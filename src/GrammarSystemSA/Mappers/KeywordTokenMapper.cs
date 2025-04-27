///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Mappers\KeywordTokenMapper.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Common;

namespace GrammarSystemSA.Mappers
{
    /// <summary>
    /// Represents dictionary that is mapping a keyword (as string) to the specific terminal type.
    /// 
    /// Used for lexical analysis.
    /// </summary>
    public class KeywordTokenMapper
    {
        /// <summary>
        /// Mapping a keyword (as string) to the specific terminal type.
        /// </summary>
        public static Dictionary<string, Terminal> Map = new Dictionary<string, Terminal>()
        {
            {"if", Terminal.IF},
            {"else", Terminal.ELSE},
            {"switch", Terminal.SWITCH},
            {"while", Terminal.WHILE},
            {"do", Terminal.DO},
            {"for", Terminal.FOR},
            {"return", Terminal.RETURN},
            {"break", Terminal.BREAK},
            {"case", Terminal.CASE},
            {"default", Terminal.DEFAULT},
            {"continue", Terminal.CONTINUE},

            {"void", Terminal.VOID},
            {"int", Terminal.INT},
            {"float", Terminal.FLOAT},
            {"double", Terminal.DOUBLE},
            {"char", Terminal.CHAR},
            {"string", Terminal.STRING},
            {"bool", Terminal.BOOL},

            {"true", Terminal.CONST_TRUE},
            {"false", Terminal.CONST_FALSE}
        };
    }
}
