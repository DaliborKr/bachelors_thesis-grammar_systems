///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA.Tests
///   File:     SyntaxAnalysisTests/ExampleProgramsSyntaxAnalysisTests.cs
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
    public class ExampleProgramsSyntaxAnalysisTests
    {
        [Fact]
        public void Example1ExampleTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXAMPLE_PROGRAMS/example1.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Example1ErrorExampleTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXAMPLE_PROGRAMS/example1_Error.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Example2ExampleTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXAMPLE_PROGRAMS/example2.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Example2ErrorExampleTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXAMPLE_PROGRAMS/example2_Error.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Example3ExampleTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXAMPLE_PROGRAMS/example3.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Example3ErrorExampleTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXAMPLE_PROGRAMS/example3_Error.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }
    }
}
