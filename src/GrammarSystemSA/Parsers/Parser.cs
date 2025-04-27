///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Parsers\Parser.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;
using GrammarSystemSA.Lexical;
using GrammarSystemSA.Components;

namespace GrammarSystemSA.Parsers
{
    /// <summary>
    /// Represents a parser that does syntax analysis of the input C++ program. Provides method Parse.
    /// </summary>
    public abstract class Parser
    {
        /// <summary>
        /// Represents pushdown of the pushdown automaton.
        /// </summary>
        protected List<TerminalNonterminal> _pushdown;

        /// <summary>
        /// Represetns token that is currently on the input.
        /// </summary>
        protected Token _actualToken;

        /// <summary>
        /// Represents a scanner that provides tokens from an input file.
        /// </summary>
        protected Scanner _scanner;

        /// <summary>
        /// Determines if logging messages are going to be written into the console or not.
        /// </summary>
        protected bool _logEnabled;

        /// <summary>
        /// Determines if the parsser is curruntlz recovering from an error or not
        /// </summary>
        protected bool _isInRecoveryMode;

        // Constructor
        public Parser(Scanner scanner, bool logEnabled)
        {
            this._pushdown = new List<TerminalNonterminal>();
            this._actualToken = new Token(Terminal.UNDEFINED_TERMINAL, "", -1, -1);
            this._scanner = scanner;
            this._logEnabled = logEnabled;
            this._isInRecoveryMode = false;
        }

        /// <summary>
        /// Does a syntax analysis of the input program with a given component.
        /// </summary>
        public abstract void Parse();

        /// <summary>
        /// Creates an syntax error record.
        /// </summary>
        /// <param name="message">Parsing error message.</param>
        /// <param name="componentName">Name of component that caused the syntax error.</param>
        protected void SyntaxErrorWriteOut(string message, string componentName)
        {
            string completeMessage = componentName + " - SYNTAX ERROR: " + message
                + "\n\tError detected on line '"+ this._scanner.GetLastToken().Line + "' and position '" + this._scanner.GetLastToken().PositionOnLine + "'.";
            
            ParsingStats.Stats.SyntaxErrorRecord(completeMessage);
            Log(completeMessage, true);
        }

        /// <summary>
        /// Creates an lexical error record.
        /// </summary>
        /// <param name="message">Lexical error message.</param>
        protected void LexicalErrorWriteOut(string message)
        {
            string completeMessage = "LEXICAL ERROR: " + message
                + "\n\tError detected on line '" + this._scanner.GetLastToken().Line + "' and position '" + this._scanner.GetLastToken().PositionOnLine + "'.";
            
            ParsingStats.Stats.LexicalErrorRecord(completeMessage);
            Log(completeMessage, true);
        }

        /// <summary>
        /// Logs a message into the console.
        /// </summary>
        /// <param name="logMessage">Log message.</param>
        /// <param name="isErrorLog">Determines if logging error or not.</param>
        protected void Log(string logMessage, bool isErrorLog)
        {
            if (this._logEnabled) 
            {
                if (isErrorLog)
                {
                    Console.WriteLine("\nxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx\n\n" +
                                       logMessage +
                                      "\n\nxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx\n");
                }
                else
                {
                    Console.WriteLine(logMessage);
                }
            }
        }


        /// <summary>
        /// Logs a transition between two components.
        /// </summary>
        /// <param name="component1">Component, that will be logged on first position.</param>
        /// <param name="component2">Component, that will be logged on second position.</param>
        /// <param name="switchBack">Determines a way of transition (if true g1 <- g2, else g1 -> g2 )</param>
        protected void LogComponentSwitch(Component component1, Component component2, bool switchBack)
        {
            if (this._logEnabled)
            {
                string activeGrammar;
                string transitionMark;
                if (switchBack)
                {
                    transitionMark = "<--";
                    activeGrammar = component1.ExtendedName;
                }
                else
                {
                    transitionMark = "-->";
                    activeGrammar= component2.ExtendedName;
                }

                Log("\n--------------------    " +
                    component1.Name +
                    "   " +
                    transitionMark +
                    "   " +
                    component2.Name +
                    "    --------------------" + "\n\nActive component: " + activeGrammar, false);
            }
        }
    }
}
