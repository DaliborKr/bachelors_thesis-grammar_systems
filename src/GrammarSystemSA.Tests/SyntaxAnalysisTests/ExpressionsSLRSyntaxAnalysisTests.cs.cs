///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA.Tests
///   File:     SyntaxAnalysisTests/ExpressionsSLRSyntaxAnalysisTests.cs
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
    public class ExpressionsSLRSyntaxAnalysisTests
    {
        [Fact]
        public void Expression1SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression1.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression2SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression2.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression3SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression3.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression4SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression4.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression5SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression5.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression6SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression6.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression7SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression7.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression8SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression8.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression9SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression9.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression10SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression10.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression11SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression11.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression12SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression12.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression13SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression13.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression14SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression14.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression15SLRTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/SLR/expression15.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();


            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }
    }
}
