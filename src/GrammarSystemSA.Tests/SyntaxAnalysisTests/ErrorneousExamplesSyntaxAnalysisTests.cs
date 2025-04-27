///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA.Tests
///   File:     SyntaxAnalysisTests/ErrorneousExamplesSyntaxAnalysisTests.cs
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
    public class ErrorneousExamplesSyntaxAnalysisTests
    {
        [Fact]
        public void CaseDefinitionInConditionErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/caseDefinitiontInCondition.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void CaseDoubleColonErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/caseDoubleColon.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ExpressionPrecedence1ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/expressionPrecedence1.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ExpressionPrecedence2ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/expressionPrecedence2.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ExpressionPrecedence3ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/expressionPrecedence3.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ExpressionPrecedence4ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/expressionPrecedence4.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ExpressionPrecedence5ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/expressionPrecedence5.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ExpressionPrecedence6ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/expressionPrecedence6.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }



        [Fact]
        public void ExpressionSLR1ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/expressionSLR1.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ExpressionSLR2ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/expressionSLR2.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ExpressionSLR3ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/expressionSLR3.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ExpressionSLR4ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/expressionSLR4.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ExpressionSLR5ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/expressionSLR5.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }



        [Fact]
        public void ForNoSemicolon1ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/forNoSemicolon1.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void ForNoSemicolon2ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/forNoSemicolon2.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void FuncDefBasic1ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/funcDefBasic1.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void FuncDefBasic2ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/funcDefBasic2.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void FuncDefBasic3ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/funcDefBasic3.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void FuncDefCommaErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/funcDefComma.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void FuncDefNotClosedErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/funcDefNotClosed.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void FunctionCallCloseBracketErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/functionCallCloseBracket.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void FunctionCallMissingCommaErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/functionCallMissingComma.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void FunctionCallMissingValueErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/functionCallMissingValue.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void NoSemicolonErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/noSemicolon.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void VarDefGlobalScope1ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/varDefGlobalScope1.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void VarDefGlobalScope2ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/varDefGlobalScope2.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void VarDefGlobalScope3ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/varDefGlobalScope3.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void VarDefInvalidParameterErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/varDefInvalidParameter.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void VarDefNoValueErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/varDefNoValue.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void WhileNotClosedCondition1ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/whileNotClosedCondition1.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void WhileNotClosedCondition2ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/whileNotClosedCondition2.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void WhileNotOpenedBodyErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/whileNotOpenedBody.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void WhileNotOpenedCondition1ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/whileNotOpenedCondition1.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }

        [Fact]
        public void WhileNotOpenedCondition2ErrorTests()
        {
            ParsingStats.Stats.StatsToInitState();

            Scanner scanner = new Scanner("../../../InputTestingPrograms/ERRORNEOUS_EXAMPLES/whileNotOpenedCondition2.cpp");

            LLParser llParser = new LLParser(scanner, false, LLComponent.InstanceBody);

            llParser.Parse();

            Assert.False(ParsingStats.Stats.ParsingSuccess);
        }
    }
}
