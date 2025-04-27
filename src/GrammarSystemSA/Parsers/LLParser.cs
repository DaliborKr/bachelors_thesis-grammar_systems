///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Parsers\LLParser.cs
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
    /// Represents a LL predictive parser that does syntax analysis based on LL components.
    /// </summary>
    public class LLParser : Parser
    {
        /// <summary>
        /// LL component assigned to the parser instance (provides grammar, parsing table, mappers, ...).
        /// </summary>
        private readonly LLComponent _component;

        // Constructor
        public LLParser(Scanner scanner, bool logEnabled, LLComponent component) : base(scanner, logEnabled)
        {
            this._component = component;
        }       

        public override void Parse()
        {
            // Initialization
            this._pushdown.Add((TerminalNonterminal)this._component.Grammar[0].LeftSide);

            this._actualToken = this._scanner.GetNextToken();

            // Parsing
            while (true)
            {
                if (this._actualToken.TerminalType == Terminal.ERROR_TOKEN)
                {
                    LexicalErrorWriteOut(this._actualToken.TerminalValue);
                    this._actualToken = _scanner.GetNextToken();
                }

                TerminalNonterminal pushdownTop = this._pushdown.Last();

                if (pushdownTop == TerminalNonterminal.STRING_TERMINATOR)
                {
                    HandleTerminatorOnTop();
                    return;
                }
                else if (GetPushdownItemType(pushdownTop) == PushDownType.TERMINAL)
                {
                    HandleTerminalOnTop(pushdownTop);
                }
                else
                {
                    HandleNonterminalOnTop(pushdownTop);
                }
            }
        }

        /// <summary>
        /// Checks if the LL parsing can terminate.
        /// </summary>
        private void HandleTerminatorOnTop()
        {
            if (this._actualToken.TerminalType == Terminal.EOF)
            {
                // G1 LL Body Success
            }
            else if (this._component.Grammar[0].LeftSide == Nonterminal.G4_START)
            {
                // G4 LL Function Call Success
                this._scanner.ReturnBy(1);
            }
            else
            {
                // Fail (this situation should never occur)
                throw new Exception("No more tokens expected, but got (" + this._actualToken.TerminalType + " [" + this._actualToken.TerminalValue + "])");
            }
        }

        /// <summary>
        /// Compares pushdown topmost terminal with the current token on input.
        /// </summary>
        /// <param name="pushdownTop">The terminal on the top of the pushdown.</param>
        private void HandleTerminalOnTop(TerminalNonterminal pushdownTop)
        {
            if ((int)pushdownTop == (int)this._actualToken.TerminalType)
            {
                this._actualToken = _scanner.GetNextToken();

                // Pop the topmost pushdown terminal
                this._pushdown.RemoveAt(this._pushdown.Count - 1);
                this._isInRecoveryMode = false;
            }
            else
            {
                // Fail
                ErrorAndRecoveryTerminalOnTop("'" + pushdownTop + "' expected, but got '" + this._actualToken.TerminalType + " [" + this._actualToken.TerminalValue + "]'");
            }
        }

        /// <summary>
        /// Pushes a production of the rule determined by the parsing table on the top of the pushdown.
        /// </summary>
        /// <param name="pushdownTop">The nonterminal on the top of the pushdown.</param>
        private void HandleNonterminalOnTop(TerminalNonterminal pushdownTop)
        {
            // Access to the parsing table
            if (this._component.NontermIndexMapper.TryGetValue(pushdownTop, out int nonterminalIndex) &&
                this._component.TermIndexMapper.TryGetValue(this._actualToken.TerminalType, out int terminalIndex))
            {
                int parsingTableProductionNumber = this._component.Table.GetCell(nonterminalIndex, terminalIndex);

                if (parsingTableProductionNumber == Constants.LLTableLookaheadValue)
                {
                    // Lookahead is needed to determine a rule number to use 
                    parsingTableProductionNumber = LookaheadFuncVarDef();
                    if (parsingTableProductionNumber == -1)
                    {
                        ErrorAndRecoveryNonterminalOnTop("Couldn't determine what rule should be used when lookahead was used.");
                        return;
                    }
                }

                if (parsingTableProductionNumber >= 0 && parsingTableProductionNumber < this._component.Grammar.Count)
                {
                    // Valid production number
                    this._pushdown.RemoveAt(this._pushdown.Count - 1);
                    PushProductionOnPushdown(this._component.Grammar[parsingTableProductionNumber]);
                    this._isInRecoveryMode = false;
                }
                else
                {
                    // Fail
                    ErrorAndRecoveryNonterminalOnTop("No rule to apply on Nonterminal '" + pushdownTop + "' with following token '" +
                        this._actualToken.TerminalType + " [" + this._actualToken.TerminalValue + "]'");
                }
            }
            else
            {
                if (!this._component.NontermIndexMapper.ContainsKey(pushdownTop))
                {
                    // A nonterminal that is not in given grammar was produced, so grammar is going to be switched
                    GrammarSwitch(pushdownTop);
                }
                else
                {
                    // Fail
                    ErrorAndRecoveryNonterminalOnTop("Forbidden token '" + this._actualToken.TerminalType + " [" + this._actualToken.TerminalValue + "]'") ;
                }
            }
        }

        /// <summary>
        /// Determines if the given symbol is terminal or nonterminal.
        /// </summary>
        /// <param name="item">Symbol to be determined.</param>
        /// <returns>Returns a type of the symbol.</returns>
        private static PushDownType GetPushdownItemType(TerminalNonterminal item)
        {
            if ((int)item <= Constants.MaxTerminalEnumValue)
            {
                return PushDownType.TERMINAL;
            }
            else
            {
                return PushDownType.NONTERMINAL;
            }
        }

        /// <summary>
        /// Pushes a production of the given rule to the top of the pushdown.
        /// </summary>
        /// <param name="rule">The rule to be pushed on the pushdown.</param>
        private void PushProductionOnPushdown(GrammarRule rule)
        {
            Log("  " + rule.ToString(), false);

            // The production symbols are pushed backwards
            for (int i = rule.RightSide.Count - 1; i >= 0; i--)
            {
                this._pushdown.Add(rule.RightSide[i]);
            }
        }

        /// <summary>
        /// Switches the grammar according to the nonterminal on the pushdown top.
        /// </summary>
        /// <param name="pushdownTop">The nonterminal on the top of the pushdown.</param>
        private void GrammarSwitch(TerminalNonterminal pushdownTop)
        {
            switch (pushdownTop)
            {
                case TerminalNonterminal.G2_AS:
                    this._isInRecoveryMode = false;

                    // The top is a start nonterminal from G2
                    PrecedenceParser precedenceParser = new PrecedenceParser(this._scanner, this._logEnabled, PrecedenceComponent.Instance);

                    LogComponentSwitch(this._component, PrecedenceComponent.Instance, false);
                    precedenceParser.Parse();
                    LogComponentSwitch(this._component, PrecedenceComponent.Instance, true);

                    break;
                case TerminalNonterminal.G3_S_START:
                    this._isInRecoveryMode = false;

                    // The top is a start nonterminal from G3
                    SLRParser slrParser = new SLRParser(this._scanner, this._logEnabled, SLRComponent.Instance);

                    LogComponentSwitch(this._component, SLRComponent.Instance, false);
                    slrParser.Parse();
                    LogComponentSwitch(this._component, SLRComponent.Instance, true);

                    break;
                default:

                    // Fail - The top is no valid nonterminal in the grammam system in this context
                    ErrorAndRecoveryForeignNonterminalOnTop("Forbidden Nonterminal - " + pushdownTop.ToString()) ;

                    break;
            }
            
            this._pushdown.RemoveAt(this._pushdown.Count - 1);

            this._actualToken = this._scanner.GetLastToken();
        }

        /// <summary>
        /// Looks ahead to determine which rule is going to be applied during the function and variable definition LL conflict.
        /// </summary>
        /// <returns>Returns the production number.</returns>
        private int LookaheadFuncVarDef()
        {
            // Get 2 tokens lookahead
            List<Token> lookaheadTokens = this._scanner.Lookahead(2);

            // Compare 2nd token that determines the upcoming production number
            if (lookaheadTokens[1].TerminalType == Terminal.ASSIGN || lookaheadTokens[1].TerminalType == Terminal.SEMICOLON)
            {
                // Use production number 2
                return 2;
            }
            else if (lookaheadTokens[1].TerminalType == Terminal.OPEN_BRACKET_ROUND)
            {
                // Use production number 3
                return 3;
            }
            else
            {
                // Couldn't determine what production to use
                return -1;
            }
        }

        /// <summary>
        /// Does actions that must be done before the recovery starts.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        /// <returns>Returns 'true' if recovery should continue  or 'false' when the parser should continue in regular mode.</returns>
        private bool ErrorAndRecoveryPreCheck(string errorMessage)
        {
            // Check if terminal eol is causing an error
            if (this._actualToken.TerminalType == Terminal.EOL)
            {
                this._actualToken = this._scanner.GetNextToken();
                return false;
            }

            // Update parsers recovery mode status 
            if (!this._isInRecoveryMode)
            {
                SyntaxErrorWriteOut(errorMessage, this._component.Name);
                this._isInRecoveryMode = true;
            }

            return true;
        }

        /// <summary>
        /// Tries to recover parser after error when a terminal is on the top of the pushdown.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        private void ErrorAndRecoveryTerminalOnTop(string errorMessage)
        {
            if (!ErrorAndRecoveryPreCheck(errorMessage))
            {
                return;
            }

            // Pop the topmost pushdown terminal
            this._pushdown.RemoveAt(this._pushdown.Count - 1);
        }

        /// <summary>
        /// Tries to recover parser after error when a nonterminal is on the top of the pushdown.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        /// <exception cref="InvalidOperationException"></exception>
        private void ErrorAndRecoveryNonterminalOnTop(string errorMessage)
        {
            if (!ErrorAndRecoveryPreCheck(errorMessage))
            {
                return;
            }

            // Get the First set of the topmost nonterminal
            if (!this._component.FirstSet.TryGetValue((Nonterminal)this._pushdown.Last(), out var firstSetOfTopmostNonterminal))
            {
                throw new InvalidOperationException("LL parsing: Not valid nonterminal on the pushdown top to do recovery.");
            }

            // Get the Follow set of the topmost nonterminal
            if (!this._component.FollowSet.TryGetValue((Nonterminal)this._pushdown.Last(), out var followSetOfTopmostNonterminal))
            {
                throw new InvalidOperationException("LL parsing: Not valid nonterminal on the pushdown top to do recovery.");
            }

            // Recovery
            while (true)
            {
                this._actualToken = _scanner.GetNextToken();

                if (firstSetOfTopmostNonterminal.Contains(this._actualToken.TerminalType))
                {
                    break;
                }
                else if (followSetOfTopmostNonterminal.Contains(this._actualToken.TerminalType))
                {
                    this._pushdown.RemoveAt(this._pushdown.Count - 1);
                    break;
                }
                else if (this._actualToken.TerminalType == Terminal.EOF)
                {
                    while (this._pushdown.Count > 1)
                    {
                        this._pushdown.RemoveAt(this._pushdown.Count - 1);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Tries to recover parser after error when nonterminal from another grammar is on the top of the pushdown.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
        private void ErrorAndRecoveryForeignNonterminalOnTop(string errorMessage)
        {
            if (!ErrorAndRecoveryPreCheck(errorMessage))
            {
                return;
            }

            // Pop the topmost pushdown terminal
            this._pushdown.RemoveAt(this._pushdown.Count - 1);
        }
    }
}
