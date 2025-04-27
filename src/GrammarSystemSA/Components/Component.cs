///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Components\Component.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Grammars;

namespace GrammarSystemSA.Components
{
    /// <summary>
    /// Represents a component of the grammar system.
    /// </summary>
    public abstract class Component
    {
        /// <summary>
        /// Represents name of the component.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents extended name of the component.
        /// </summary>
        public string ExtendedName { get; set; }

        /// <summary>
        /// Represents list of grammar rules related to the component.
        /// </summary>
        public List<GrammarRule> Grammar { get; set; }

        // Private constructor (cannot be instantiated from outside - Singleton patern)
        protected Component(string name, string extendedName, List<GrammarRule> grammar)
        {
            this.Name = name;
            this.ExtendedName = extendedName;
            this.Grammar = grammar;
        }
    }
}
