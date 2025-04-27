///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Components\PrecedenceComponent.cs
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
    /// Represents a precedence component of the grammar system.
    /// </summary>
    public class PrecedenceComponent : Component
    {
        // Singleton instance of a precedence component for Grammar G2 Precedence Expressions
        private static readonly PrecedenceComponent _instance = new PrecedenceComponent("G2", "G2 - Precedence", GrammarSetsData.Precedence,
            PrecedenceParsingTable.Instance, PrecedenceTermIndexMapper.Map);
        public static PrecedenceComponent Instance 
        {
            get { return _instance; } 
        }

        /// <summary>
        /// Instance of the precedence parsing table.
        /// </summary>
        public PrecedenceParsingTable Table { get; set; }

        /// <summary>
        /// Represents a dictionary that is mapping terminals to specific
        /// indexes of the parsing table.
        /// </summary>
        public Dictionary<Terminal, int> TermIndexMap { get; set; }

        // Singleton constructor (cannot be instantiated from outside)
        private PrecedenceComponent(string name, string extendedName, List<GrammarRule> grammar, PrecedenceParsingTable table, 
            Dictionary<Terminal, int> termIndexMap) : base(name, extendedName, grammar)
        {
            this.Table = table;
            this.TermIndexMap = termIndexMap;
        }
    }
}
