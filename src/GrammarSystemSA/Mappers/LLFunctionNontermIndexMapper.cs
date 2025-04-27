///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Mappers\LLFunctionNontermIndexMapper.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Mappers
{
    /// <summary>
    /// Represents dictionary that is mapping Grammar G4 LL Function Call nonterminals to specific
    /// row indexes of LL parsing table.
    /// </summary>
    public class LLFunctionNontermIndexMapper
    {
        /// <summary>
        /// Mapping Grammar G4 LL Function Call nonterminals to specific
        /// row indexes of LL parsing table.
        /// </summary>
        public readonly static Dictionary<TerminalNonterminal, int> Map = new Dictionary<TerminalNonterminal, int>()
        {
            {TerminalNonterminal.G4_START, 0},
            {TerminalNonterminal.G4_FUNCTION_CALL, 1},
            {TerminalNonterminal.G4_ARGS, 2},
            {TerminalNonterminal.G4_ARGS_CONT, 3}
        };
    }
}
