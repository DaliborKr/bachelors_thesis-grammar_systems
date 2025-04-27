///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Mappers\LLFunctionTermIndexMapper.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Mappers
{
    /// <summary>
    /// Represents dictionary that is mapping Grammar G4 LL Function Call terminals to specific
    /// column indexes of LL parsing table.
    /// </summary>
    public class LLFunctionTermIndexMapper
    {
        /// <summary>
        /// Mapping Grammar G4 LL Function Call terminals to specific
        /// column indexes of LL parsing table.
        /// </summary>
        public readonly static Dictionary<Terminal, int> Map = new Dictionary<Terminal, int>()
        {
            {Terminal.STRING_TERMINATOR, 0},
            {Terminal.ID, 1},
            {Terminal.OPEN_BRACKET_ROUND, 2},
            {Terminal.CLOSE_BRACKET_ROUND, 3},
            {Terminal.COMMA, 4},
            {Terminal.NOT, 5},
            {Terminal.PREFIX_INCREMENT, 6},
            {Terminal.PREFIX_DECREMENT, 7},
            {Terminal.CONST_INT, 8},
            {Terminal.CONST_FLOAT, 9},
            {Terminal.CONST_DOUBLE, 10},
            {Terminal.CONST_CHAR, 11},
            {Terminal.CONST_STRING, 12},
            {Terminal.CONST_TRUE, 13},
            {Terminal.CONST_FALSE, 14}
        };
    }
}
