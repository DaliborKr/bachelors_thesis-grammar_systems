///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Grammars\GrammarSetsData.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Grammars
{
    /// <summary>
    /// Definitions of Lists of grammar rules representing all grammars used in the grammar system and of
    /// First and Follow sets for LL grammars.
    /// </summary>
    public class GrammarSetsData
    {
        /// <summary>
        /// Grammar G1 LL Body
        /// </summary>
        public static readonly List<GrammarRule> LLBody =
        [
            new(0, Nonterminal.G1_START,
                [
                    TerminalNonterminal.G1_PROGRAM_MAIN,
                    TerminalNonterminal.STRING_TERMINATOR
                ]),

            new(1, Nonterminal.G1_PROGRAM_MAIN,
                [
                    TerminalNonterminal.G1_DEFINE,
                    TerminalNonterminal.EOL,
                    TerminalNonterminal.G1_PROGRAM_MAIN
                ]),

            new(2, Nonterminal.G1_PROGRAM_MAIN,
                [
                    TerminalNonterminal.G1_VAR_DEF,
                    TerminalNonterminal.SEMICOLON,
                    TerminalNonterminal.G1_PROGRAM_MAIN
                ]),

            new(3, Nonterminal.G1_PROGRAM_MAIN,
                [
                    TerminalNonterminal.G1_FUNC_DTYPE,
                    TerminalNonterminal.ID,
                    TerminalNonterminal.OPEN_BRACKET_ROUND,
                    TerminalNonterminal.G1_PARAMETERS,
                    TerminalNonterminal.CLOSE_BRACKET_ROUND,
                    TerminalNonterminal.G1_CONSTRUCT_BLOCK,
                    TerminalNonterminal.G1_PROGRAM_MAIN
                ]),

            new(4, Nonterminal.G1_PROGRAM_MAIN,
                [
                    TerminalNonterminal.EOF
                ]),

            new(5, Nonterminal.G1_CONSTRUCT_BLOCK,
                [
                    TerminalNonterminal.OPEN_BRACKET_CURLY,
                    TerminalNonterminal.G1_CONSTRUCT_CONT,
                    TerminalNonterminal.CLOSE_BRACKET_CURLY
                ]),

            new(6, Nonterminal.G1_CONSTRUCT_CONT,
                [
                    TerminalNonterminal.G1_CONSTRUCT,
                    TerminalNonterminal.G1_CONSTRUCT_CONT
                ]),

            new(7, Nonterminal.G1_CONSTRUCT_CONT,
                [
                // EPSILON
                ]),

            new(8, Nonterminal.G1_CONSTRUCT,
                [
                    TerminalNonterminal.IF,
                    TerminalNonterminal.OPEN_BRACKET_ROUND,
                    TerminalNonterminal.G1_ELEMENT,
                    TerminalNonterminal.CLOSE_BRACKET_ROUND,
                    TerminalNonterminal.G1_CONSTRUCT_BLOCK,
                    TerminalNonterminal.G1_IF_CONT
                ]),

            new(9, Nonterminal.G1_CONSTRUCT,
                [
                    TerminalNonterminal.SWITCH,
                    TerminalNonterminal.OPEN_BRACKET_ROUND,
                    TerminalNonterminal.G1_ELEMENT,
                    TerminalNonterminal.CLOSE_BRACKET_ROUND,
                    TerminalNonterminal.G1_CONSTRUCT_BLOCK
                ]),

            new(10, Nonterminal.G1_CONSTRUCT,
                [
                    TerminalNonterminal.WHILE,
                    TerminalNonterminal.OPEN_BRACKET_ROUND,
                    TerminalNonterminal.G1_ELEMENT,
                    TerminalNonterminal.CLOSE_BRACKET_ROUND,
                    TerminalNonterminal.G1_CONSTRUCT_BLOCK
                ]),

            new(11, Nonterminal.G1_CONSTRUCT,
                [
                    TerminalNonterminal.DO,
                    TerminalNonterminal.G1_CONSTRUCT_BLOCK,
                    TerminalNonterminal.WHILE,
                    TerminalNonterminal.OPEN_BRACKET_ROUND,
                    TerminalNonterminal.G1_VALUE,
                    TerminalNonterminal.CLOSE_BRACKET_ROUND
                ]),

            new(12, Nonterminal.G1_CONSTRUCT,
                [
                    TerminalNonterminal.FOR,
                    TerminalNonterminal.OPEN_BRACKET_ROUND,
                    TerminalNonterminal.G1_ELEMENT,
                    TerminalNonterminal.SEMICOLON,
                    TerminalNonterminal.G1_VALUE,
                    TerminalNonterminal.SEMICOLON,
                    TerminalNonterminal.G1_VALUE,
                    TerminalNonterminal.CLOSE_BRACKET_ROUND,
                    TerminalNonterminal.G1_CONSTRUCT_BLOCK
                ]),

            new(13, Nonterminal.G1_CONSTRUCT,
                [
                    TerminalNonterminal.RETURN,
                    TerminalNonterminal.G1_VALUE,
                    TerminalNonterminal.SEMICOLON
                ]),

            new(14, Nonterminal.G1_CONSTRUCT,
                [
                    TerminalNonterminal.BREAK,
                    TerminalNonterminal.SEMICOLON
                ]),

            new(15, Nonterminal.G1_CONSTRUCT,
                [
                    TerminalNonterminal.CONTINUE,
                    TerminalNonterminal.SEMICOLON
                ]),

            new(16, Nonterminal.G1_CONSTRUCT,
                [
                    TerminalNonterminal.CASE,
                    TerminalNonterminal.G3_S_START,
                    TerminalNonterminal.COLON
                ]),

            new(17, Nonterminal.G1_CONSTRUCT,
                [
                    TerminalNonterminal.DEFAULT,
                    TerminalNonterminal.COLON
                ]),

            new(18, Nonterminal.G1_CONSTRUCT,
                [
                    TerminalNonterminal.G1_DEFINE,
                    TerminalNonterminal.EOL
                ]),

            new(19, Nonterminal.G1_CONSTRUCT,
                [
                    TerminalNonterminal.G1_ELEMENT,
                    TerminalNonterminal.SEMICOLON
                ]),

            new(20, Nonterminal.G1_ELEMENT,
                [
                    TerminalNonterminal.G1_VAR_DEF
                ]),

            new(21, Nonterminal.G1_ELEMENT,
                [
                    TerminalNonterminal.G1_VALUE
                ]),

            new(22, Nonterminal.G1_VAR_DEF,
                [
                    TerminalNonterminal.G1_DTYPE,
                    TerminalNonterminal.ID,
                    TerminalNonterminal.G1_ASSIGN
                ]),

            new(23, Nonterminal.G1_ASSIGN,
                [
                    TerminalNonterminal.ASSIGN,
                    TerminalNonterminal.G3_S_START
                ]),

            new(24, Nonterminal.G1_ASSIGN,
                [
                    // EPSILON
                ]),

            new(25, Nonterminal.G1_VALUE,
                [
                    TerminalNonterminal.G2_AS
                ]),

            new(26, Nonterminal.G1_VALUE,
                [
                    // EPSILON
                ]),

            new(27, Nonterminal.G1_DEFINE,
                [
                    TerminalNonterminal.DEFINE,
                    TerminalNonterminal.ID,
                    TerminalNonterminal.G3_S_START
                ]),

            new(28, Nonterminal.G1_IF_CONT,
                [
                    TerminalNonterminal.ELSE,
                    TerminalNonterminal.G1_ELSE_IF_CONT
                ]),

            new(29, Nonterminal.G1_IF_CONT,
                [
                    // EPSILON
                ]),

            new(30, Nonterminal.G1_ELSE_IF_CONT,
                [
                    TerminalNonterminal.IF,
                    TerminalNonterminal.OPEN_BRACKET_ROUND,
                    TerminalNonterminal.G1_ELEMENT,
                    TerminalNonterminal.CLOSE_BRACKET_ROUND,
                    TerminalNonterminal.G1_CONSTRUCT_BLOCK,
                    TerminalNonterminal.G1_IF_CONT
                ]),

            new(31, Nonterminal.G1_ELSE_IF_CONT,
                [
                    TerminalNonterminal.G1_CONSTRUCT_BLOCK
                ]),

            new(32, Nonterminal.G1_FUNC_DTYPE,
                [
                    TerminalNonterminal.VOID
                ]),

            new(33, Nonterminal.G1_FUNC_DTYPE,
                [
                    TerminalNonterminal.G1_DTYPE
                ]),

            new(34, Nonterminal.G1_PARAMETERS,
                [
                    TerminalNonterminal.G1_VAR_DEF,
                    TerminalNonterminal.G1_PARAMETERS_CONT
                ]),

            new(35, Nonterminal.G1_PARAMETERS,
                [
                    // EPSILON
                ]),

            new(36, Nonterminal.G1_PARAMETERS_CONT,
                [
                    TerminalNonterminal.COMMA,
                    TerminalNonterminal.G1_VAR_DEF,
                    TerminalNonterminal.G1_PARAMETERS_CONT
                ]),

            new(37, Nonterminal.G1_PARAMETERS_CONT,
                [
                    // EPSILON
                ]),

            new(38, Nonterminal.G1_DTYPE,
                [
                    TerminalNonterminal.INT
                ]),

            new(39, Nonterminal.G1_DTYPE,
                [
                    TerminalNonterminal.FLOAT
                ]),

            new(40, Nonterminal.G1_DTYPE,
                [
                    TerminalNonterminal.DOUBLE
                ]),

            new(41, Nonterminal.G1_DTYPE,
                [
                    TerminalNonterminal.CHAR
                ]),

            new(42, Nonterminal.G1_DTYPE,
                [
                    TerminalNonterminal.STRING
                ]),

            new(43, Nonterminal.G1_DTYPE,
                [
                    TerminalNonterminal.BOOL
                ])
        ];

        /// <summary> 
        /// Grammar G4 LL Function Call
        /// </summary>
        public static readonly List<GrammarRule> LLFunctionCall =
        [
            new(0, Nonterminal.G4_START,
                [
                    TerminalNonterminal.G4_FUNCTION_CALL,
                    TerminalNonterminal.STRING_TERMINATOR
                ]),

            new(1, Nonterminal.G4_FUNCTION_CALL,
                [
                    TerminalNonterminal.ID,
                    TerminalNonterminal.OPEN_BRACKET_ROUND,
                    TerminalNonterminal.G4_ARGS,
                    TerminalNonterminal.CLOSE_BRACKET_ROUND
                ]),

            new(2, Nonterminal.G4_ARGS,
                [
                    TerminalNonterminal.G2_AS,
                    TerminalNonterminal.G4_ARGS_CONT
                ]),

            new(3, Nonterminal.G4_ARGS,
                [
                    // EPSILON
                ]),

            new(4, Nonterminal.G4_ARGS_CONT,
                [
                    TerminalNonterminal.COMMA,
                    TerminalNonterminal.G2_AS,
                    TerminalNonterminal.G4_ARGS_CONT
                ]),

            new(5, Nonterminal.G4_ARGS_CONT,
                [
                    // EPSILON
                ])
        ];

        /// <summary>
        /// Grammar G2 Precedence Expressions with an assignment
        /// </summary>
        public static readonly List<GrammarRule> Precedence =
        [
            new(1, Nonterminal.G2_AS,
                [
                    TerminalNonterminal.ID,
                    TerminalNonterminal.ASSIGN,
                    TerminalNonterminal.G2_EXP
                ]),

            new(2, Nonterminal.G2_AS,
                [
                    TerminalNonterminal.ID,
                    TerminalNonterminal.PLUS_ASSIGN,
                    TerminalNonterminal.G2_EXP
                ]),

            new(3, Nonterminal.G2_AS,
                [
                    TerminalNonterminal.ID,
                    TerminalNonterminal.MINUS_ASSIGN,
                    TerminalNonterminal.G2_EXP
                ]),

            new(4, Nonterminal.G2_AS,
                [
                    TerminalNonterminal.ID,
                    TerminalNonterminal.MULTIPLY_ASSIGN,
                    TerminalNonterminal.G2_EXP
                ]),

            new(5, Nonterminal.G2_AS,
                [
                    TerminalNonterminal.ID,
                    TerminalNonterminal.DIVIDE_ASSIGN,
                    TerminalNonterminal.G2_EXP
                ]),

            new(6, Nonterminal.G2_AS,
                [
                    TerminalNonterminal.ID,
                    TerminalNonterminal.MODULO_ASSIGN,
                    TerminalNonterminal.G2_EXP
                ]),

            new(7, Nonterminal.G2_AS,
                [
                    TerminalNonterminal.G2_EXP
                ]),

            new(8, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.OR,
                    TerminalNonterminal.G2_EXP
                ]),

            new(9, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.AND,
                    TerminalNonterminal.G2_EXP
                ]),

            new(10, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.EQUAL,
                    TerminalNonterminal.G2_EXP
                ]),

            new(11, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.NOT_EQUAL,
                    TerminalNonterminal.G2_EXP
                ]),

            new(12, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.GREATER,
                    TerminalNonterminal.G2_EXP
                ]),

            new(13, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.LESS,
                    TerminalNonterminal.G2_EXP
                ]),

            new(14, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.LESS_EQUAL,
                    TerminalNonterminal.G2_EXP
                ]),

            new(15, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.GREATER_EQUAL,
                    TerminalNonterminal.G2_EXP
                ]),

            new(16, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.PLUS,
                    TerminalNonterminal.G2_EXP
                ]),

            new(17, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.MINUS,
                    TerminalNonterminal.G2_EXP
                ]),

            new(18, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.MULTIPLY,
                    TerminalNonterminal.G2_EXP
                ]),

            new(19, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.DIVIDE,
                    TerminalNonterminal.G2_EXP
                ]),

            new(20, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.MODULO,
                    TerminalNonterminal.G2_EXP
                ]),

            new(21, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.POSTFIX_INCREMENT
                ]),

            new(22, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.POSTFIX_DECREMENT
                ]),

            new(23, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.NOT,
                    TerminalNonterminal.G2_EXP
                ]),

            new(24, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.PREFIX_INCREMENT,
                    TerminalNonterminal.G2_EXP
                ]),

            new(25, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.PREFIX_DECREMENT,
                    TerminalNonterminal.G2_EXP
                ]),

            new(26, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.CONST_INT
                ]),

            new(27, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.CONST_FLOAT
                ]),

            new(28, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.CONST_DOUBLE
                ]),

            new(29, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.CONST_CHAR
                ]),

            new(30, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.CONST_STRING
                ]),

            new(31, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.CONST_TRUE
                ]),

            new(32, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.CONST_FALSE
                ]),

            new(33, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.ID
                ]),

            new(34, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.OPEN_BRACKET_ROUND,
                    TerminalNonterminal.G2_AS,
                    TerminalNonterminal.CLOSE_BRACKET_ROUND
                ]),

            new(35, Nonterminal.G2_EXP,
                [
                    TerminalNonterminal.OPEN_BRACKET_ROUND,
                    TerminalNonterminal.G2_EXP,
                    TerminalNonterminal.CLOSE_BRACKET_ROUND
                ])
        ];

        /// <summary>
        /// Grammar G3 SLR Expressions without an assignment
        /// </summary>
        public static readonly List<GrammarRule> SLR =
        [
            new(0, Nonterminal.G3_S_START,
                [
                    TerminalNonterminal.G3_O
                ]),

            new(1, Nonterminal.G3_O,
                [
                    TerminalNonterminal.G3_O,
                    TerminalNonterminal.OR,
                    TerminalNonterminal.G3_A
                ]),

            new(2, Nonterminal.G3_O,
                [
                    TerminalNonterminal.G3_A
                ]),

            new(3, Nonterminal.G3_A,
                [
                    TerminalNonterminal.G3_A,
                    TerminalNonterminal.AND,
                    TerminalNonterminal.G3_C1
                ]),

            new(4, Nonterminal.G3_A,
                [
                    TerminalNonterminal.G3_C1
                ]),

            new(5, Nonterminal.G3_C1,
                [
                    TerminalNonterminal.G3_C1,
                    TerminalNonterminal.EQUAL,
                    TerminalNonterminal.G3_C2
                ]),

            new(6, Nonterminal.G3_C1,
                [
                    TerminalNonterminal.G3_C1,
                    TerminalNonterminal.NOT_EQUAL,
                    TerminalNonterminal.G3_C2
                ]),

            new(7, Nonterminal.G3_C1,
                [
                    TerminalNonterminal.G3_C2
                ]),

            new(8, Nonterminal.G3_C2,
                [
                    TerminalNonterminal.G3_C2,
                    TerminalNonterminal.GREATER,
                    TerminalNonterminal.G3_E
                ]),

            new(9, Nonterminal.G3_C2,
                [
                    TerminalNonterminal.G3_C2,
                    TerminalNonterminal.LESS,
                    TerminalNonterminal.G3_E
                ]),

            new(10, Nonterminal.G3_C2,
                [
                    TerminalNonterminal.G3_C2,
                    TerminalNonterminal.LESS_EQUAL,
                    TerminalNonterminal.G3_E
                ]),

            new(11, Nonterminal.G3_C2,
                [
                    TerminalNonterminal.G3_C2,
                    TerminalNonterminal.GREATER_EQUAL,
                    TerminalNonterminal.G3_E
                ]),

            new(12, Nonterminal.G3_C2,
                [
                    TerminalNonterminal.G3_E
                ]),

            new(13, Nonterminal.G3_E,
                [
                    TerminalNonterminal.G3_E,
                    TerminalNonterminal.PLUS,
                    TerminalNonterminal.G3_T
                ]),

            new(14, Nonterminal.G3_E,
                [
                    TerminalNonterminal.G3_E,
                    TerminalNonterminal.MINUS,
                    TerminalNonterminal.G3_T
                ]),

            new(15, Nonterminal.G3_E,
                [
                    TerminalNonterminal.G3_T
                ]),

            new(16, Nonterminal.G3_T,
                [
                    TerminalNonterminal.G3_T,
                    TerminalNonterminal.MULTIPLY,
                    TerminalNonterminal.G3_N
                ]),

            new(17, Nonterminal.G3_T,
                [
                    TerminalNonterminal.G3_T,
                    TerminalNonterminal.DIVIDE,
                    TerminalNonterminal.G3_N
                ]),

            new(18, Nonterminal.G3_T,
                [
                    TerminalNonterminal.G3_T,
                    TerminalNonterminal.MODULO,
                    TerminalNonterminal.G3_N
                ]),

            new(19, Nonterminal.G3_T,
                [
                    TerminalNonterminal.G3_N
                ]),

            new(20, Nonterminal.G3_N,
                [
                    TerminalNonterminal.PREFIX_INCREMENT,
                    TerminalNonterminal.G3_D,
                ]),

            new(21, Nonterminal.G3_N,
                [
                    TerminalNonterminal.PREFIX_DECREMENT,
                    TerminalNonterminal.G3_D,
                ]),

            new(22, Nonterminal.G3_N,
                [
                    TerminalNonterminal.NOT,
                    TerminalNonterminal.G3_N
                ]),

            new(23, Nonterminal.G3_N,
                [
                    TerminalNonterminal.G3_P
                ]),

            new(24, Nonterminal.G3_P,
                [
                    TerminalNonterminal.G3_D,
                    TerminalNonterminal.POSTFIX_INCREMENT
                ]),

            new(25, Nonterminal.G3_P,
                [
                    TerminalNonterminal.G3_D,
                    TerminalNonterminal.POSTFIX_DECREMENT
                ]),

            new(26, Nonterminal.G3_P,
                [
                    TerminalNonterminal.G3_I
                ]),

            new(27, Nonterminal.G3_I,
                [
                    TerminalNonterminal.CONST_INT
                ]),

            new(28, Nonterminal.G3_I,
                [
                    TerminalNonterminal.CONST_FLOAT
                ]),

            new(29, Nonterminal.G3_I,
                [
                    TerminalNonterminal.CONST_DOUBLE
                ]),

            new(30, Nonterminal.G3_I,
                [
                    TerminalNonterminal.CONST_CHAR
                ]),

            new(31, Nonterminal.G3_I,
                [
                    TerminalNonterminal.CONST_STRING
                ]),

            new(32, Nonterminal.G3_I,
                [
                    TerminalNonterminal.CONST_TRUE
                ]),

            new(33, Nonterminal.G3_I,
                [
                    TerminalNonterminal.CONST_FALSE
                ]),

            new(34, Nonterminal.G3_I,
                [
                    TerminalNonterminal.OPEN_BRACKET_ROUND,
                    TerminalNonterminal.G3_O,
                    TerminalNonterminal.CLOSE_BRACKET_ROUND
                ]),

            new(35, Nonterminal.G3_I,
                [
                    TerminalNonterminal.G3_D
                ]),

            new(36, Nonterminal.G3_D,
                [
                    TerminalNonterminal.ID
                ])
        ];

        /// <summary>
        /// First sets for all nonterminals of the G1 LL Body component.
        /// </summary>
        public static readonly Dictionary<Nonterminal, List<Terminal>> LLBodyFirstSet = new Dictionary<Nonterminal, List<Terminal>>()
        {
            {Nonterminal.G1_START, [
                Terminal.EOF, Terminal.DEFINE, Terminal.VOID, Terminal.INT, Terminal.FLOAT, Terminal.DOUBLE,
                Terminal.CHAR, Terminal.STRING, Terminal.BOOL]},

            {Nonterminal.G1_PROGRAM_MAIN, [
                Terminal.EOF, Terminal.DEFINE, Terminal.VOID, Terminal.INT, Terminal.FLOAT, Terminal.DOUBLE,
                Terminal.CHAR, Terminal.STRING, Terminal.BOOL]},

            {Nonterminal.G1_CONSTRUCT_BLOCK, [
                Terminal.OPEN_BRACKET_CURLY]},

            {Nonterminal.G1_CONSTRUCT_CONT, [
                Terminal.IF, Terminal.SWITCH, Terminal.WHILE, Terminal.DO, Terminal.FOR, Terminal.RETURN, Terminal.BREAK, Terminal.CONTINUE, Terminal.CASE, Terminal.DEFAULT, Terminal.SEMICOLON, Terminal.DEFINE,
                Terminal.OPEN_BRACKET_ROUND, Terminal.ID, Terminal.NOT, Terminal.PREFIX_INCREMENT, Terminal.PREFIX_DECREMENT, Terminal.CONST_INT, Terminal.CONST_FLOAT, Terminal.CONST_DOUBLE,
                Terminal.CONST_CHAR, Terminal.CONST_STRING, Terminal.CONST_TRUE, Terminal.CONST_FALSE ,Terminal.INT, Terminal.FLOAT, Terminal.DOUBLE, Terminal.CHAR,
                Terminal.STRING, Terminal.BOOL]},

            {Nonterminal.G1_CONSTRUCT, [
                Terminal.IF, Terminal.SWITCH, Terminal.WHILE, Terminal.DO, Terminal.FOR, Terminal.RETURN, Terminal.BREAK, Terminal.CONTINUE, Terminal.CASE, Terminal.DEFAULT, Terminal.SEMICOLON, Terminal.DEFINE,
                Terminal.OPEN_BRACKET_ROUND, Terminal.ID, Terminal.NOT, Terminal.PREFIX_INCREMENT, Terminal.PREFIX_DECREMENT, Terminal.CONST_INT, Terminal.CONST_FLOAT, Terminal.CONST_DOUBLE,
                Terminal.CONST_CHAR, Terminal.CONST_STRING, Terminal.CONST_TRUE, Terminal.CONST_FALSE ,Terminal.INT, Terminal.FLOAT, Terminal.DOUBLE, Terminal.CHAR,
                Terminal.STRING, Terminal.BOOL]},

            {Nonterminal.G1_ELEMENT, [
                Terminal.OPEN_BRACKET_ROUND, Terminal.ID, Terminal.NOT, Terminal.PREFIX_INCREMENT, Terminal.PREFIX_DECREMENT, Terminal.CONST_INT, Terminal.CONST_FLOAT, Terminal.CONST_DOUBLE,
                Terminal.CONST_CHAR, Terminal.CONST_STRING, Terminal.CONST_TRUE, Terminal.CONST_FALSE ,Terminal.INT, Terminal.FLOAT, Terminal.DOUBLE, Terminal.CHAR,
                Terminal.STRING, Terminal.BOOL]},

            {Nonterminal.G1_VAR_DEF, [
                Terminal.INT, Terminal.FLOAT, Terminal.DOUBLE, Terminal.CHAR, Terminal.STRING, Terminal.BOOL]},

            {Nonterminal.G1_ASSIGN, [Terminal.ASSIGN]},

            {Nonterminal.G1_VALUE, [
                Terminal.OPEN_BRACKET_ROUND, Terminal.ID, Terminal.NOT, Terminal.PREFIX_INCREMENT, Terminal.PREFIX_DECREMENT, Terminal.CONST_INT, Terminal.CONST_FLOAT, Terminal.CONST_DOUBLE,
                Terminal.CONST_CHAR, Terminal.CONST_STRING, Terminal.CONST_TRUE, Terminal.CONST_FALSE]},

            {Nonterminal.G1_DEFINE, [Terminal.DEFINE]},

            {Nonterminal.G1_IF_CONT, [Terminal.ELSE]},

            {Nonterminal.G1_ELSE_IF_CONT, [Terminal.IF, Terminal.CLOSE_BRACKET_CURLY]},

            {Nonterminal.G1_FUNC_DTYPE, [Terminal.VOID, Terminal.INT, Terminal.FLOAT, Terminal.DOUBLE, Terminal.CHAR, Terminal.STRING, Terminal.BOOL]},

            {Nonterminal.G1_PARAMETERS, [Terminal.INT, Terminal.FLOAT, Terminal.DOUBLE, Terminal.CHAR, Terminal.STRING, Terminal.BOOL]},

            {Nonterminal.G1_PARAMETERS_CONT, [Terminal.COMMA]},

            {Nonterminal.G1_DTYPE, [Terminal.INT, Terminal.FLOAT, Terminal.DOUBLE, Terminal.CHAR, Terminal.STRING, Terminal.BOOL]}
        };

        /// <summary>
        /// Follow sets for all nonterminals of the G1 LL Body component.
        /// </summary>
        public static readonly Dictionary<Nonterminal, List<Terminal>> LLBodyFollowSet = new Dictionary<Nonterminal, List<Terminal>>()
        {
            {Nonterminal.G1_START, []},

            {Nonterminal.G1_PROGRAM_MAIN, [Terminal.STRING_TERMINATOR]},

            {Nonterminal.G1_CONSTRUCT_BLOCK, [
                Terminal.EOF, Terminal.DEFINE, Terminal.VOID, Terminal.INT, Terminal.FLOAT, Terminal.DOUBLE, Terminal.CHAR, Terminal.STRING, Terminal.BOOL,
                Terminal.CLOSE_BRACKET_CURLY, Terminal.IF, Terminal.SWITCH, Terminal.WHILE, Terminal.DO, Terminal.FOR, Terminal.RETURN, Terminal.BREAK, Terminal.CONTINUE, 
                Terminal.CASE, Terminal.DEFAULT, Terminal.SEMICOLON, Terminal.OPEN_BRACKET_ROUND, Terminal.ID, Terminal.NOT, Terminal.PREFIX_INCREMENT, 
                Terminal.PREFIX_DECREMENT, Terminal.CONST_INT, Terminal.CONST_FLOAT, Terminal.CONST_DOUBLE, Terminal.CONST_CHAR, Terminal.CONST_STRING, 
                Terminal.CONST_TRUE, Terminal.CONST_FALSE, Terminal.ELSE]},

            {Nonterminal.G1_CONSTRUCT_CONT, [Terminal.CLOSE_BRACKET_CURLY]},

            {Nonterminal.G1_CONSTRUCT, [
                Terminal.CLOSE_BRACKET_CURLY, Terminal.IF, Terminal.SWITCH, Terminal.WHILE, Terminal.DO, Terminal.FOR, Terminal.RETURN, Terminal.BREAK, Terminal.CONTINUE,
                Terminal.CASE, Terminal.DEFAULT, Terminal.SEMICOLON, Terminal.DEFINE, Terminal.OPEN_BRACKET_ROUND, Terminal.ID, Terminal.NOT, Terminal.PREFIX_INCREMENT,
                Terminal.PREFIX_DECREMENT, Terminal.CONST_INT, Terminal.CONST_FLOAT, Terminal.CONST_DOUBLE, Terminal.CONST_CHAR, Terminal.CONST_STRING,
                Terminal.CONST_TRUE, Terminal.CONST_FALSE, Terminal.INT, Terminal.FLOAT, Terminal.DOUBLE, Terminal.CHAR, Terminal.STRING, Terminal.BOOL]},

            {Nonterminal.G1_ELEMENT, [Terminal.CLOSE_BRACKET_ROUND, Terminal.SEMICOLON]},

            {Nonterminal.G1_VAR_DEF, [Terminal.SEMICOLON, Terminal.CLOSE_BRACKET_ROUND, Terminal.COMMA]},

            {Nonterminal.G1_ASSIGN, [Terminal.SEMICOLON, Terminal.CLOSE_BRACKET_ROUND, Terminal.COMMA]},

            {Nonterminal.G1_VALUE, [Terminal.SEMICOLON, Terminal.CLOSE_BRACKET_ROUND]},

            {Nonterminal.G1_DEFINE, [Terminal.EOL]},

            {Nonterminal.G1_IF_CONT, [
                Terminal.CLOSE_BRACKET_CURLY, Terminal.IF, Terminal.SWITCH, Terminal.WHILE, Terminal.DO, Terminal.FOR, Terminal.RETURN, Terminal.BREAK, Terminal.CONTINUE,
                Terminal.CASE, Terminal.DEFAULT, Terminal.SEMICOLON, Terminal.DEFINE, Terminal.OPEN_BRACKET_ROUND, Terminal.ID, Terminal.NOT, Terminal.PREFIX_INCREMENT,
                Terminal.PREFIX_DECREMENT, Terminal.CONST_INT, Terminal.CONST_FLOAT, Terminal.CONST_DOUBLE, Terminal.CONST_CHAR, Terminal.CONST_STRING,
                Terminal.CONST_TRUE, Terminal.CONST_FALSE, Terminal.INT, Terminal.FLOAT, Terminal.DOUBLE, Terminal.CHAR, Terminal.STRING, Terminal.BOOL]},

            {Nonterminal.G1_ELSE_IF_CONT, [
                Terminal.CLOSE_BRACKET_CURLY, Terminal.IF, Terminal.SWITCH, Terminal.WHILE, Terminal.DO, Terminal.FOR, Terminal.RETURN, Terminal.BREAK, Terminal.CONTINUE,
                Terminal.CASE, Terminal.DEFAULT, Terminal.SEMICOLON, Terminal.DEFINE, Terminal.OPEN_BRACKET_ROUND, Terminal.ID, Terminal.NOT, Terminal.PREFIX_INCREMENT,
                Terminal.PREFIX_DECREMENT, Terminal.CONST_INT, Terminal.CONST_FLOAT, Terminal.CONST_DOUBLE, Terminal.CONST_CHAR, Terminal.CONST_STRING,
                Terminal.CONST_TRUE, Terminal.CONST_FALSE, Terminal.INT, Terminal.FLOAT, Terminal.DOUBLE, Terminal.CHAR, Terminal.STRING, Terminal.BOOL]},

            {Nonterminal.G1_FUNC_DTYPE, [Terminal.ID]},

            {Nonterminal.G1_PARAMETERS, [Terminal.CLOSE_BRACKET_ROUND]},

            {Nonterminal.G1_PARAMETERS_CONT, [Terminal.CLOSE_BRACKET_ROUND]},

            {Nonterminal.G1_DTYPE, [Terminal.ID]}
        };

        /// <summary>
        /// First sets for all nonterminals of the  G4 LL Function Call component.
        /// </summary>
        public static readonly Dictionary<Nonterminal, List<Terminal>> LLFunctionFirstSet = new Dictionary<Nonterminal, List<Terminal>>()
        {
            {Nonterminal.G4_START, [Terminal.ID]},

            {Nonterminal.G4_FUNCTION_CALL, [Terminal.ID]},

            {Nonterminal.G4_ARGS, [
                Terminal.OPEN_BRACKET_ROUND, Terminal.ID, Terminal.NOT, Terminal.PREFIX_INCREMENT, Terminal.PREFIX_DECREMENT, Terminal.CONST_INT, 
                Terminal.CONST_FLOAT, Terminal.CONST_DOUBLE, Terminal.CONST_CHAR, Terminal.CONST_STRING, Terminal.CONST_TRUE, Terminal.CONST_FALSE]},

            {Nonterminal.G4_ARGS_CONT, [Terminal.COMMA]},
        };

        /// <summary>
        /// Follow sets for all nonterminals of the  G4 LL Function Call component.
        /// </summary>
        public static readonly Dictionary<Nonterminal, List<Terminal>> LLFunctionFollowSet = new Dictionary<Nonterminal, List<Terminal>>()
        {
            {Nonterminal.G4_START, []},

            {Nonterminal.G4_FUNCTION_CALL, [Terminal.STRING_TERMINATOR]},

            {Nonterminal.G4_ARGS, [Terminal.CLOSE_BRACKET_ROUND]},

            {Nonterminal.G4_ARGS_CONT, [Terminal.CLOSE_BRACKET_ROUND]},
        };
    }
}
