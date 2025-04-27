///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Lexical\Scanner.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;
using GrammarSystemSA.Mappers;

namespace GrammarSystemSA.Lexical
{
    /// <summary>
    /// Represent Scanner for lexical analysis a provides key method called GetNextToken. 
    /// </summary>
    public class Scanner
    {
        /// <summary>
        /// Input source file.
        /// </summary>
        private readonly FileStream _sourceProgram;

        /// <summary>
        /// List of all evaluated tokens.
        /// </summary>
        private List<Token> _tokens;

        /// <summary>
        /// Final position on the previous line that scanner was reading on.
        /// </summary>
        private int _lastPositionOnPreviousLine;

        /// <summary>
        /// Current line number ofthe  input source program that scanner is reading on.
        /// </summary>
        public int ProgramLine {  get; private set; }

        /// <summary>
        /// Current position on the line that scanner is reading on.
        /// </summary>
        public int PositionOnLine {  get; private set; }

        /// <summary>
        /// Current FSM state.
        /// </summary>
        private ScannerState _currentState;

        // Constructor
        public Scanner(string fileName)
        {
            try
            {
                this.ProgramLine = 1;
                this.PositionOnLine = 1;
                this._lastPositionOnPreviousLine = 1;
                this._sourceProgram = File.OpenRead(fileName);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File not found: " + fileName);
            }

            this._tokens = [];
        }

        /// <summary>
        /// Closes the input source file.
        /// </summary>
        public void CloseInput()
        {
            this._sourceProgram.Close();
        }

        /// <summary>
        /// Reverts scanner back by n evaluated tokens.
        /// </summary>
        /// <param name="numberOfTokens">Number of evaluated tokens to return by.</param>
        public void ReturnBy(int numberOfTokens)
        {
            int index = this._tokens.Count - numberOfTokens;

            long? position = this._tokens[index].FilePosition;

            if (position is null)
            {
                throw new ArgumentNullException(nameof(position));
            }
            else
            {
                // Revert scanner
                this.ProgramLine = this._tokens[this._tokens.Count - numberOfTokens].Line;
                this.PositionOnLine = this._tokens[_tokens.Count - numberOfTokens].PositionOnLine;
                this._sourceProgram.Seek((long)position, SeekOrigin.Begin);
                this._tokens.RemoveRange(this._tokens.Count - numberOfTokens, numberOfTokens);

                while (Char.IsWhiteSpace((char)this._sourceProgram.ReadByte()));
                this._sourceProgram.Seek(-1, SeekOrigin.Current);
            }
        }

        /// <summary>
        /// Returns list of following n tokens and revert scanner to original condition.
        /// </summary>
        /// <param name="n">Number of tokens to lookahead on.</param>
        /// <returns>List of following n tokens.</returns>
        public List<Token> Lookahead(int n)
        {
            // Marking original condition of the scanner
            long filePosition = this._sourceProgram.Position;
            int programLineBackUp = this.ProgramLine;
            int positionOnLineBackUp = this.PositionOnLine;

            List<Token> lookaheadTokens = new List<Token>();

            // Lookahead
            for (int i = 0; i < n; i++)
            {
                lookaheadTokens.Add(GetNextToken());
            }

            // Revert scanner to the original condition
            this._tokens.RemoveRange(this._tokens.Count - n, n);
            this._sourceProgram.Seek(filePosition, SeekOrigin.Begin);
            this.ProgramLine = programLineBackUp;
            this.PositionOnLine = positionOnLineBackUp;

            return lookaheadTokens;
        }

        /// <summary>
        /// Returns a following token from the input file.
        /// </summary>
        /// <returns>Following token from the input file.</returns>
        public Token GetNextToken()
        {
            this._currentState = ScannerState.START;

            Token token = new Token(Terminal.UNDEFINED_TERMINAL, "", this.ProgramLine, this.PositionOnLine);
            token.FilePosition = this._sourceProgram.Position;

            while (token.TerminalType == Terminal.UNDEFINED_TERMINAL) 
            {
                EvaluateNextState((char)this._sourceProgram.ReadByte(), token);
            }

            if (token.TerminalType == Terminal.ID)
            {
                MapKeywordOnToken(token);
            }

            this._tokens.Add(token);

            return token;
        }

        /// <summary>
        /// Updates properties tracking current position in the file.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        private void UpdateFilePosition(char input)
        {
            if (input == '\n')
            {
                this.ProgramLine++;
                this._lastPositionOnPreviousLine = this.PositionOnLine;
                this.PositionOnLine = 1;
            }
            else
            {
                this.PositionOnLine++;
            }
        }

        /// <summary>
        /// Returns the input file cursor by 1 (if it is possible) and updates properties tracking current position in the file.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        private void SeekBackByOne(char input)
        {
            if (input == Constants.Eof)
            {
                return;
            }
            
            else if (input == '\n')
            {
                this.ProgramLine--;
                this.PositionOnLine = _lastPositionOnPreviousLine;
            }
            else
            {
                this.PositionOnLine--;
            }
            this._sourceProgram.Seek(-1, SeekOrigin.Current);
        }

        /// <summary>
        /// Returns an lexical error description message.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="stateName">Name of the state where an error occurs.</param>
        /// <returns>Lexical error description message.</returns>
        private static string MakeErrorMessage(string input, string stateName)
        {
            return "Invalid character in state '" + stateName + "': " + input;
        }

        /// <summary>
        /// Returns last evaluated token.
        /// </summary>
        /// <returns>Last evaluated token.</returns>
        public Token GetLastToken()
        {
            return this._tokens.Last();
        }

        /// <summary>
        /// Determines if the value of the id token matches with the keyword and changes the token type if yes.
        /// </summary>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void MapKeywordOnToken(Token token)
        {
            if (KeywordTokenMapper.Map.ContainsKey(token.TerminalValue))
            {
                token.TerminalType = KeywordTokenMapper.Map[token.TerminalValue];
            }
        }

        /// <summary>
        /// Based on the current state decides which state method will be called.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void EvaluateNextState(char input, Token token)
        {
            UpdateFilePosition(input);
            switch (this._currentState) 
            {
                case ScannerState.START:
                    StartState(input, token);
                    break;

                case ScannerState.ID_KEYWORD:
                    IdKeywordState(input, token);
                    break;

                case ScannerState.LINE_COMMENT:
                    LineCommentState(input);
                    break;

                case ScannerState.BLOCK_COMMENT_START: 
                    BlockCommentStartState(input, token);
                    break;

                case ScannerState.BLOCK_COMMENT_END: 
                    BlockCommentEndState(input, token);
                    break;

                case ScannerState.HASHTAG:
                    HashtagState(input, token);
                    break;

                case ScannerState.ASSIGN:
                    AssignState(input, token);
                    break;

                case ScannerState.PLUS:
                    PlusState(input, token);
                    break;

                case ScannerState.MINUS:
                    MinusState(input, token);
                    break;

                case ScannerState.MULTIPLY:
                    MultiplyState(input, token);
                    break;

                case ScannerState.DIVIDE:
                    DivideState(input, token);
                    break;
                
                case ScannerState.MODULO:
                    ModuloState(input, token);
                    break;
                
                case ScannerState.NOT:
                    NotState(input, token);
                    break;
                
                case ScannerState.LESS:
                    LessState(input, token);
                    break;
                
                case ScannerState.GREATER:
                    GreaterState(input, token);
                    break;
                
                case ScannerState.AND_1:
                    And1State(input, token);
                    break;
                
                case ScannerState.OR_1:
                    Or1State(input, token);
                    break;
                
                case ScannerState.INTEGER_1:
                    Integer1State(input, token);
                    break;
                
                case ScannerState.INTEGER_2:
                    Integer2State(input, token);
                    break;
                
                case ScannerState.INTEGER_HEXA_START:
                    IntegerHexaStartState(input, token);
                    break;
                
                case ScannerState.INTEGER_HEXA:
                    IntegerHexaState(input, token);
                    break;
                
                case ScannerState.DOUBLE_0:
                    Double0State(input, token);
                    break;
                
                case ScannerState.DOUBLE_1:
                    Double1State(input, token);
                    break;
                
                case ScannerState.DOUBLE_2:
                    Double2State(input, token);
                    break;
                
                case ScannerState.EXPONENT:
                    ExponentState(input, token);
                    break;
                
                case ScannerState.EXPONENT_SIGN:
                    ExponentSignState(input, token);
                    break;
                
                case ScannerState.CHAR_START:
                    CharStartState(input, token);
                    break;
                
                case ScannerState.CHAR_VALUE:
                    CharValueState(input, token);
                    break;
                
                case ScannerState.CHAR_ESCAPE:
                    CharEscapeState(input, token);
                    break;
                
                case ScannerState.STRING_VALUE:
                    StringValueState(input, token);
                    break;
                
                case ScannerState.STRING_ESCAPE:
                    StringEscapeState(input, token);
                    break;
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Start.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void StartState(char input, Token token) 
        {
            switch (input)
            {
                case '\n':
                    token.TerminalType = Terminal.EOL;
                    break;
                case Constants.Eof:
                    token.TerminalType = Terminal.EOF;
                    break;
                case '(':
                    token.TerminalType = Terminal.OPEN_BRACKET_ROUND;
                    break;
                case ')':
                    token.TerminalType = Terminal.CLOSE_BRACKET_ROUND;
                    break;
                case '{':
                    token.TerminalType = Terminal.OPEN_BRACKET_CURLY;
                    break;
                case '}':
                    token.TerminalType = Terminal.CLOSE_BRACKET_CURLY;
                    break;
                case ';':
                    token.TerminalType = Terminal.SEMICOLON;
                    break;
                case ':':
                    token.TerminalType = Terminal.COLON;
                    break;
                case ',':
                    token.TerminalType = Terminal.COMMA;
                    break;
                case '/':
                    this._currentState = ScannerState.DIVIDE;
                    break;
                case '#':
                    this._currentState = ScannerState.HASHTAG;
                    break;
                case '\'':
                    this._currentState = ScannerState.CHAR_START;
                    break;
                case '\"':
                    this._currentState = ScannerState.STRING_VALUE;
                    break;
                case '|':
                    this._currentState = ScannerState.OR_1;
                    break;
                case '&':
                    this._currentState = ScannerState.AND_1;
                    break;
                case '>':
                    this._currentState = ScannerState.GREATER;
                    break;
                case '<':
                    this._currentState = ScannerState.LESS;
                    break;
                case '!':
                    this._currentState = ScannerState.NOT;
                    break;
                case '%':
                    this._currentState = ScannerState.MODULO;
                    break;
                case '*':
                    this._currentState = ScannerState.MULTIPLY;
                    break;
                case '-':
                    this._currentState = ScannerState.MINUS;
                    break;
                case '+':
                    this._currentState = ScannerState.PLUS;
                    break;
                case '=':
                    this._currentState = ScannerState.ASSIGN;
                    break;
                case '0':
                    token.TerminalValue += input;
                    this._currentState = ScannerState.INTEGER_1;
                    break;
                case '.':
                    token.TerminalValue += input;
                    this._currentState = ScannerState.DOUBLE_0;
                    break;
                default:
                    if (Char.IsDigit(input))
                    {
                        token.TerminalValue += input;
                        this._currentState = ScannerState.INTEGER_1;
                    }
                    else if (Char.IsLetter(input) || input == '_') 
                    {
                        token.TerminalValue += input;
                        this._currentState = ScannerState.ID_KEYWORD;
                    }
                    else if (Char.IsWhiteSpace(input))
                    {
                        token.PositionOnLine++;
                        // Stay in the current state (Start state)
                    }
                    else
                    {
                        token.TerminalType = Terminal.ERROR_TOKEN;
                        token.TerminalValue = MakeErrorMessage(input.ToString(), "Start");
                    }
                    break;
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Id or keyword.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void IdKeywordState(char input, Token token)
        {
            if (Char.IsLetter(input) || input == '_' || Char.IsDigit(input)) 
            {
                token.TerminalValue += input;
            }
            else
            {
                token.TerminalType = Terminal.ID;

                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Line comment.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        private void LineCommentState(char input)
        {
            if (input == Constants.Eof || input == '\n')
            {
                this._currentState = ScannerState.START;
            }

            // Else stay in the current state (Line comment state)
        }

        /// <summary>
        /// Logic of the FSM state named: Block comment start.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void BlockCommentStartState(char input, Token token)
        {
            if (input == '*')
            {
                this._currentState = ScannerState.BLOCK_COMMENT_END;
            }
            else if (input == Constants.Eof)
            {
                token.TerminalType = Terminal.ERROR_TOKEN;
                token.TerminalValue = MakeErrorMessage("Eof", "Block comment start");
            }

            // Else stay in the current state (Block comment start state)
        }

        /// <summary>
        /// Logic of the FSM state named: Block comment end.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void BlockCommentEndState(char input, Token token)
        {
            if (input == '/')
            {
                this._currentState = ScannerState.START;
            }
            else if (input == '*')
            {
                // Stay in the current state (Block comment ending state)
            }
            else if (input == Constants.Eof)
            {
                token.TerminalType = Terminal.ERROR_TOKEN;
                token.TerminalValue = MakeErrorMessage("Eof", "Block comment ending");
            }
            else
            {
                this._currentState = ScannerState.BLOCK_COMMENT_START;
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Hashtag.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void HashtagState(char input, Token token)
        {
            token.TerminalValue += input;
            int i = 1;
            while (i < Constants.Define.Length)
            {
                input = (char)this._sourceProgram.ReadByte();
                UpdateFilePosition(input);
                token.TerminalValue += input;
                i++;
            }

            if (token.TerminalValue.Equals(Constants.Define))
            {
                token.TerminalType = Terminal.DEFINE;
                return;
            }
            else
            {
                token.TerminalType = Terminal.ERROR_TOKEN;
                token.TerminalValue = MakeErrorMessage(token.TerminalValue, "Hashtag");
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Assign.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void AssignState(char input, Token token)
        {
            if (input == '=')
            {
                token.TerminalType = Terminal.EQUAL;
            }
            else
            {
                token.TerminalType = Terminal.ASSIGN;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Plus.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void PlusState(char input, Token token)
        {
            if (input == '=')
            {
                token.TerminalType = Terminal.PLUS_ASSIGN;
            }
            else if (input == '+')
            {
                Token? previousToken = GetLastToken();

                if (previousToken != null && previousToken.TerminalType == Terminal.ID)
                {
                    token.TerminalType = Terminal.POSTFIX_INCREMENT;
                }
                else
                {
                    token.TerminalType = Terminal.PREFIX_INCREMENT;
                }
            }
            else
            {
                token.TerminalType = Terminal.PLUS;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Minus.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void MinusState(char input, Token token)
        {
            if (input == '=')
            {
                token.TerminalType = Terminal.MINUS_ASSIGN;
            }
            else if (input == '-')
            {
                Token? previousToken = GetLastToken();

                if (previousToken != null && previousToken.TerminalType == Terminal.ID)
                {
                    token.TerminalType = Terminal.POSTFIX_DECREMENT;
                }
                else
                {
                    token.TerminalType = Terminal.PREFIX_DECREMENT;
                }
            }
            else
            {
                token.TerminalType = Terminal.MINUS;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Multiply.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void MultiplyState(char input, Token token)
        {
            if (input == '=')
            {
                token.TerminalType = Terminal.MULTIPLY_ASSIGN;
            }
            else
            {
                token.TerminalType = Terminal.MULTIPLY;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Divide.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void DivideState(char input, Token token)
        {
            if (input == '=')
            {
                token.TerminalType = Terminal.DIVIDE_ASSIGN;
            }
            else if (input == '/')
            {
                this._currentState = ScannerState.LINE_COMMENT;
            }
            else if (input == '*')
            {
                this._currentState = ScannerState.BLOCK_COMMENT_START;
            }
            else
            {
                token.TerminalType = Terminal.DIVIDE;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Modulo.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void ModuloState(char input, Token token)
        {
            if (input == '=')
            {
                token.TerminalType = Terminal.MODULO_ASSIGN;
            }
            else
            {
                token.TerminalType = Terminal.MODULO;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Not.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void NotState(char input, Token token)
        {
            if (input == '=')
            {
                token.TerminalType = Terminal.NOT_EQUAL;
            }
            else
            {
                token.TerminalType = Terminal.NOT;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Less.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void LessState(char input, Token token)
        {
            if (input == '=')
            {
                token.TerminalType = Terminal.LESS_EQUAL;
            }
            else
            {
                token.TerminalType = Terminal.LESS;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Greater.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void GreaterState(char input, Token token)
        {
            if (input == '=')
            {
                token.TerminalType = Terminal.GREATER_EQUAL;
            }
            else
            {
                token.TerminalType = Terminal.GREATER;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: And1.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void And1State(char input, Token token)
        {
            if (input == '&')
            {
                token.TerminalType = Terminal.AND;
            }
            else
            {
                token.TerminalType = Terminal.ERROR_TOKEN;
                token.TerminalValue = MakeErrorMessage(input.ToString(), "And 1");
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Or1.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void Or1State(char input, Token token)
        {
            if (input == '|')
            {
                token.TerminalType = Terminal.OR;
            }
            else
            {
                token.TerminalType = Terminal.ERROR_TOKEN;
                token.TerminalValue = MakeErrorMessage(input.ToString(), "Or 1");
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Integer1.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void Integer1State(char input, Token token)
        {
            if (input == 'x' || input == 'X')
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.INTEGER_HEXA_START;
            }
            else if (Char.IsDigit(input))
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.INTEGER_2;
            }
            else if (input == '.')
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.DOUBLE_0;
            }
            else
            {
                token.TerminalType = Terminal.CONST_INT;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Integer2.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void Integer2State(char input, Token token)
        {
            if (input == 'e' || input == 'E')
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.EXPONENT;
            }
            else if (Char.IsDigit(input))
            {
                token.TerminalValue += input;
            }
            else if (input == '.')
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.DOUBLE_0;
            }
            else
            {
                token.TerminalType = Terminal.CONST_INT;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Integer hexa start.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void IntegerHexaStartState(char input, Token token)
        {
            if (Char.IsDigit(input) ||
                input >= 'a' && input <= 'f' ||
                input >= 'A' && input <= 'F' )
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.INTEGER_HEXA;
            }
            else
            {
                token.TerminalType = Terminal.ERROR_TOKEN;
                token.TerminalValue = MakeErrorMessage(input.ToString(), "Integer hexa start");
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Integer hexa.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void IntegerHexaState(char input, Token token)
        {
            if (Char.IsDigit(input) ||
                input >= 'a' && input <= 'f' ||
                input >= 'A' && input <= 'F')
            {
                token.TerminalValue += input;
            }
            else
            {
                token.TerminalType = Terminal.CONST_INT;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Double0.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void Double0State(char input, Token token)
        {
            if (Char.IsDigit(input))
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.DOUBLE_1;
            }
            else if (input == 'e' || input == 'E')
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.EXPONENT;
            }
            else
            {
                token.TerminalType = Terminal.ERROR_TOKEN;
                token.TerminalValue = MakeErrorMessage(input.ToString(), "Double 0");
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Double1.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void Double1State(char input, Token token)
        {
            if (Char.IsDigit(input))
            {
                token.TerminalValue += input;
            }
            else if (input == 'e' || input == 'E')
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.EXPONENT;
            }
            else if (input == 'f' || input == 'F')
            {
                token.TerminalValue += input;
                token.TerminalType = Terminal.CONST_FLOAT;
            }
            else
            {
                token.TerminalType = Terminal.CONST_DOUBLE;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Double2.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void Double2State(char input, Token token)
        {
            if (Char.IsDigit(input))
            {
                token.TerminalValue += input;
            }
            else if (input == 'f' || input == 'F')
            {
                token.TerminalValue += input;
                token.TerminalType = Terminal.CONST_FLOAT;
            }
            else
            {
                token.TerminalType = Terminal.CONST_DOUBLE;
                SeekBackByOne(input);
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Exponent.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void ExponentState(char input, Token token)
        {
            if (Char.IsDigit(input))
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.DOUBLE_2;
            }
            else if (input == '-')
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.EXPONENT_SIGN;
            }
            else
            {
                token.TerminalType = Terminal.ERROR_TOKEN;
                token.TerminalValue = MakeErrorMessage(input.ToString(), "Exponent");
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Exponent sign.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void ExponentSignState(char input, Token token)
        {
            if (Char.IsDigit(input))
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.DOUBLE_2;
            }
            else
            {
                token.TerminalType = Terminal.ERROR_TOKEN;
                token.TerminalValue = MakeErrorMessage(input.ToString(), "Exponent sign");
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Char start.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void CharStartState(char input, Token token)
        {
            if (input == '\\')
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.CHAR_ESCAPE;
            }
            else if (input == Constants.Eof)
            {
                token.TerminalType = Terminal.ERROR_TOKEN;
                token.TerminalValue = MakeErrorMessage("Eof", "Char start");
            }
            else
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.CHAR_VALUE;
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Char value.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void CharValueState(char input, Token token)
        {
            if (input == '\'')
            {
                token.TerminalType = Terminal.CONST_CHAR;
            }
            else
            {
                token.TerminalType = Terminal.ERROR_TOKEN;
                token.TerminalValue = MakeErrorMessage(input.ToString(), "Char value");
            }
        }

        /// <summary>
        /// Logic of the FSM state named: Char escape.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void CharEscapeState(char input, Token token)
        {
            switch (input)
            {
                case 'n':
                case 't':
                case 'r':
                case '\'':
                case '\"':
                case '?':
                case '\\':
                    token.TerminalValue += input;
                    this._currentState = ScannerState.CHAR_VALUE;
                    break;
                default:
                    token.TerminalType = Terminal.ERROR_TOKEN;
                    token.TerminalValue = MakeErrorMessage(input.ToString(), "Char escape");
                    break;
            }
        }

        /// <summary>
        /// Logic of the FSM state named: String value.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void StringValueState(char input, Token token)
        {
            if (input == '\\')
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.STRING_ESCAPE;
            }
            else if (input == '\"')
            {
                token.TerminalType = Terminal.CONST_STRING;
            }
            else if (input == Constants.Eof)
            {
                token.TerminalType = Terminal.ERROR_TOKEN;
                token.TerminalValue = MakeErrorMessage("Eof", "String value");
            }
            else
            {
                token.TerminalValue += input;
                this._currentState = ScannerState.STRING_VALUE;
            }
        }

        /// <summary>
        /// Logic of the FSM state named: String escape.
        /// </summary>
        /// <param name="input">Character read from the input file.</param>
        /// <param name="token">Instance of a token that is currently being specified.</param>
        private void StringEscapeState(char input, Token token)
        {
            switch (input)
            {
                case 'n':
                case 't':
                case 'r':
                case '\'':
                case '\"':
                case '?':
                case '\\':
                    token.TerminalValue += input;
                    this._currentState = ScannerState.STRING_VALUE;
                    break;
                default:
                    token.TerminalType = Terminal.ERROR_TOKEN;
                    token.TerminalValue = MakeErrorMessage(input.ToString(), "Char escape");
                    break;
            }
        }
    }
}
