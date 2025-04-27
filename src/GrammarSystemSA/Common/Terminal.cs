///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Common\Terminal.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


namespace GrammarSystemSA.Common
{
    /// <summary>
    /// Set of all possible parsing terminals.
    /// </summary>
    public enum Terminal
    {
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
        EPSILON = 64
    }
}
