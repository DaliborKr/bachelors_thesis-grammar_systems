///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Parsers\PrecedenceParser.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;
using GrammarSystemSA.Components;
using GrammarSystemSA.Grammars;
using GrammarSystemSA.Lexical;

namespace GrammarSystemSA.Parsers
{
    /// <summary>
    /// Represents a Precedence parser that does syntax analysis based on precedence components.
    /// </summary>
    public class PrecedenceParser : BottomUpParser
    {
        /// <summary>
        /// Precedence component assigned to the parser instance (provides grammar, parsing table, mappers, ...).
        /// </summary>
        private readonly PrecedenceComponent _component;

        /// <summary>
        /// Represents a list that contains indexes of terminals on the pushdown (except the top one).
        /// </summary>
        private List<int> _pushdownTerminalIndexes;

        /// <summary>
        /// Represents the topmost pushdown terminal.
        /// </summary>
        private int _pushdownTopTerminalIndex;

        // Constructor
        public PrecedenceParser(Scanner scanner, bool logEnabled, PrecedenceComponent component) : base(scanner, logEnabled)
        {
            this._component = component;
            this._pushdownTerminalIndexes = new List<int>();
        }

        public override void Parse()
        {
            // Initialization
            this._pushdown.Add(TerminalNonterminal.STRING_TERMINATOR);
            this._pushdownTopTerminalIndex = 0;

            this._actualToken = this._scanner.GetLastToken();

            CheckActualToken(this._component);

            // Parsing
            while (true)
            {
                if (this._isInRecoveryMode)
                {
                    return;
                }

                if (this._component.TermIndexMap.TryGetValue((Terminal)this._pushdown[this._pushdownTopTerminalIndex], out int rowIndex) &&
                    this._component.TermIndexMap.TryGetValue(this._actualToken.TerminalType, out int columnIndex))
                {
                    // Access to the parsing table
                    switch (this._component.Table.GetCell(rowIndex, columnIndex))
                    {
                        case ParsingTableAction.EQUAL:
                            PushAndReadNext();
                            break;
                        case ParsingTableAction.SHIFT:
                            // Add current topmost terminal to the termnal list before it is replaced
                            this._pushdownTerminalIndexes.Add(this._pushdownTopTerminalIndex);

                            PushAndReadNext();
                            break;
                        case ParsingTableAction.REDUCE:
                            ReducePushdownTop();
                            break;
                        case ParsingTableAction.OK:
                            if (CheckPushdownFinalState())
                            {
                                // Success
                                return;
                            }
                            else
                            {
                                ErrorAndRecovery("Forbidden symbols on pushdown at final state. Expected '" + TerminalNonterminal.G2_AS +
                                    "' got " + PushdownToString(1));
                            }
                            break;
                        case ParsingTableAction.ERROR:
                            ErrorAndRecovery("Parsing table error [" + 
                                this._pushdown[this._pushdownTopTerminalIndex].ToString() + 
                                ", " + 
                                this._actualToken.TerminalType.ToString() + 
                                "]");
                            break;
                    }
                }
                else
                {
                    // Not allowed terminal in the precedence parser detected (it will be handled in LL parser later)
                    this._actualToken = new Token(Terminal.STRING_TERMINATOR, "", -1, -1);
                }
            }
        }

        protected override void PushAndReadNext()
        {
            this._pushdown.Add((TerminalNonterminal)this._actualToken.TerminalType);

            // Change of the topmost terminal on the pushdown
            this._pushdownTopTerminalIndex = this._pushdown.Count - 1;
            
            this._actualToken = this._scanner.GetNextToken();
            CheckActualToken(this._component);
        }

        protected override void ReducePushdownTop()
        {
            if (this._pushdownTerminalIndexes.Count <= 0)
            {
                ErrorAndRecovery("Reduction - No symbols to reduce");
            }

            // Pop a terminal index and replace current topmost terminal as it is going to be reduced
            this._pushdownTopTerminalIndex = this._pushdownTerminalIndexes.Last();
            this._pushdownTerminalIndexes.RemoveAt(this._pushdownTerminalIndexes.Count - 1);

            int headIndex = this._pushdownTopTerminalIndex + 1;
            List<TerminalNonterminal> pushdownTail = GetAndRemoveHeadAt(headIndex);

            // Find a suitable grammar rule for the reduction
            foreach (GrammarRule rule in this._component.Grammar)
            {
                Nonterminal? reducedTo = rule.CompareRightSide(pushdownTail);

                if (reducedTo != null)
                {
                    Log("  " + rule.ToString(), false);

                    this._pushdown.Add((TerminalNonterminal)reducedTo);
                    return;
                }
            }

            // Error - No suitable grammar rule was found
            string errorMessage = "Reduction - No matching rule for sequence:  ";
            foreach (TerminalNonterminal item in pushdownTail)
            {
                errorMessage += item.ToString() + "  ";
            }
            ErrorAndRecovery(errorMessage);
        }

        protected override List<TerminalNonterminal> GetAndRemoveHeadAt(int index) 
        {
            int tailLength = this._pushdown.Count - index;
            List <TerminalNonterminal> pushdownTail = this._pushdown.GetRange(index, tailLength);
            this._pushdown.RemoveRange(index, tailLength);

            return pushdownTail;
        }

        /// <summary>
        /// Checks that in the final state of precedence parsing exactly 1 nonterminal
        /// and string termination symbol is left on the pushdown.
        /// </summary>
        /// <returns>Returns true if the final state is OK or returns false.</returns>
        private bool CheckPushdownFinalState()
        {
            if (this._pushdown.Count == 2 &&
                (this._pushdown[1] == TerminalNonterminal.G2_AS || this._pushdown[1] == TerminalNonterminal.G2_EXP))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Makes a string from the top of the pushdown up to the given index.
        /// </summary>
        /// <param name="fromId">Numeric index</param>
        /// <returns>Returns a string representing a head of the pushdown.</returns>
        private string PushdownToString(int fromId)
        {
            string pushdownString = "[ ";
            for (int i = fromId; i < this._pushdown.Count; i++)
            {
                pushdownString += this._pushdown[i] + " ";
            }
            pushdownString += "]";

            return pushdownString;
        }

        /// <summary>
        /// Recovers parser after error by skipping input symbols, that should be parsed with this instance.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        private void ErrorAndRecovery(string errorMessage)
        {
            SyntaxErrorWriteOut(errorMessage, this._component.Name);

            this._isInRecoveryMode = true;

            // Skip input symbols
            while (this._component.TermIndexMap.ContainsKey(this._actualToken.TerminalType))
            {
                if (this._actualToken.TerminalType == Terminal.STRING_TERMINATOR)
                {
                    break;
                }

                this._actualToken = this._scanner.GetNextToken();
                CheckActualToken(this._component);
            }
        }
    }
}
