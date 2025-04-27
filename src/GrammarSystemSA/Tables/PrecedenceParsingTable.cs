///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Tables\PrecedenceParsingTable.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Tables
{
    /// <summary>
    /// Represents Precedence parsing table. As a singleton it has exactly one instance (for G2 Precedence Expressions). 
    /// Provides method GetCell.
    /// </summary>
    public class PrecedenceParsingTable : ParsingTable<ParsingTableAction>
    {
        // Singleton instance for Grammar G2 Precedence Expressions
        private static readonly PrecedenceParsingTable _instance = new PrecedenceParsingTable();
        public static PrecedenceParsingTable Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Parsing table represented by a two-dimensional array.
        /// </summary>
        public override ParsingTableAction[,] Table { get; protected set; } = new ParsingTableAction[Constants.PrecedenceTableRows, Constants.PrecedenceTableColumns];

        // Singleton constructor (cannot be instantiated from outside)
        private PrecedenceParsingTable()
        {
            FillTableFromCSV(Constants.PrecedenceTableCSVPath, Constants.PrecedenceTableRows, Constants.PrecedenceTableColumns);
        }

        /// <summary>
        /// Transfers a value read from the CSV file into an parsing table action (type of the table cell).
        /// </summary>
        /// <param name="row">Numeric row index of the parsing table.</param>
        /// <param name="column">Numeric column index of the parsing table.</param>
        /// <param name="csvValue">Value read from CSV file to be parsed.</param>
        protected override void ParseCell(int row, int column, string csvValue)
        {
            switch (csvValue)
            {
                case "<":
                    this.Table[row, column] = ParsingTableAction.SHIFT;
                    break;
                case ">":
                    this.Table[row, column] = ParsingTableAction.REDUCE;
                    break;
                case "=":
                    this.Table[row, column] = ParsingTableAction.EQUAL;
                    break;
                case "OK":
                    this.Table[row, column] = ParsingTableAction.OK;
                    break;
                case "":
                    this.Table[row, column] = ParsingTableAction.ERROR;
                    break;
            }
        }
    }
}
