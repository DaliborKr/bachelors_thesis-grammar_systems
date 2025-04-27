///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Grammars\GrammarRule.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Grammars
{
    /// <summary>
    /// Represents any contextfree grammar rule (its number, left side and right side). Provides method
    /// CompareRightSide.
    /// </summary>
    public class GrammarRule
    {
        public int RuleNumber { get; private set; }
        public Nonterminal LeftSide { get; private set; }
        public List<TerminalNonterminal> RightSide { get; private set; }

        public GrammarRule(int ruleNumber, Nonterminal leftSide, List<TerminalNonterminal> rightSide)
        {
            RuleNumber = ruleNumber;
            LeftSide = leftSide;
            RightSide = rightSide;
        }

        /// <summary>
        /// Compares rule right side with list of terminals and nonterminals given as an argument.
        /// </summary>
        /// <param name="otherRightSide">List of terminals and nonterminals to be compared.</param>
        /// <returns>Returns the left side of the rule if there is a match or returns null.</returns>
        public Nonterminal? CompareRightSide(List<TerminalNonterminal> otherRightSide)
        {
            if (RightSide.Count != otherRightSide.Count)
            {
                return null;
            }

            for (int i = 0; i < RightSide.Count; i++)
            {
                if (RightSide[i] != otherRightSide[i])
                {
                    return null;
                }
            }

            return LeftSide;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object in form of 'p: A -> x1 x2 ... xn'</returns>
        public override string ToString()
        {
            string rightSideString = "";
            foreach (TerminalNonterminal symbol in RightSide)
            {
                if ((int)symbol <= Constants.MaxTerminalEnumValue)
                {
                    rightSideString += symbol.ToString().ToLower() + " ";
                }
                else
                {
                    rightSideString += symbol.ToString() + " ";
                }
            }

            if (RightSide.Count == 0)
            {
                rightSideString = "epsilon";
            }

            return string.Format("{0,-3} {1,20:t} -> ", RuleNumber.ToString() + ":", LeftSide.ToString()) + rightSideString;
        }
    }
}
