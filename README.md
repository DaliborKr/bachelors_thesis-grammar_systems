# Bachelor's thesis - Grammar Systems and Their Applications
#### `Author:` &nbsp;&nbsp; Dalibor Kříčka
#### `Supervisor:` &nbsp;&nbsp; prof. RNDr. Alexandr Meduna, CSc.
#### 2024, Brno
---
---

## Assignment
The specific wording of the assignment for this bachelor thesis is as follows:


1. Study grammar systems and their properties in detail.
2. According to the supervisor's instructions, introduce alternative types of grammar systems.
3. Study the properties of the grammar systems introduced in the previous point and compare them with already established grammar systems. Consult the supervisor about the focus of this study.
4. Demonstrate the applicability of the introduced systems in the field of syntactic analysis. Focus on combined syntactic analysis based on the systems from point 2.
5. Apply and implement the syntactic analysis proposed in the previous step. Test it on a set of at least 10 examples.
6. Evaluate the achieved results and discuss further development of the project.


## Submitted Files
* **app/** – directory containing executable files and necessary files for running
    * **Linux/** – directory with the executable application for Linux distributions
        * **ExampleInputFiles/** – directory with example input files
        * **TablesData/** – directory with CSV files containing analysis table data
        * **GrammarSystemSA** – executable file
    * **Windows/** – directory with the executable application for Windows platform
        * **ExampleInputFiles/** – directory with example input files
        * **TablesData/** – directory with CSV files containing analysis table data
        * **GrammarSystemSA.exe** – executable file
* **doc/** – directory containing documentation
    * **docSrc/** – directory with source files of the technical report
    * **others/** – directory with schemes and tables used for the solution
    * **xkrick01_BP_TechnickaZprava.pdf** – PDF file of the technical report
* **src/** – directory containing application source code
    * **GrammarSystemSA/** – project implementing the application source code
    * **GrammarSystemSA.Tests/** – project with xUnit tests for the application
    * **InputTestingPrograms/** – directory with input files for testing
    * **TablesData/** – directory with CSV files containing analysis table data
    * **GrammarSystemSA.sln** – .NET solution file
* **README.md**

## Technical Report
The bachelor's thesis's technical report is in PDF format in the `doc/` directory (file `xkrick01_BP_TechnickaZprava.pdf`). The source files needed to generate the PDF are located in `doc/docSrc/`. The PDF can be created from this directory using the `make` command.

## Application Description
Application is a _.NET console application_ implemented in the _C# programming language_. The application performs lexical and syntactic analysis on an input file based on a specific _grammar system_ designed for this thesis, which accepts a _subset of the C++ language_. The output of the application indicates whether the lexical and syntactic analysis succeeded or failed. If errors are found, a list of all detected errors, along with short descriptions, is printed. The implementation includes _error recovery_, allowing the detection of multiple errors within a single parsing run. Additionally, errors are localized within the input file (specific lines and positions are identified). Optionally, users can display the _parsing process_ (component activity transfers and grammar rules applied), as detailed in Chapters 6 and 7 of the technical report (`doc/xkrick01_BP_TechnickaZprava.pdf`).

### Inputs and Outputs
**Input:** a source file that should be lexically and syntactically analyzed.
The file should contain a subset of C++ as defined in the technical report, subsection 5.3.

**Output:** a console message indicating whether the parsing succeeded or failed.
On success/failure, the following message appears:

```
The parsing of the file ’[path]’ has succeeded / failed.
```

If parsing fails, a detailed list of all errors is also provided, specifying:
- the error type (lexical/syntactic)
- the component that detected the error
- a short description
- the line and position where the error occurred.

**Example**:

Input file `errorExample.cpp`:
```
int i = 12 10

void idFunc(){
i = 10 - + 2;
}
```

Console output:
```
The parsing of the file ’errorExample.cpp’ has failed.

Error messages:

 -> G3 - SYNTAX ERROR: Parsing table error [15, CONST_INT]
   Error detected on line ’1’ and position ’12’.
 -> G1 - SYNTAX ERROR: ’SEMICOLON’ expected, but got ’VOID [void]’
   Error detected on line ’3’ and position ’1’.
 -> G2 - SYNTAX ERROR: Reduction - No matching rule for sequence: G2_EXP MINUS
   Error detected on line ’4’ and position ’14’.
```

#### Running the Application with argument _--show_
The application can be run with an optional argument --show to output the sequence of events during syntactic analysis (component activity transfer, rule application, and error information).

**Example**:

* Input file `showExample.cpp`:
```
int i = !true * 10;
```

* Run with _--show_ argument, console output::
```
Active component: G1 - LL body
  0:           G1_START -> G1_PROGRAM_MAIN string_terminator
  3:    G1_PROGRAM_MAIN -> G1_VAR_DEF semicolon G1_PROGRAM_MAIN
  20:        G1_VAR_DEF -> G1_DTYPE id G1_ASSIGN
  45:          G1_DTYPE -> int
  21:         G1_ASSIGN -> assign G3_S_START

––––––––––––––––––––– G1 --> G3 –––––––––––––––––––––

Active component: G3 - SLR
  32:              G3_I -> const_true
  26:              G3_P -> G3_I
  23:              G3_N -> G3_P
  22:              G3_N -> not G3_N
  19:              G3_T -> G3_N
  27:              G3_I -> const_int
  26:              G3_P -> G3_I
  23:              G3_N -> G3_P
  16:              G3_T -> G3_T multiply G3_N
  15:              G3_E -> G3_T
  12:             G3_C2 -> G3_E
  7:              G3_C1 -> G3_C2
  4:               G3_A -> G3_C1
  2:               G3_O -> G3_A

––––––––––––––––––––– G1 <-- G3 –––––––––––––––––––––

Active component: G1 - LL body
  6:    G1_PROGRAM_MAIN -> eof


=============================================================


The parsing of the file ’showExample.cpp’ has succeeded.
```

### Environment
The program was tested on:
* **Microsoft Windows 10**,
* **Fedora LINUX 40**,
* **Ubuntu 23.10**.

Functionality on other operating systems is not guaranteed.


### Used Technologies
Technologies such as C# and .NET version 8.0 were used, and development took place in the Visual Studio Community 2022 environment. C# is a high-level, object-oriented programming language, while .NET is a development platform that provides a wide range of libraries and a runtime environment for C#. Although all the mentioned technologies are developed by Microsoft, it is possible to compile the resulting application not only for the Windows platform but also, for example, for various Linux distributions (Fedora, Ubuntu, etc.).



## Application Usage
### Compilation of the .NET Project and Requirements for Execution
#### Installing .NET
To compile the project, it is necessary to have the development platform _.NET version 8.0_, which provides the required libraries and runtime environment for the _C# language_.
Nainstalovat .NET je možné podle následujícího postupu:
* Installation for **[Windows](https://learn.microsoft.com/en-us/dotnet/core/install/windows?tabs=net80)**
* Installation for **[Linux](https://learn.microsoft.com/en-us/dotnet/core/install/linux)**
    * Fedora: `dnf install dotnet-sdk-8.0`
    * Ubuntu: `apt-get install dotnet-sdk-8.0`

You might need to restart your terminal or the system after installation.

#### Kompilace projektu
The project can be compiled from the directory containing the project file with the `.csproj` extension (in this case, `GrammarSystemSA.csproj` located in the `src/_GrammarSystemSA/`). The compilation itself is started with the command:

```
dotnet build
```

The default path for the compiled project is `bin/Debug/net8.0/` where the executable file of the console application can be found. The project can also be built from the `src/`folder, where the `GrammarSystemSA.sln` file (representing the solution of the whole .NET application) is located.


The target directory for the compiled project can be explicitly specified using the `-o <custom_path>`. The build command then looks like this:
```
dotnet build -o <custom_path>
```

#### Analysis Tables Data
**To ensure the correct functionality of the syntax analyzer, which is the core of the application, it is necessary to copy the `TablesData/` folder into the directory where the compiled project resides (i.e., where the executable file is located).**

This folder contains .csv files for the individual components, holding the analysis tables data for all grammar system components.
Without these files, the syntax analyzer cannot function.
The `TablesData/` folder must contain the following files:

* LLFuncTable.csv,
* LLTable.csv,
* PrecTable.csv,
* SLRTable.csv.

The folder with the CSV files can be found under `src/`.

### Running the Application

Executable versions of the application are located in the `app/Windows` (for Windows) and `app/Linux` (for Linux distributions) directories.
These directories already include the analysis tables data (`TablesData/`) and also example input files that can be used for running the syntax analysis (inside `ExampleInputFiles/`).
The application, meaning the syntax analysis over an input file, is started using the following command:

* **Windows**
```
GrammarSystemSA.exe <path_to_source_file> [--show]
```

* **Linux distributions**

```
./GrammarSystemSA <path_to_source_file> [--show]
```

where:
* **<path_to_source_file>** – is the path to the source file to be lexically and syntactically analyzed
* **--show, -s** – is an optional parameter
    * if set, the program outputs a trace of events occurring during the syntax analysis (component activity transfers, grammar rule applications, errors)

The program arguments must be entered in the order shown above.


### Displaying Help
The help information for the program can be displayed as follows:

* **Windows**
```
GrammarSystemSA.exe --help | -h
```

* **Linux distributions**

```
./GrammarSystemSA --help | -h
```

## Application Testing
The functionality of the application was tested using the .NET tool _xUnit.net_. The specific .NET project containing the tests and test files can be found in the `src/GrammarSystemSA.Tests/` folder.
The application was tested on approximately 120 input files containing source text in the language accepted by the implemented grammar system. All test files are accessible for review in the `src/InputTestingPrograms/` directory.
The testing was conducted on both syntactically correct files, for which a successful syntax analysis is expected, as well as syntactically incorrect files, where the detection of errors is expected.
The correctness of the application was verified on the _Windows 10_, _Fedora 40_, and _Ubuntu 23.10_ platforms.

The mentioned tests can be run from the directory containing the project file with the `.csproj` extension (in this case, `GrammarSystemSA.Tests.csproj`) using the following command:

```
dotnet test
```

It is essential that individual tests are executed sequentially because the project uses the _Singleton_ design pattern. Running multiple tests in parallel would cause all the concurrently running tests to access the same instance of the class designed in this way.
This could lead to mutual overwriting of property values of this instance. In the provided project, sequential testing is already configured.

The example input files for syntax analysis (both syntactically correct and incorrect) are also available in the `app/Windows/ExampleInputFiles/` folder of the provided files.
Running the application with the **--show** argument on these programs can serve as a clear example of how the grammar system works or how recovery occurs after an error in individual components.

## Development Environments
To conveniently build not only individual projects but also the entire .NET solution, debug the program, and run xUnit tests, the available development environments can be used.

### Visual Studio 2022
_Visual Studio 2022_ is specifically designed for .NET project development. It provides all available tools and is complex. It is only available for the _Windows_ platform.

### Visual Studio Code
On Linux platforms, _Visual Studio Code_ can be used with selected extensions. The extensions suitable for working with .NET and the C# language are:
* C#
* C# Dev Kit
* .NET Install Tool


## GrammarSystemSA Project Source File Structure
* `Common/` - Constants and enumerations defining sets of terminals, nonterminals, automaton states, etc.
    * Constants.cs
    * Nonterminals.cs
    * ParsingTableAction.cs
    * PushDownType.cs
    * ScannerState.cs
    * Terminal.cs
    * TerminalNonterminal.cs

* `Components/` - Classes representing individual components of the grammar system
    * Component.cs
    * LLComponent.cs
    * PrecedenceComponent.cs
    * SLRComponent.cs

* `Grammars/` - Sets of grammar rules for individual components and a class representing a grammar rule
    * GrammarRule.cs
    * GrammarSetsData.cs

* `Lexical/` - Lexical analyzer and class representing a token
    * Scanner.cs
    * Token.cs

* `Mappers/` - Dictionaries mapping terminal keywords to specific string values and terminals/nonterminals to row/column indices of specific analysis tables
    * KeywordTokenMapper.cs
    * LLBodyNontermIndexMapper.cs
    * LLBodyTermIndexMapper.cs
    * LLFunctionNontermIndexMapper.cs
    * LLFunctionTermIndexMapper.cs
    * PrecedenceTermIndexMapper.cs
    * SLRNonTermIndexMapper.cs

* `Parsers/` - Classes implementing the logic of individual parsing methods and the overall syntax analyzer based on the grammar system
    * BottomUpParser.cs
    * LLParser.cs
    * Parser.cs
    * ParsingStats.cs
    * PrecedenceParser.cs
    * SLRParser.cs
    * SLRPushdownItem.cs

* `Tables/` - Analysis tables for individual components, including algorithms for processing CSV files with table data
    * LLParsingTable.cs
    * ParsingTable.cs
    * PrecedenceParsingTable.cs
    * SLRParsingTable.cs
    * SLRTableCell.cs

* `Program.cs` - Class with the Main() method that runs the syntax analysis and processes input arguments


The function of individual source files in the project is explained in more detail in the technical report (file `doc/xkrick01_BP_TechnickaZprava.pdf`), specifically in _Chapter 6 Implementation of the Grammar System_, where the details are elaborated.