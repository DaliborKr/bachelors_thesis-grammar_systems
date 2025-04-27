///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Common\ParsingTableAction.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


namespace GrammarSystemSA.Common
{
    /// <summary>
    /// Set of all possible actions that can appear in a precedence or SLR table.
    /// </summary>
    public enum ParsingTableAction
    {
        SHIFT = 0,
        REDUCE = 1,
        EQUAL = 2,
        OK = 3,
        GOTO = 4,
        ERROR = 5
    }
}
