///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Tables\LLParsingTable.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Tables
{
    /// <summary>
    /// Represents LL parsing table. Has exactly 2 instances (for G1 LL Body and G4 LL Function Call). 
    /// Provides method GetCell.
    /// </summary>
    public class LLParsingTable : ParsingTable<int>
    {
        // First table instance for Grammar G1 LL Body
        private static readonly LLParsingTable _instanceBody = new LLParsingTable(Constants.LLBodyTableCSVPath, Constants.LLBodyTableRows, Constants.LLBodyTableColumns);
        public static LLParsingTable InstanceBody 
        {  
            get { return _instanceBody; } 
        }

        // Second table instance for Grammar G4 LL Function Call
        private static readonly LLParsingTable _instanceFunctionCall = new LLParsingTable(Constants.LLFuncCallTableCSVPath, Constants.LLFuncCallTableRows, Constants.LLFuncCallColumns);
        public static LLParsingTable InstanceFunctionCall
        {
            get { return _instanceFunctionCall; }
        }

        /// <summary>
        /// Parsing table represented by a two-dimensional array.
        /// </summary>
        public override int[,] Table { get; protected set; }

        // Private constructor (cannot be instantiated from outside - exactly 2 instances)
        private LLParsingTable(string path, int rows, int columns)
        {
            Table = new int[rows, columns];
            FillTableFromCSV(path, rows, columns);
        }

        /// <summary>
        /// Transfers a value read from the CSV file into an integer (type of the table cell).
        /// </summary>
        /// <param name="row">Numeric row index of the parsing table.</param>
        /// <param name="column">Numeric column index of the parsing table.</param>
        /// <param name="csvValue">Value read from CSV file to be parsed.</param>
        protected override void ParseCell(int row, int column, string csvValue)
        {
            if (csvValue.Equals(""))
            {
                this.Table[row, column] = -1;
            }
            else
            {
                this.Table[row, column] = int.Parse(csvValue);
            }
        }
    }
}
