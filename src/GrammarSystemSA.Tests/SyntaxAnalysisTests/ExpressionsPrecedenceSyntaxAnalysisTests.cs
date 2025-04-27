///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA.Tests
///   File:     SyntaxAnalysisTests/ExpressionsPrecedenceSyntaxAnalysisTests.cs
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
    public class ExpressionsPrecedenceSyntaxAnalysisTests
    {
        [Fact]
        public void Expression1PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression1.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression2PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression2.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression3PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression3.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression4PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression4.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression5PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression5.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression6PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression6.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression7PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression7.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression8PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression8.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression9PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression9.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression10PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression10.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression11PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression12.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression12PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression12.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression13PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression13.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression14PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression14.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression15PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression15.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression16PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression16.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression17PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression17.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression18PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression18.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression19PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression19.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void Expression20PrecedenceTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/EXPRESSIONS/PRECEDENCE/expression20.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.True(ParsingStats.Stats.ParsingSuccess);
        }
    }
}
