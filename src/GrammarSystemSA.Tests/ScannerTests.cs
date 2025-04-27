///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA.Tests
///   File:     ScannerTests.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Lexical;

namespace GrammarSystemSA.Tests
{
    public class ScannerTests
    {
        [Fact]
        public void OpeningExistingFile()
        {
            Scanner scanner = new Scanner("../../../InputTestingPrograms/OpenFileTest.cpp");
        }

        [Fact]
        public void OpeningNonExistingFile()
        {
            Assert.Throws<FileNotFoundException>(() => new Scanner("nonexistent_file.cpp"));
        }
    }
}
