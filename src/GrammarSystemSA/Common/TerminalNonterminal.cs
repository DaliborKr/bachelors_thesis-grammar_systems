///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Common\TerminalNonterminal.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


namespace GrammarSystemSA.Common
{
    /// <summary>
    /// Set of all possible parsing terminals and nonterminals.
    /// </summary>
    public enum TerminalNonterminal
    {
        // TERMINALS
        // For lexical analysis purposes
        UNDEFINED_TERMINAL = -2,
        ERROR_TOKEN = -1,

        // Mainly body of the program
        DEFINE = 1,
        EOL = 2,
        SEMICOLON = 3,
        ID = 4,
        OPEN_BRACKET_ROUND = 5,
        CLOSE_BRACKET_ROUND = 6,
        OPEN_BRACKET_CURLY = 7,
        CLOSE_BRACKET_CURLY = 8,
        EOF = 9,
        IF = 10,
        SWITCH = 11,
        WHILE = 12,
        DO = 13,
        FOR = 14,
        RETURN = 15,
        ELSE = 16,
        BREAK = 17,
        CASE = 18,
        COLON = 19,
        DEFAULT = 20,
        CONTINUE = 21,
        COMMA = 22,
        VOID = 23,
        INT = 24,
        FLOAT = 25,
        DOUBLE = 26,
        CHAR = 27,
        STRING = 28,
        BOOL = 29,

        // Expressions
        ASSIGN = 32,
        PLUS_ASSIGN = 33,
        MINUS_ASSIGN = 34,
        MULTIPLY_ASSIGN = 35,
        DIVIDE_ASSIGN = 36,
        MODULO_ASSIGN = 37,
        OR = 38,
        AND = 39,
        EQUAL = 40,
        NOT_EQUAL = 41,
        GREATER = 42,
        LESS = 43,
        GREATER_EQUAL = 44,
        LESS_EQUAL = 45,
        PLUS = 46,
        MINUS = 47,
        MULTIPLY = 48,
        DIVIDE = 49,
        MODULO = 50,
        PREFIX_INCREMENT = 51,
        PREFIX_DECREMENT = 52,
        POSTFIX_INCREMENT = 53,
        POSTFIX_DECREMENT = 54,
        NOT = 55,

        // Constants
        CONST_INT = 56,
        CONST_FLOAT = 57,
        CONST_DOUBLE = 58,
        CONST_CHAR = 59,
        CONST_STRING = 60,
        CONST_TRUE = 61,
        CONST_FALSE = 62,

        // String terminator
        STRING_TERMINATOR = 63,

        // Epsilon
        EPSILON = 64,


        // NONTERMINALS
        // LL body grammar
        G1_START = 99,
        G1_PROGRAM_MAIN = 100,
        G1_CONSTRUCT_BLOCK = 101,
        G1_CONSTRUCT_CONT = 102,
        G1_CONSTRUCT = 103,
        G1_ELEMENT = 104,
        G1_VAR_DEF = 105,
        G1_ASSIGN = 106,
        G1_VALUE = 107,
        G1_IF_CONT = 108,
        G1_ELSE_IF_CONT = 109,
        G1_FUNC_DTYPE = 110,
        G1_PARAMETERS = 111,
        G1_PARAMETERS_CONT = 112,
        G1_DTYPE = 113,
        G1_DEFINE = 117,

        // Precedence expression grammar
        G2_AS = 118,
        G2_EXP = 119,

        // SLR expression grammar
        G3_S_START = 120,
        G3_O = 121,
        G3_A = 122,
        G3_C1 = 123,
        G3_C2 = 124,
        G3_E = 125,
        G3_T = 126,
        G3_N = 127,
        G3_P = 128,
        G3_I = 129,
        G3_D = 130,

        // LL function call grammar
        G4_START = 131,
        G4_FUNCTION_CALL = 132,
        G4_ARGS = 133,
        G4_ARGS_CONT = 134
    }
}
