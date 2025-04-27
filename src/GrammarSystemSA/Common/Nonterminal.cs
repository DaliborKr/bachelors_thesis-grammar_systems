///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Common\Nonterminal.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


namespace GrammarSystemSA.Common
{
    /// <summary>
    /// Set of all possible parsing nonterminals.
    /// </summary>
    public enum Nonterminal
    {
        // LL body grammar
        G1_START = 99,
        G1_PROGRAM_MAIN = 100,
        G1_CONSTRUCT_BLOCK = 101,
        G1_CONSTRUCT_CONT = 102,
        G1_CONSTRUCT = 103,
        G1_ELEMENT = 104,
        G1_VAR_DEF = 105,
        G1_ASSIGN = 106,
        G1_VALUE = 107,
        G1_IF_CONT = 108,
        G1_ELSE_IF_CONT = 109,
        G1_FUNC_DTYPE = 110,
        G1_PARAMETERS = 111,
        G1_PARAMETERS_CONT = 112,
        G1_DTYPE = 113,
        G1_DEFINE = 117,

        // Precedence expression grammar
        G2_AS = 118,
        G2_EXP = 119,

        // SLR expression grammar
        G3_S_START = 120,
        G3_O = 121,
        G3_A = 122,
        G3_C1 = 123,
        G3_C2 = 124,
        G3_E = 125,
        G3_T = 126,
        G3_N = 127,
        G3_P = 128,
        G3_I = 129,
        G3_D = 130,

        // LL function call grammar
        G4_START = 131,
        G4_FUNCTION_CALL = 132,
        G4_ARGS = 133,
        G4_ARGS_CONT = 134
    }
}
