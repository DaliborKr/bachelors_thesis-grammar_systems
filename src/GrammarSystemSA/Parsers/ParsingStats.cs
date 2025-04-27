///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Parsers\ParsingStats.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


namespace GrammarSystemSA.Parsers
{
    /// <summary>
    /// Represents informations about parsing proccess. It maintains number of lexical and syntax errors and all
    /// error messages. It provides methods for making records of lexical or syntax errors.
    /// </summary>
    public class ParsingStats
    {
        // Singleton instance of a parsing statistic
        private static readonly ParsingStats _stats = new ParsingStats();
        public static ParsingStats Stats
        {
            get { return _stats; }
        }

        public bool ParsingSuccess {  get; set; }
        public int SyntaxErrorNumber { get; set; }
        public int LexicalErrorNumber { get; set; }

        public List<string> ErrorMessages { get; set; }

        private ParsingStats() 
        {
            this.ErrorMessages = new List<string>();
            StatsToInitState();
        }

        /// <summary>
        /// Brings the singleton instance to the initial state.
        /// </summary>
        public void StatsToInitState()
        {
            this.ParsingSuccess = true;
            this.SyntaxErrorNumber = 0;
            this.LexicalErrorNumber = 0;
            this.ErrorMessages = new List<string>();
        }

        /// <summary>
        /// Makes a record of the syntax error.
        /// </summary>
        /// <param name="message">Error message of the recorded error.</param>
        public void SyntaxErrorRecord(string message) 
        {
            this.ParsingSuccess = false;
            this.SyntaxErrorNumber++;
            this.ErrorMessages.Add(message);
        }

        /// <summary>
        /// Makes a record of the lexical error.
        /// </summary>
        /// <param name="message">Error message of the recorded error.</param>
        public void LexicalErrorRecord(string message)
        {
            this.ParsingSuccess = false;
            this.LexicalErrorNumber++;
            this.ErrorMessages.Add(message);
        }
    }
}
