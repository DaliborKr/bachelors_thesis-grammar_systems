///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Lexical\Token.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Lexical
{
    /// <summary>
    /// Represents token information.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Represents specific terminal.
        /// </summary>
        public Terminal TerminalType { get; set; }

        /// <summary>
        /// Contains value of ids and literals.
        /// </summary>
        public string TerminalValue { get; set; }

        /// <summary>
        /// Position in input file, where the token has occured.
        /// </summary>
        public long? FilePosition { get; set; }

        /// <summary>
        /// Line number in input file where the token has occured.
        /// </summary>
        public int Line {  get; set; }

        /// <summary>
        /// Position in the line where the token has occurred.
        /// </summary>
        public int PositionOnLine { get; set; }

        // Constructor
        public Token(Terminal terminalType, string value, int line, int position)
        {
            this.TerminalType = terminalType;
            this.TerminalValue = value;
            this.Line = line;
            this.PositionOnLine = position;
            this.FilePosition = null;
        }
    }
}
