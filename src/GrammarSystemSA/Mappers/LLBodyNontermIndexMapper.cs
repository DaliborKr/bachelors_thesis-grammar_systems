///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Mappers\LLBodyNontermIndexMapper.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Mappers
{
    /// <summary>
    /// Represents dictionary that is mapping Grammar G1 LL Body nonterminals to specific
    /// row indexes of LL parsing table.
    /// </summary>
    public class LLBodyNontermIndexMapper
    {
        /// <summary>
        /// Mapping Grammar G1 LL Body nonterminals to specific
        /// row indexes of LL parsing table.
        /// </summary>
        public readonly static Dictionary<TerminalNonterminal, int> Map = new Dictionary<TerminalNonterminal, int>()
        {
            {TerminalNonterminal.G1_START, 0},
            {TerminalNonterminal.G1_PROGRAM_MAIN, 1},
            {TerminalNonterminal.G1_CONSTRUCT_BLOCK, 2},
            {TerminalNonterminal.G1_CONSTRUCT_CONT, 3},
            {TerminalNonterminal.G1_CONSTRUCT, 4},
            {TerminalNonterminal.G1_ELEMENT, 5},
            {TerminalNonterminal.G1_VAR_DEF, 6},
            {TerminalNonterminal.G1_ASSIGN, 7},
            {TerminalNonterminal.G1_VALUE, 8},
            {TerminalNonterminal.G1_DEFINE, 9},
            {TerminalNonterminal.G1_IF_CONT, 10},
            {TerminalNonterminal.G1_ELSE_IF_CONT, 11},
            {TerminalNonterminal.G1_FUNC_DTYPE, 12},
            {TerminalNonterminal.G1_PARAMETERS, 13},
            {TerminalNonterminal.G1_PARAMETERS_CONT, 14},
            {TerminalNonterminal.G1_DTYPE, 15}
        };
    }
}
