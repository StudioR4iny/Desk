using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;

namespace R4iny.Desk.Cli;

internal class Args
{
    private static Args _instance;
    public static Args Instance => Args._instance ??= new Args();

    private const bool ZeroInputHelp = true;
    internal const string DatabasePath = "database.json";

    private Parser Parser { get; set; }

    private Args()
    {
        string description = "R4iny.Desk ~ Logging app for developer and everyone."
            + Environment.NewLine + Environment.NewLine
            + "We made a tool that helps our work into a single app."
            + " We hope this will help you and please let me know if you have any suggestions."
            + Environment.NewLine
            + "To get further infomation or to report bugs, please read README.MD or contact us.";

        RootCommand root = new RootCommand(description);
        root.AddRange(new List<Symbol>()
        {
            Commands.DatabaseCommand,
        });

        root.SetHandler(() =>
        {
            if (Args.ZeroInputHelp)
            {
                Console.WriteLine("INFO:: Zero-argument calls the '--help' flag");
                Console.WriteLine();

                this.Parser.Invoke("--help");
                Environment.Exit(0);
            }

            Args.TopWork();
        });

        this.Parser = new CommandLineBuilder(root)
            .UseHelp("-h", "--help")
            .UseVersionOption("-v", "--version")
            .Build();
    }

    public int Parse(string[] args) => this.Parser.Invoke(args);
    public int Parse(string arg) => this.Parse(arg.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries));

    private static void TopWork()
    {
        Console.WriteLine("TOP WORK!!");
    }
}

public static partial class ExtensionMethods
{
    public static void AddRange(this Command command, IEnumerable<Symbol> symbols)
    {
        foreach (Symbol sym in symbols)
        {
            if (sym is Command) command.AddCommand(sym as Command);
            else if (sym is Argument) command.AddArgument(sym as Argument);
            else if (sym is Option) command.AddOption(sym as Option);
            else throw new NotImplementedException();
        }
    }

    public static void AddSortedSymbol(this Command command, IEnumerable<Symbol> symbols)
    {
        command.AddRange(symbols.OrderBy(x => x.Name));
    }
}