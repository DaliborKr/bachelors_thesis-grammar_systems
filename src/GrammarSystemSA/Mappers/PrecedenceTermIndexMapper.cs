///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Mappers\PrecedenceTermIndexMapper.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Mappers
{
    /// <summary>
    /// Represents dictionary that is mapping Grammar G2 Precedence terminals to specific
    /// indexes of Precedence parsing table.
    /// </summary>
    public class PrecedenceTermIndexMapper
    {
        /// <summary>
        /// Mapping Grammar G2 Precedence terminals to specific
        /// indexes of Precedence parsing table.
        /// </summary>
        public readonly static Dictionary<Terminal, int> Map = new Dictionary<Terminal, int>()
        {
            {Terminal.POSTFIX_INCREMENT, 0},
            {Terminal.POSTFIX_DECREMENT, 1},
            {Terminal.PREFIX_INCREMENT, 2},
            {Terminal.PREFIX_DECREMENT, 3},
            {Terminal.NOT, 4},
            {Terminal.PLUS, 5},
            {Terminal.MINUS, 6},
            {Terminal.MULTIPLY, 7},
            {Terminal.DIVIDE, 8},
            {Terminal.MODULO, 9},
            {Terminal.LESS, 10},
            {Terminal.GREATER, 11},
            {Terminal.LESS_EQUAL, 12},
            {Terminal.GREATER_EQUAL, 13},
            {Terminal.EQUAL, 14},
            {Terminal.NOT_EQUAL, 15},
            {Terminal.AND, 16},
            {Terminal.OR, 17},
            {Terminal.ASSIGN, 18},
            {Terminal.PLUS_ASSIGN, 19},
            {Terminal.MINUS_ASSIGN, 20},
            {Terminal.MULTIPLY_ASSIGN, 21},
            {Terminal.DIVIDE_ASSIGN, 22},
            {Terminal.MODULO_ASSIGN, 23},
            {Terminal.OPEN_BRACKET_ROUND, 24},
            {Terminal.CLOSE_BRACKET_ROUND, 25},
            {Terminal.CONST_INT, 26},
            {Terminal.CONST_FLOAT, 26},
            {Terminal.CONST_DOUBLE, 26},
            {Terminal.CONST_CHAR, 26},
            {Terminal.CONST_STRING, 26},
            {Terminal.CONST_TRUE, 26},
            {Terminal.CONST_FALSE, 26},
            {Terminal.ID, 27},
            {Terminal.STRING_TERMINATOR, 28}            
        };
    }
}
