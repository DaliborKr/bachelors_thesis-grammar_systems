///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA.Tests
///   File:     SyntaxAnalysisTests/ForSyntaxAnalysisTests.cs
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
    public class ForSyntaxAnalysisTests
    {
        [Fact]
        public void BreakInBodyForTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/FOR/breakInBody.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ComplexForTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/FOR/complex.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ComplexCondition1ForTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/FOR/complexCondition1.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ComplexCondition2ForTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/FOR/complexCondition2.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ContinueInBodyForTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/FOR/continueInBody.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void EmptyBodyForTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/FOR/emptyBody.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void EmptyConditionForTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/FOR/emptyCondition.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void NonemptyBodyForTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/FOR/nonemptyBody.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }
    }
}
