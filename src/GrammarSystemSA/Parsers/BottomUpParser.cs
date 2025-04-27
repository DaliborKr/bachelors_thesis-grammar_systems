///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Parsers\BottomUpParser.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;
using GrammarSystemSA.Lexical;
using GrammarSystemSA.Components;

namespace GrammarSystemSA.Parsers
{
    /// <summary>
    /// Represents a bottom up parser (Precedence or SLR) that does syntax analysis of the input C++ program.
    /// </summary>
    public abstract class BottomUpParser : Parser
    {
        /// <summary>
        /// Represents the immersion level of the round bracket so that the bottom-up parser recognizes its own termination.
        /// </summary>
        protected int _bracketsOpenedCounter;

        // Constructor
        protected BottomUpParser(Scanner scanner, bool logEnabled) : base(scanner, logEnabled)
        {
            this._bracketsOpenedCounter = 0;
        }

        /// <summary>
        /// Pushes an actual token and state on the pushdown and reads the next token.
        /// </summary>
        protected abstract void PushAndReadNext();

        /// <summary>
        /// Reduces symbols on the top of the pushdown to a nonterminal according to the suitable grammar rule.
        /// </summary>
        protected abstract void ReducePushdownTop();

        /// <summary>
        /// Gets and removes symbols on the top of the pushdown up to the given index.
        /// </summary>
        /// <param name="index">Numeric index</param>
        /// <returns>Returns a list of terminals and nonterminals from the top of the pushdown.</returns>
        protected abstract List<TerminalNonterminal> GetAndRemoveHeadAt(int index);

        /// <summary>
        /// Groups all functions that checks actual token together.
        /// <param name="currentComponent">Instance of the component, which is currently used for parsing.</param>
        /// </summary>
        protected void CheckActualToken(Component currentComponent)
        {
            CheckBracketsOpened();
            CheckFuncCall(currentComponent);
        }

        /// <summary>
        /// Increments or decrements the bracket immersion level according to an actual token. 
        /// If the immersion level is negative, it replaces an actual token with the string termination symbol.
        /// </summary>
        private void CheckBracketsOpened()
        {
            if (this._actualToken.TerminalType == Terminal.OPEN_BRACKET_ROUND)
            {
                this._bracketsOpenedCounter++;
            }
            else if (this._actualToken.TerminalType == Terminal.CLOSE_BRACKET_ROUND)
            {
                this._bracketsOpenedCounter--;
            }

            if (this._bracketsOpenedCounter < 0)
            {
                this._actualToken = new Token(Terminal.STRING_TERMINATOR, "", -1, -1);
            }
        }

        /// <summary>
        /// It checks if a sequence of input tokens doesn't match a function call construction. 
        /// If it does, it switches LL grammar that parses function calls.
        /// <param name="currentComponent">Instance of the component, which is currently used for parsing.</param>
        /// </summary>
        private void CheckFuncCall(Component currentComponent)
        {
            if (this._actualToken.TerminalType == Terminal.ID)
            {
                List<Token> lookaheadTokens = this._scanner.Lookahead(1);

                if (lookaheadTokens[0].TerminalType == Terminal.OPEN_BRACKET_ROUND)
                {
                    // Return the scanner by 1 token so G4 can verify function call syntax from an ID token
                    this._scanner.ReturnBy(1);
                    
                    LLParser llParser = new LLParser(this._scanner, this._logEnabled, LLComponent.InstanceFunctionCall);

                    LogComponentSwitch(currentComponent, LLComponent.InstanceFunctionCall, false);
                    llParser.Parse();
                    LogComponentSwitch(currentComponent, LLComponent.InstanceFunctionCall, true);

                    // There should be a constant type set according to the return type of function ID (in the symbol table)
                    this._actualToken = new Token(Terminal.CONST_INT, "", -1, -1);
                }
            }
        }
    }
}
