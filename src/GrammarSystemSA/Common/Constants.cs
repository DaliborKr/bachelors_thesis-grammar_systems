///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Common\Constants.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


namespace GrammarSystemSA.Common
{
    /// <summary>
    /// Definitions of constants used across the whole project.
    /// </summary>
    public class Constants
    {
        // Scanner constants
        public const char Eof = '\uffff';
        public const string Define = "define ";
        public const string Include = "include ";

        // Parser constants
        public const int MaxTerminalEnumValue = 64;

        // Parsing table constants
        public const int LLBodyTableRows = 16;
        public const int LLBodyTableColumns = 41;
        public const string LLBodyTableCSVPath = "TablesData/LLTable.csv";
        public const int LLTableLookaheadValue = -100;

        public const int LLFuncCallTableRows = 4;
        public const int LLFuncCallColumns = 15;
        public const string LLFuncCallTableCSVPath = "TablesData/LLFuncTable.csv";

        public const int SLRTableRows = 56;
        public const int SLRTableColumns = 40;
        public const string SLRTableCSVPath = "TablesData/SLRTable.csv";

        public const int PrecedenceTableRows = 29;
        public const int PrecedenceTableColumns = 29;
        public const string PrecedenceTableCSVPath = "TablesData/PrecTable.csv";
    }
}
