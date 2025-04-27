///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Components\SLRComponent.cs
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
    /// Represents a SLR component of the grammar system.
    /// </summary>
    public class SLRComponent : Component
    {
        // Singleton instance of a SLR component for Grammar G3 SLR Expressions
        private static readonly SLRComponent _instance = new SLRComponent("G3", "G3 - SLR", GrammarSetsData.SLR,
            SLRParsingTable.Instance, SLRNonTermIndexMapper.Map);
        public static SLRComponent Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Instance of the SLR parsing table.
        /// </summary>
        public SLRParsingTable Table { get; set; }

        /// <summary>
        /// Represents a dictionary that is mapping terminals and nonterminals to specific
        /// indexes of the parsing table.
        /// </summary>
        public Dictionary<TerminalNonterminal, int> TermIndexMap { get; set; }

        // Singleton constructor (cannot be instantiated from outside)
        private SLRComponent(string name, string extendedName, List<GrammarRule> grammar, SLRParsingTable table,
            Dictionary<TerminalNonterminal, int> termIndexMap) : base(name, extendedName, grammar)

        {
            this.Table = table;
            this.TermIndexMap = termIndexMap;
        }
    }
}
