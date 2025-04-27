///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Tables\SLRTableCell.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Tables
{
    /// <summary>
    /// Represents a cell in SLR parsing table (its action and production or state number).
    /// </summary>
    public class SLRTableCell
    {
        public ParsingTableAction Action { get; private set; }
        public int ProductionStateNumber { get; private set; }

        public SLRTableCell(ParsingTableAction action, int productionStateNumber)
        {
            Action = action;
            ProductionStateNumber = productionStateNumber;
        }

        /// <summary>
        /// Returns a string that represents a SLR parsing table cell.
        /// </summary>
        /// <returns>A string that represents a SLR parsing table cell.</returns>
        public override string ToString()
        {
            string actionShortcut = "";
            switch (this.Action)
            {
                case ParsingTableAction.SHIFT:
                    actionShortcut = "S";
                    break;
                case ParsingTableAction.REDUCE:
                    actionShortcut = "R";
                    break;
                case ParsingTableAction.ERROR:
                    actionShortcut = "ERR";
                    break;
                case ParsingTableAction.GOTO:
                    actionShortcut = "GO";
                    break;
                case ParsingTableAction.OK:
                    actionShortcut = "OK";
                    break;
            }

            return actionShortcut + ": " + this.ProductionStateNumber;
        }
    }
}
