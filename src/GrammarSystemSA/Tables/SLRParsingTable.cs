///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Tables\SLRParsingTable.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Tables
{
    /// <summary>
    /// Represents SLR parsing table. As a singleton it has exactly one instance (for G3 SLR Expressions). 
    /// Provides method GetCell.
    /// </summary>
    public class SLRParsingTable : ParsingTable<SLRTableCell>
    {
        // Singleton instatnce for Grammar G3 SLR Expressions
        private static readonly SLRParsingTable _instance = new SLRParsingTable();
        public static SLRParsingTable Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Parsing table represented by a two-dimensional array.
        /// </summary>
        public override SLRTableCell[,] Table { get; protected set; } = new SLRTableCell[Constants.SLRTableRows, Constants.SLRTableColumns];


        // Singleton constructor (cannot be instantiated from outside)
        private SLRParsingTable()
        {
            FillTableFromCSV(Constants.SLRTableCSVPath, Constants.SLRTableRows, Constants.SLRTableColumns);
        }

        /// <summary>
        /// Transfers a value read from the CSV file into an SLR table cell (type of the table cell).
        /// </summary>
        /// <param name="row">Numeric row index of the parsing table.</param>
        /// <param name="column">Numeric column index of the parsing table.</param>
        /// <param name="csvValue">Value read from CSV file to be parsed.</param>
        protected override void ParseCell(int row, int column, string csvValue)
        {
            switch (csvValue)
            {
                case "":
                    this.Table[row, column] = new SLRTableCell(ParsingTableAction.ERROR, -1);
                    return;
                case "OK":
                    this.Table[row, column] = new SLRTableCell(ParsingTableAction.OK, -1);
                    return;
            }

            switch (csvValue[0])
            {
                case 's':
                    this.Table[row, column] = new SLRTableCell(ParsingTableAction.SHIFT, int.Parse(csvValue[1..]));
                    break;
                case 'r':
                    this.Table[row, column] = new SLRTableCell(ParsingTableAction.REDUCE, int.Parse(csvValue[1..]));
                    break;
                case 'g':
                    this.Table[row, column] = new SLRTableCell(ParsingTableAction.GOTO, int.Parse(csvValue[1..]));
                    break;
            }
        }
    }
}
