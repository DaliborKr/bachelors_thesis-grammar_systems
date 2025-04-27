using GrammarSystemSA.Common;
using GrammarSystemSA.Components;
using GrammarSystemSA.Grammars;
///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Parsers\SLRParser.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Lexical;
using GrammarSystemSA.Tables;

namespace GrammarSystemSA.Parsers
{
    /// <summary>
    /// Represents a SLR predictive parser that does syntax analysis based on SLR components.
    /// </summary>
    public class SLRParser : BottomUpParser
    {
        /// <summary>
        /// SLR component assigned to the parser instance (provides grammar, parsing table, mappers, ...).
        /// </summary>
        private readonly SLRComponent _component;

        /// <summary>
        /// Represents pushdown of the pushdown automaton.
        /// </summary>
        private new List<SLRPushdownItem> _pushdown;

        /// <summary>
        /// Represents the current state that the SLR parser is in.
        /// </summary>
        private int _actualState;

        /// <summary>
        /// Represents the most recently read cell from the SLR parsing table.
        /// </summary>
        private SLRTableCell _actualCell;

        // Constructor
        public SLRParser(Scanner scanner, bool logEnabled, SLRComponent component) : base(scanner, logEnabled)
        {
            this._component = component;
            this._pushdown = new List<SLRPushdownItem>();
            this._actualCell = new SLRTableCell(ParsingTableAction.ERROR, -1);
        }

        public override void Parse()
        {
            // Initialization
            this._pushdown.Add(new SLRPushdownItem(TerminalNonterminal.STRING_TERMINATOR, 0));
            this._actualState = 0;

            this._actualToken = this._scanner.GetLastToken();

            CheckActualToken(this._component);

            // Parsing
            while (true)
            {
                if (this._isInRecoveryMode)
                {
                    return;
                }

                if (this._component.TermIndexMap.TryGetValue((TerminalNonterminal)this._actualToken.TerminalType, out int columnIndex))
                {
                    // Check if the state number is valid
                    if (this._actualState >= this._component.Table.Table.GetLength(0) || this._actualState < 0)
                    {
                        ErrorAndRecovery("Nonexisting state '" + this._actualState + "'");
                    }

                    this._actualCell = this._component.Table.GetCell(this._actualState, columnIndex);

                    // Access to the ACTION parsing table part
                    switch (this._actualCell.Action)
                    {
                        case ParsingTableAction.SHIFT:
                            PushAndReadNext();
                            break;
                        case ParsingTableAction.REDUCE:
                            ReducePushdownTop();
                            break;
                        case  ParsingTableAction.OK:
                            // Success
                            //Console.WriteLine("SLR parsing has success");
                            return;
                        case ParsingTableAction.ERROR:
                            ErrorAndRecovery("Parsing table error [" +
                                this._actualState +
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
            // Update the current state
            this._actualState = this._actualCell.ProductionStateNumber;
            this._pushdown.Add(new SLRPushdownItem((TerminalNonterminal)this._actualToken.TerminalType,
                this._actualState));
            
            this._actualToken = this._scanner.GetNextToken();
            CheckActualToken(this._component);
        }

        protected override void ReducePushdownTop()
        {
            GrammarRule rule = this._component.Grammar[this._actualCell.ProductionStateNumber];

            int pushdownRuleIndexStart = this._pushdown.Count - rule.RightSide.Count;
            List<TerminalNonterminal> pushdownTail = GetAndRemoveHeadAt(pushdownRuleIndexStart);

            if (rule.CompareRightSide(pushdownTail) != null)
            {
                // Get a state from the topmost pushdown symbol after symbols that take part in the reduction
                int rowIndex = this._pushdown.Last().State;

                if (!this._component.TermIndexMap.TryGetValue((TerminalNonterminal)rule.LeftSide, out int columnIndex))
                {
                    ErrorAndRecovery("Unknown parsing table symbol - '" + rule.LeftSide.ToString() + "'");
                }

                // Access to the GOTO parsing table part
                this._actualState = this._component.Table.GetCell(rowIndex, columnIndex).ProductionStateNumber;
                this._pushdown.Add(new SLRPushdownItem((TerminalNonterminal)rule.LeftSide, this._actualState));

                Log("  " + rule.ToString(), false);
            }
            else
            {
                // Error - The rule doesn't match with the head of the pushdown
                string errorMessage = "Reduction - Rule number " + rule.RuleNumber + " doesn't match with pushdown top:  ";
                foreach (TerminalNonterminal item in pushdownTail)
                {
                    errorMessage += item.ToString() + "  ";
                }
                ErrorAndRecovery(errorMessage);
            }
        }

        protected override List<TerminalNonterminal> GetAndRemoveHeadAt(int index)
        {
            int tailLength = this._pushdown.Count - index;
            List<SLRPushdownItem> pushdownTailItem = this._pushdown.GetRange(index, tailLength);
            this._pushdown.RemoveRange(index, tailLength);

            List<TerminalNonterminal> pushdownTail = new List<TerminalNonterminal>();
            foreach (SLRPushdownItem pushdownItem in pushdownTailItem)
            {
                pushdownTail.Add(pushdownItem.Symbol);
            }

            return pushdownTail;
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
            while (this._component.TermIndexMap.ContainsKey((TerminalNonterminal)this._actualToken.TerminalType))
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
