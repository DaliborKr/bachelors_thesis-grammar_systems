///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Parsers\SLRPushdownItem.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Parsers
{
    /// <summary>
    /// Represents item that appears on the pushdown of a SLR parser. This item is a pair of symbol and state number.
    /// </summary>
    public struct SLRPushdownItem
    {
        public TerminalNonterminal Symbol {  get; }

        public int State { get; }

        // Constructor
        public SLRPushdownItem(TerminalNonterminal symbol, int state)
        {
            this.Symbol = symbol;
            this.State = state;
        }

        public override readonly string ToString()
        {
            return "<" + this.Symbol.ToString() + ", " + this.State + ">";
        }
    }
}
