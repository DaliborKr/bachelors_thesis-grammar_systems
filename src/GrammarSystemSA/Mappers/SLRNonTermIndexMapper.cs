///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Mappers\SLRNonTermIndexMapper.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Mappers
{
    /// <summary>
    /// Represents dictionary that is mapping Grammar G4 SLR terminals and nonterminals to specific
    /// column indexes of SLR parsing table.
    /// </summary>
    public class SLRNonTermIndexMapper
    {
        /// <summary>
        /// Mapping Grammar G4 SLR terminals and nonterminals to specific
        /// column indexes of SLR parsing table.
        /// </summary>
        public readonly static Dictionary<TerminalNonterminal, int> Map = new Dictionary<TerminalNonterminal, int>()
        {
            {TerminalNonterminal.OR, 0},
            {TerminalNonterminal.AND, 1},
            {TerminalNonterminal.EQUAL, 2},
            {TerminalNonterminal.NOT_EQUAL, 3},
            {TerminalNonterminal.GREATER, 4},
            {TerminalNonterminal.LESS, 5},
            {TerminalNonterminal.LESS_EQUAL, 6},
            {TerminalNonterminal.GREATER_EQUAL, 7},
            {TerminalNonterminal.PLUS, 8},
            {TerminalNonterminal.MINUS, 9},
            {TerminalNonterminal.MULTIPLY, 10},
            {TerminalNonterminal.DIVIDE, 11},
            {TerminalNonterminal.MODULO, 12},
            {TerminalNonterminal.PREFIX_INCREMENT, 13},
            {TerminalNonterminal.PREFIX_DECREMENT, 14},
            {TerminalNonterminal.NOT, 15},
            {TerminalNonterminal.POSTFIX_INCREMENT, 16},
            {TerminalNonterminal.POSTFIX_DECREMENT, 17},
            {TerminalNonterminal.CONST_INT, 18},
            {TerminalNonterminal.CONST_FLOAT, 19},
            {TerminalNonterminal.CONST_DOUBLE, 20},
            {TerminalNonterminal.CONST_CHAR, 21},
            {TerminalNonterminal.CONST_STRING, 22},
            {TerminalNonterminal.CONST_TRUE, 23},
            {TerminalNonterminal.CONST_FALSE, 24},
            {TerminalNonterminal.OPEN_BRACKET_ROUND, 25},
            {TerminalNonterminal.CLOSE_BRACKET_ROUND, 26},
            {TerminalNonterminal.ID, 27},
            {TerminalNonterminal.STRING_TERMINATOR, 28},

            {TerminalNonterminal.G3_S_START, 29},
            {TerminalNonterminal.G3_O, 30},
            {TerminalNonterminal.G3_A, 31},
            {TerminalNonterminal.G3_C1, 32},
            {TerminalNonterminal.G3_C2, 33},
            {TerminalNonterminal.G3_E, 34},
            {TerminalNonterminal.G3_T, 35},
            {TerminalNonterminal.G3_N, 36},
            {TerminalNonterminal.G3_P, 37},
            {TerminalNonterminal.G3_I, 38},
            {TerminalNonterminal.G3_D, 39}
        };
    }
}
