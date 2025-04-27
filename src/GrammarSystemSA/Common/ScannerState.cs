///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Common\ScannerState.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


namespace GrammarSystemSA.Common
{
    /// <summary>
    /// Set of all possible scanner automaton states.
    /// </summary>
    public enum ScannerState
    {
        START = 0,

        ID_KEYWORD = 1,

        LINE_COMMENT = 2,
        BLOCK_COMMENT_START = 3,
        BLOCK_COMMENT_END = 4,

        HASHTAG = 5,

        ASSIGN = 6,
        PLUS = 7,
        MINUS = 8,
        MULTIPLY = 9,
        DIVIDE = 10,
        MODULO = 11,
        NOT = 12,
        LESS = 13,
        GREATER = 14,
        AND_1 = 15,
        OR_1 = 16,

        INTEGER_1 = 17,
        INTEGER_2 = 18,
        INTEGER_HEXA_START = 19,
        INTEGER_HEXA = 20,

        DOUBLE_0 = 21,
        DOUBLE_1 = 22,
        DOUBLE_2 = 23,
        EXPONENT = 24,
        EXPONENT_SIGN = 25,

        CHAR_START = 26,
        CHAR_VALUE = 27,
        CHAR_ESCAPE = 28,

        STRING_VALUE = 29,
        STRING_ESCAPE = 30
    }
}
