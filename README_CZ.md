# Bakalářská práce - Gramatické systémy a jejich aplikace
#### `Autor:` &nbsp;&nbsp; Dalibor Kříčka (xkrick01)
#### `Vedoucí práce:` &nbsp;&nbsp; prof. RNDr. Alexandr Meduna, CSc.
#### 2024, Brno
---
---

## Zadání
Konkrétní znění zadání pro tuto bakalářskou práci je následovné:


1. Seznamte se podrobně s gramatickými systémy a jejich vlastnostmi.
2. Dle pokynů vedoucího zaveďte alternativní typy gramatických systémů.
3. Studujte vlastnosti gramatických systémů zavedených v předchozím bodě a porovnejte je s již zavedenými gramatickými systémy. Zaměření tohoto studia konzultujte s vedoucím.
4. Demonstrujte aplikovatelnost zavedených systémů v oblasti syntaktické analýzy. Zaměřte se na kombinovanou syntaktickou analýzu založenou na systémech z bodu 2.
5. Aplikujte a implementujte syntaktickou analýzu navrženou v předchozím bodě. Testujte ji na sadě minimálně 10 příkladů.
6. Zhodnoťte dosažené výsledky. Diskutujte další vývoj projektu.


## Odevzdané soubory
* **app/** – adresář obsahující spustitelné soubory a soubory nezbytné pro spuštění
    * **Linux/** – adresář se spustitelnou aplikací pro linuxové distribuce
        * **ExampleInputFiles/** – adresář s ukázkovými vstupními soubory aplikace
        * **TablesData/** – adresář s CSV soubory, které obsahují data tabulek analýzy
        * **GrammarSystemSA** – spustitelný soubor aplikace
    * **Windows/** – adresář se spustitelnou aplikací pro platformu Windows
        * **ExampleInputFiles/** – adresář s ukázkovými vstupními soubory aplikace
        * **TablesData/** – adresář s CSV soubory, které obsahují data tabulek analýzy
        * **GrammarSystemSA.exe** – spustitelný soubor aplikace
* **doc/** – adresář dokumentace
    * **docSrc/** – adresář obsahující zdrojové soubory technické zprávy
    * **others/** – adresář obsahující schémata a tabulky využité pro řešení práce
    * **xkrick01_BP_TechnickaZprava.pdf** – PDF soubor technické zprávy
* **src/** – adresář aplikace
    * **GrammarSystemSA/** – projekt implementující zdrojové soubory aplikace
    * **GrammarSystemSA.Tests/** – projekt s xUnit testy k aplikaci
    * **InputTestingPrograms/** – adresář se vstupními soubory pro testování
    * **TablesData/** – adresář s CSV soubory, které obsahují data tabulek analýzy
    * **GrammarSystemSA.sln** – řešení (solution) .NET aplikace
* **README.md**

## Technické zpráva
Technická zpráva bakalářké práce je k nalezení ve formátu PDF ve složce `doc/` (soubor `xkrick01_BP_TechnickaZprava.pdf`). Zdrojový text práce včetně všech náležitostí potřebných pro vytvoření PDF se nachází ve složce `doc/docSrc`. PDF je možné vytvořit z tohoto adresáře příkazem `make`.

## Popis aplikace
Jedná se o .NET konzolovou aplikaci implementovanou v programovacím jazyce C#. Tato aplikace provádí lexikální a syntaktickou analýzu nad vstupním souborem na základě konkrétního gramatického systému definovaného pro tuto práci, který přijímá podmnožinu jazyka C++. Výstupem této aplikace je informace o tom, zda proběhla lexikální i syntaktická analýza bezchybně nebo naopak s chybou. Při neúspěchu je na výstup vypsán seznam všech nalezených chyb s jejich krátkým popisem. Implementace je obohacena o funkcionalitu zotavení po chybě, takže je možné v rámci jednoho běhu syntaktické analýzy detekovat více než jednu chybu. Dalším rozšířením je lokalizace chyb v rámci vstupního souboru informující uživatele o konkrétním místě výskytu jednotlivých chyb. Volitelně navíc může uživatel nechat na výstup vypsat průběh syntaktické analýzy, tedy kdy a jakým způsobem probíhalo předání aktivity mezi komponentami gramatického systému a jaká gramatická pravidla byla aplikována při konkrétní aktivitě určité komponenty (viz `doc/xkrick01_BP_TechnickaZprava.pdf` kapitoly 6 a 7).

### Vstupy a výstupy aplikace
Vstupem do programu je soubor se zdrojovým textem, nad kterým má být provedena lexikální a syntaktická analýza. Očekává se, že obsah vstupního souboru bude podmnožinou jazyka C++ definovanou v `doc/xkrick01_BP_TechnickaZprava.pdf` v podkapitole
5.3. Výstupem je výpis do konzole s informací o úspěchu či neúspěchu syntaktické analýzy. Výpis po úspěšné/neúspěšné analýze vypadá následovně:

```
The parsing of the file ’[path]’ has succeeded / failed.
```

V případě neúspěchu je kromě informace o neúspěchu na výstupu uveden také kompletní seznam všech chyb včetně podrobností o chybách. Pro každou chybu je specifikováno, o jaký typ chyby se jedná (lexikální/syntaktická), kterou komponentou byla chyba odhalena, krátký popis chyby a řádek a pozici na řádku, kde se chyba vyskytuje. Viz nasledující příklad:

Vstupní program `errorExample.cpp`:
```
int i = 12 10

void idFunc(){
i = 10 - + 2;
}
```

Výstup v konzoli:
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

#### Spuštění aplikace s argumentem _--show_
Program je možné spustit s volitelným argumentem _--show_, který na výstup vypíše sled událostí, které nastávají v průběhu celé syntaktické analýzy. Mezi zaznamenávané události patří předání aktivity mezi komponentami, aplikace gramatického pravidla a informace o chybě při analýze. Viz následující příklad:

* Vstupní program `showExample.cpp`:
```
int i = !true * 10;
```

* Výstup v konzoli při spuštění s argumentem _--show_:
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

### Prostředí
Program byl testován na následujících operačních systémech:
* **Microsoft Windows 10**,
* **Fedora LINUX 40**,
* **Ubuntu 23.10**.

Na jiných než výše uvedených operačních systémech není zaručena korektní funkcionalita programu.


### Použité technologie
Využito je technologií _C#_ a _.NET verze 8.0_ a vývoj probíhal ve vývojovém prostředí _Visual Studio Comunity 2022_. C# je vysokoúrovňový objektově orientovaný programovací jazyk, zatímco .NET je vývojová platforma poskytující množství knihoven a běhové prostředí pro jazyk C#. Přesto, že jsou všechny zmíněné technologie vyvíjeny společností Microsoft, je možné výslednou aplikaci, kromě platformy Windows, zkompilovat také například pro různé linuxové distribuce (Fedora, Ubuntu, . . . ).



## Použití aplikace
### Kompilace .NET projektu a náležitosti pro spuštění
#### Instalace .NET
Pro kompilaci projektu je nutné disponovat vývojovou platformou _.NET verze 8.0_, která poskytuje potřebné knihovny a běhové prostředí pro jazyk _C#_.
Nainstalovat .NET je možné podle následujícího postupu:
* Instalace pro **[Windows](https://learn.microsoft.com/en-us/dotnet/core/install/windows?tabs=net80)**
* Instalace pro **[Linux](https://learn.microsoft.com/en-us/dotnet/core/install/linux)**
    * Fedora: `dnf install dotnet-sdk-8.0`
    * Ubuntu: `apt-get install dotnet-sdk-8.0`

Může se stát, že aby bylo možné po instalaci příkazy `dotnet` použít, bude třeba restartovat již spuštěný příkazový řádek nebo i celý systém.

#### Kompilace projektu
Projekt je možné kompilovat z adresáře, který obsahuje projektový soubor s příponou _.csproj_ (v tomto případě _GrammarSystemSA.csproj_ v adresáři `src/_GrammarSystemSA/`). Samotná kompilace je spuštěna příkazem:

```
dotnet build
```

Výchozí cesta k takto sestavenému projektu je `bin/Debug/net8.0/`, kde je k nalezení spustitelný soubor konzolové aplikace. Zmíněným příkazem lze projekt sestavit i ze složky `src/`, kde je přítomen soubor _GrammarSystemSA.sln_, představující řešení (solution) celé .NET aplikace.


Vlastní cesta k adresáři, kam má být projekt sestaven, může být explicitně specifikována parametrem _-o <vlastni_cesta>_. Příkaz pro sestavení projektu poté vypadá následovně:
```
dotnet build -o <vlastni_cesta>
```

#### Data tabulek analýzy
Pro zajištění správné funkcionality syntaktického analyzátoru, jenž je jádrem aplikace, **je nutné do adresáře se sestaveným projektem (tedy tam, kde je umístěný spustitelný soubor) nakopírovat složku TablesData/**, která obsahuje soubory typu _.csv_ pro jednotlivé komponenty. Tyto soubory obsahují data tabulek analýzy všech komponent gramatického systému.
Bez nich tedy není možné syntaktický analyzátor spustit. Konkrétní soubory, které musí složka **TablesData/** obsahovat jsou:

* LLFuncTable.csv,
* LLTable.csv,
* PrecTable.csv,
* SLRTable.csv.

Složka s CSV soubory je k nalezení ve složce `src/`.

### Spuštění aplikace




Spustitelné aplikace se nachází ve složkách `app/Windows` (pro platformu _Windows_) a `app/Linux` (pro _linuxové distribuce_). V těchto složkách jsou již vložená data tabulek analýzy (složka `TablesData/`) a navíc příklady vstupních souborů, nad kterými je možné syntaktickou analýzu spustit (ve složce `ExampleInputFiles/`). Aplikace, tedy syntaktická analýza nad vstupním souborem, je spuštěna následujícím příkazem:

* **Windows**
```
GrammarSystemSA.exe <cesta_ke_zdrojovemu_souboru> [--show]
```

* **Linuxové distribuce**

```
./GrammarSystemSA <cesta_ke_zdrojovemu_souboru> [--show]
```

kde:
* **<cesta_ke_zdrojovemu_souboru>** – je cesta ke zdrojovému souboru, nad kterým má být provedena lexikální a  syntaktické analýza
* **--show, -s** – je volitelný parametr
    * pokud je nastaven, je na výstup vypsán sled událostí, které nastávají v průběhu celé syntaktické analýzy (předání aktivity mezi komponentami, použití gramatických pravidel, chyby)

Jednotlivé argumenty programu musí být zadány ve výše uvedeném pořadí.


### Vypsání nápovědy
Následujícím způsobem je možné vypsat nápovědu k programu:

* **Windows**
```
GrammarSystemSA.exe --help | -h
```

* **Linuxové distribuce**

```
./GrammarSystemSA --help | -h
```

## Testování aplikace
Funkčnost aplikace byla testována pomocí .NET nástroje _xUnit.net_. Konkrétní .NET projekt,
který obsahuje testy i testovací soubory, je k nalezení ve
složce `src/GrammarSystemSA.Tests/`. Aplikace byla testována na přibližně 120 vstupních souborech obsahujících zdrojový text v jazyce,
který přijímá implementovaný gramatický systém. Všechny testovací soubory jsou přístupné k nahlédnutí v adresáři `src/InputTestingPrograms/`. Testování probíhalo jak na syntakticky správných souborech, pro
které je předpokládán úspěch syntaktické analýzy, tak na souborech syntakticky chybných, u kterých je naopak očekáváno odhalení chyby.
Správnost fungování aplikace byla ověřena na platformách _Windows 10_, _Fedora 40_ a _Ubuntu 23.10_.

Zmíněné testy je možné spustit z adresáře, který obsahuje projektový soubor s příponou .csproj (v tomto případě GrammarSystemSA.Tests.csproj), následujícím příkazem:

```
dotnet test
```

Je nutné, aby jednotlivé testy byly spoušteny sekvenčně, jelikož je v projektu využit návrhový vzor _Singleton_ (česky _jedináček_). Při paralelním běhu více testů by bylo všemi právě probíhajícími testy přistupováno k právě jedné konkrétní instanci takto navrhnuté třídy.
To znamená, že by mohlo dojít k vzájemnému přepisování hodnot vlastností této instance. V přiloženém projektu je sekvenční testování již nastaveno.

V přiložených souborech jsou také ve složce `app/Windows/ExampleInputFiles/` dostupné ukázkové vstupní soubory
pro syntaktickou analýzu (syntakticky správné i chybné). Spuštění aplikace s argumentem **--show** nad těmito programy může posloužit jako zřetelný příklad toho, jak
gramatický systém pracuje, popřípadě jak probíhá zotavení po chybě v jednotlivých komponentách.

## Vývojová prostředí
Pro pohodlné sestavování nejen jednotlivých _projektů_, ale i celého .NET _řešení_, ladění programu a spouštění testů xUnit je možné použít dostupná vývojová prostředí.

### Visual Studio 2022
_Visual Studio 2022_ je přímo určené pro vývoj .NET projektů. Poskytuje veškeré dostupné nástroje a je komplexní. Dostupné je pouze pro platformu _Windows_.

### Visual Studio Code
Na Linuxových platformách je možné využít _Visual Studio Code_ s vybranými rozšířeními. Rozšíření vhodná pro práci s .NET a jazykem C# jsou:
* C#
* C# Dev Kit
* .NET Install Tool


## Struktura zdrojových souborů .NET projektu GrammarSystemSA
* `Common/` - Konstanty a výčtové typy definující množiny terminálů, neterminálů, stavů konečného automatu, . . .
    * Constants.cs
    * Nonterminals.cs
    * ParsingTableAction.cs
    * PushDownType.cs
    * ScannerState.cs
    * Terminal.cs
    * TerminalNonterminal.cs

* `Components/` - Třídy reprezentující jednotlivé komponenty gramatického systému
    * Component.cs
    * LLComponent.cs
    * PrecedenceComponent.cs
    * SLRComponent.cs

* `Grammars/` - Množiny gramatických pravidel jednotlivých komponent a třída reprezentující gramatické pravidlo
    * GrammarRule.cs
    * GrammarSetsData.cs

* `Lexical/` - Lexikální analyzátor a třída reprezentující token
    * Scanner.cs
    * Token.cs

* `Mappers/` - Slovníky mapující terminály klíčových slov na konkrétní hodnoty řetězců a terminály/neterminály na indexy řádků/sloupců konkrétních tabulek analýzy
    * KeywordTokenMapper.cs
    * LLBodyNontermIndexMapper.cs
    * LLBodyTermIndexMapper.cs
    * LLFunctionNontermIndexMapper.cs
    * LLFunctionTermIndexMapper.cs
    * PrecedenceTermIndexMapper.cs
    * SLRNonTermIndexMapper.cs

* `Parsers/` - Třídy implementující logiku jednotlivých metod syntaktické analýzy i celého syntaktického analyzátoru založeného na gramatickém systému
    * BottomUpParser.cs
    * LLParser.cs
    * Parser.cs
    * ParsingStats.cs
    * PrecedenceParser.cs
    * SLRParser.cs
    * SLRPushdownItem.cs

* `Tables/` - Tabulky analýzy jednotlivých komponent včetně algoritmů na zpracování CSV souborů s daty tabulek
    * LLParsingTable.cs
    * ParsingTable.cs
    * PrecedenceParsingTable.cs
    * SLRParsingTable.cs
    * SLRTableCell.cs

* `Program.cs` - Třída s metodou Main(), která spouští syntaktickou analýzu a zpracovává vstupní argumenty


Funkce jednotlivých zdrojových souborů v projektu je detailněji vysvětlena v technické zprávě (soubor `doc/xkrick01_BP_TechnickaZprava.pdf`), konkrétně v kapitole _6 Implementace gramatického systému_, kde jsou podrobnosti rozepsány.