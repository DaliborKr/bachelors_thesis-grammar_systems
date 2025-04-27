///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Tables\ParsingTable.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using Microsoft.VisualBasic.FileIO;

namespace GrammarSystemSA.Tables
{
    /// <summary>
    /// Represents a parsing table. Provides method GetCell.
    /// </summary>
    /// <typeparam name="T">Data type of the table cells.</typeparam>
    public abstract class ParsingTable<T>
    {
        /// <summary>
        /// Parsing table represented by a two-dimensional array.
        /// </summary>
        abstract public T[,] Table { get; protected set; }

        /// <summary>
        /// Provides access to the specific cell of the parsing table.
        /// </summary>
        /// <param name="row">Numeric row index of the parsing table.</param>
        /// <param name="column">Numeric column index of the parsing table.</param>
        /// <returns>Returns cell of the table.</returns>
        public T GetCell(int row, int column)
        {
            return Table[row, column];
        }

        /// <summary>
        /// Fills the parsing table with data from a given CSV file.
        /// </summary>
        /// <param name="path">Path to the CSV file to be parsed.</param>
        /// <param name="rows">Number of parsing table rows.</param>
        /// <param name="columns">Number of parsing table columns.</param>
        protected void FillTableFromCSV(string path, int rows, int columns)
        {
            try
            {
                using TextFieldParser parser = new TextFieldParser(path);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                for (int i = 0; i < rows; i++)
                {
                    string[]? fields = parser.ReadFields();

                    if (fields is not null)
                    {
                        for (int j = 0; j < columns; j++)
                        {
                            ParseCell(i, j, fields[j]);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("CSV file '" + path + "' not found.'\n\n" +
                    "The entire folder 'TablesData/' with the parsing table data of all components seems to be missing. Please check it out and insert the folder 'TablesData/' if necessary.");
                
                Environment.Exit(1);
                
                //throw new FileNotFoundException("CSV file '" + path + "' not found.");
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred: " + e.Message);
            }
        }

        /// <summary>
        /// Transfers a value read from the CSV file into the wanted type (type of the table cell).
        /// </summary>
        /// <param name="row">Numeric row index of the parsing table.</param>
        /// <param name="column">Numeric column index of the parsing table.</param>
        /// <param name="csvValue">Value read from CSV file to be parsed.</param>
        protected abstract void ParseCell(int row, int column, string csvValue);
    }
}
