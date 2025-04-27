///////////////////////////////////////////////////////////////////////////
/// 
///  Bachelor's Thesis - Grammar Systems and Their Applications
/// 
///   Project:  GrammarSystemSA
///   File:     Program.cs
/// 
///   Author:   Dalibor Kříčka (xkrick01)
///   Year:     2024
/// 
///////////////////////////////////////////////////////////////////////////


using GrammarSystemSA.Lexical;
using GrammarSystemSA.Parsers;
using GrammarSystemSA.Components;

namespace GrammarSystemSA
{
    class Program
    {
        /// <summary>
        /// Parses input arguments. Prints help when arguments are incorrect.
        /// </summary>
        /// <param name="args">Array of input arguments.</param>
        /// <returns>Tuple with parsed input file path and value of the show parameter.</returns>
        static Tuple<string, bool> ParseProgramArguments(string[] args)
        {
            bool showParameter = false;

            if (args.Length <= 0)
            {
                Console.WriteLine("Path to the file is missing.\n");
                PrintProgramHelp();
            }
            else if (args.Length > 2)
            {
                Console.WriteLine("Too many program arguments.\n");
                PrintProgramHelp();
            }

            if (args.Length == 1)
            {
                if (args[0] == "-h" || args[0] == "--help")
                {
                    PrintProgramHelp();
                }
            }
            else if (args.Length == 2)
            {
                if (args[1] == "-s" || args[1] == "--show")
                {
                    showParameter = true;
                }
                else
                {
                    Console.WriteLine("Unknown parameter '" + args[1] + "'.\n");
                    PrintProgramHelp();
                }
            }

            return new Tuple<string, bool>(args[0], showParameter);
        }

        /// <summary>
        /// Prints helps into the console and exits program.
        /// </summary>
        static void PrintProgramHelp()
        {
            Console.WriteLine(
                    "PROGRAM HELP\n" +
                    "  NAME:\n" +
                    "    GrammarSystemSA - Syntax analyzer of C++ language based on CD grammar system\n" +
                    "\n" +
                    "  USAGE:\n" +
                    "    Run parser:  GrammarSystemSA.exe <filePath> [-s | --show]\n" +
                    "    Show help:   GrammarSystemSA.exe -h | --help\n" +
                    "\n" +
                    "  OPTIONS:\n" +
                    "    <filePath>    Path to the file with C++ source program to be parsed\n" +
                    "    -s, --show    Allow to show a process of parsing via console (sequences of applied grammar rules and switching components)\n" +
                    "    -h, --help    Show help and usage information\n" +
                    "\n" +
                    "  AUTHOR:\n" +
                    "    Dalibor Kříčka (xkrick01), 2023"
                );
            Environment.Exit(0);
        }

        /// <summary>
        /// Prints into the console results that summarize the process of parsing (success or failure of parsing, list of errors).
        /// </summary>
        /// <param name="filePath">Path to the input source file.</param>
        /// <param name="showParameter">Value of the show parameter.</param>
        static void PrintParsingResults(string filePath, bool showParameter)
        {
            if (showParameter)
            {
                Console.WriteLine("\n\n=============================================================\n");
            }

            if (ParsingStats.Stats.ParsingSuccess)
            {
                Console.WriteLine("\nThe parsing of the file '" + filePath + "' has succeeded.");
            }
            else
            {

                Console.WriteLine("\nThe parsing of the file '" + filePath + "' has failed.");

                if (showParameter)
                {
                    Console.WriteLine("\nNumber of SYNTAX ERROR detected: " + ParsingStats.Stats.SyntaxErrorNumber);
                    Console.WriteLine("Number of LEXICAL ERROR detected: " + ParsingStats.Stats.LexicalErrorNumber);
                }

                Console.WriteLine("\nError messages:");
                foreach (string message in ParsingStats.Stats.ErrorMessages)
                {
                    Console.WriteLine("  -> " + message);
                }
            }
        }

        static void Main(string[] args)
        {
            Tuple<string, bool> parsedArgs = ParseProgramArguments(args);
            string filePath = parsedArgs.Item1;
            bool showParameter = parsedArgs.Item2;

            try
            {
                Scanner scanner = new Scanner(filePath);
                LLParser llParser = new LLParser(scanner, showParameter, LLComponent.InstanceBody);

                if (showParameter)
                {
                    Console.WriteLine("Active component: " + LLComponent.InstanceBody.ExtendedName);
                }

                llParser.Parse();
                PrintParsingResults(filePath, showParameter);

                scanner.CloseInput();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File '" + filePath + "' not found.");
            }
        }
    }
}