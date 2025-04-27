///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Mappers\LLBodyTermIndexMapper.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Mappers
{
    /// <summary>
    /// Represents dictionary that is mapping Grammar G1 LL Body terminals to specific
    /// column indexes of LL parsing table.
    /// </summary>
    public class LLBodyTermIndexMapper
    {
        /// <summary>
        /// Mapping Grammar G1 LL Body terminals to specific
        /// column indexes of LL parsing table.
        /// </summary>
        public readonly static Dictionary<Terminal, int> Map = new Dictionary<Terminal, int>()
        {
            {Terminal.STRING_TERMINATOR, 0},
            {Terminal.EOL, 1},
            {Terminal.SEMICOLON, 2},
            {Terminal.OPEN_BRACKET_ROUND, 3},
            {Terminal.CLOSE_BRACKET_ROUND, 4},
            {Terminal.OPEN_BRACKET_CURLY, 5},
            {Terminal.CLOSE_BRACKET_CURLY, 6},
            {Terminal.EOF, 7},
            {Terminal.IF, 8},
            {Terminal.SWITCH, 9},
            {Terminal.WHILE, 10},
            {Terminal.DO, 11},
            {Terminal.FOR, 12},
            {Terminal.RETURN, 13},
            {Terminal.BREAK, 14},
            {Terminal.CONTINUE, 15},
            {Terminal.CASE, 16},
            {Terminal.DEFAULT, 17},
            {Terminal.COLON, 18},
            {Terminal.ASSIGN, 19},
            {Terminal.DEFINE, 20},
            {Terminal.ELSE, 21},
            {Terminal.VOID, 22},
            {Terminal.COMMA, 23},
            {Terminal.INT, 24},
            {Terminal.FLOAT, 25},
            {Terminal.DOUBLE, 26},
            {Terminal.CHAR, 27},
            {Terminal.STRING, 28},
            {Terminal.BOOL, 29},
            {Terminal.ID, 30},
            {Terminal.NOT, 31},
            {Terminal.PREFIX_INCREMENT, 32},
            {Terminal.PREFIX_DECREMENT, 33},
            {Terminal.CONST_INT, 34},
            {Terminal.CONST_FLOAT, 35},
            {Terminal.CONST_DOUBLE, 36},
            {Terminal.CONST_CHAR, 37},
            {Terminal.CONST_STRING, 38},
            {Terminal.CONST_TRUE, 39},
            {Terminal.CONST_FALSE, 40}
        };
    }
}
