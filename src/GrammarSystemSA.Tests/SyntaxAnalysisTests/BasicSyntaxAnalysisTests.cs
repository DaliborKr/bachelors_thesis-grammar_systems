///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA.Tests
///   File:     SyntaxAnalysisTests/BasicSyntaxAnalysisTests.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Components;
using GrammarSystemSA.Lexical;
using GrammarSystemSA.Parsers;

namespace GrammarSystemSA.Tests.SyntaxAnalysisTests
{
    public class BasicSyntaxAnalysisTests
    {
        [Fact]
        public void DefineFunctionScopeBasicTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/BASIC/FUNCTION_SCOPE/define.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void SemicolonsFunctionScopeBasicTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/BASIC/FUNCTION_SCOPE/semicolons.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void VariableDefinitionFunctionScopeBasicTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/BASIC/FUNCTION_SCOPE/variableDefinition.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void DefineGlobalScopeBasicTests()
        {
            ParsingStats.Stats.StatsToInitState();
            
            Scanner scanner = new Scanner("../../../InputTestingPrograms/BASIC/GLOBAL_SCOPE/define.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();
            
            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void FunctionDefinitionNoParameterGlobalScopeBasicTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/BASIC/GLOBAL_SCOPE/functionDefinitionNoParameters.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();
            
            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void FunctionDefinitionWithAssignGlobalScopeBasicTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/BASIC/GLOBAL_SCOPE/functionDefinitionWithAssign.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();
            
            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void FunctionDefinitionWithParametersGlobalScopeBasicTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/BASIC/GLOBAL_SCOPE/functionDefinitionWithParameters.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();
            
            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void VariableDefinitionGlobalScopeBasicTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/BASIC/GLOBAL_SCOPE/variableDefinition.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();
            
            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void VariableDefinitionWithAssignGlobalScopeBasicTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/BASIC/GLOBAL_SCOPE/variableDefinitionWithAssign.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();
            
            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }
    }
}
