///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Components\LLComponent.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;
using GrammarSystemSA.Grammars;
using GrammarSystemSA.Mappers;
using GrammarSystemSA.Tables;

namespace GrammarSystemSA.Components
{
    /// <summary>
    /// Represents a LL component of the grammar system.
    /// </summary>
    public class LLComponent : Component
    {
        // First LL component instance for Grammar G1 LL Body
        private static readonly LLComponent _instanceBody = new LLComponent("G1", "G1 - LL body", GrammarSetsData.LLBody, 
            LLParsingTable.InstanceBody, GrammarSetsData.LLBodyFirstSet, GrammarSetsData.LLBodyFollowSet, 
            LLBodyNontermIndexMapper.Map, LLBodyTermIndexMapper.Map);
        public static LLComponent InstanceBody 
        { 
            get { return _instanceBody; } 
        }

        // First LL component instance for Grammar G4 LL Function Call
        private static readonly LLComponent _instanceFunctionCall = new LLComponent("G4", "G4 - LL function call", GrammarSetsData.LLFunctionCall, 
            LLParsingTable.InstanceFunctionCall, GrammarSetsData.LLFunctionFirstSet, GrammarSetsData.LLFunctionFollowSet,
            LLFunctionNontermIndexMapper.Map, LLFunctionTermIndexMapper.Map);
        public static LLComponent InstanceFunctionCall
        {
            get { return _instanceFunctionCall; }
        }

        /// <summary>
        /// Instance of the LL parsing table.
        /// </summary>
        public LLParsingTable Table { get; set; }

        /// <summary>
        /// Represents a dictionary that is mapping nonterminals to the specific
        /// row indexes of the parsing table.
        /// </summary>
        public Dictionary<TerminalNonterminal, int> NontermIndexMapper { get; set; }

        /// <summary>
        /// Represents a dictionary that is mapping terminals to the specific
        /// column indexes of the parsing table.
        /// </summary>
        public Dictionary<Terminal, int> TermIndexMapper { get; set; }

        /// <summary>
        /// First set for all nonterminals of the component.
        /// </summary>
        public Dictionary<Nonterminal, List<Terminal>> FirstSet { get; set; }

        /// <summary>
        /// Follow set for all nonterminals of the component.
        /// </summary>
        public Dictionary<Nonterminal, List<Terminal>> FollowSet { get;set; }

        // Private constructor (cannot be instantiated from outside - exactly 2 instances)
        private LLComponent(string name, string extendedName, List<GrammarRule> grammar, LLParsingTable table, Dictionary<Nonterminal, List<Terminal>> firstSet, Dictionary<Nonterminal, List<Terminal>> followSet,
            Dictionary<TerminalNonterminal, int> nontermIndexMapper, Dictionary<Terminal, int> termIndexMapper) : base(name, extendedName, grammar)
        {
            this.Table = table;
            this.NontermIndexMapper = nontermIndexMapper;
            this.TermIndexMapper = termIndexMapper;
            this.FirstSet = firstSet;
            this.FollowSet = followSet;
            this.Grammar = grammar;
        }
    }
}
