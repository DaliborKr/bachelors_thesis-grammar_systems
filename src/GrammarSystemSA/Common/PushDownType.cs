///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Common\PushDownType.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


namespace GrammarSystemSA.Common
{
    /// <summary>
    /// Set of all possible item types of parsing pushdown.
    /// </summary>
    public enum PushDownType
    {
        TERMINAL = 0,
        NONTERMINAL = 1
    }
}
