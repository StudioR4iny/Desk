using R4iny.Desk.Cli.FunctionModels;
using System.CommandLine;

namespace R4iny.Desk.Cli;

internal class Commands
{
    internal static Command DatabaseCommand
    {
        get
        {
            Command command = new Command(
                name: "database",
                description: "Commands about database.");

            var forceResetFlagOption = new Option<bool>(
                name: "--forced",
                description: "If the database is missing, make a new one without confirmation.");
            forceResetFlagOption.AddAlias("-f");
            command.AddOption(forceResetFlagOption);

            command.SetHandler(DatabaseFunction.TopWork,
                forceResetFlagOption);

            command.AddSortedSymbol(new List<Symbol>()
            {
                DatabaseFunction.CurrentCommand,
                DatabaseFunction.ClearCommand,
                DatabaseFunction.NewCommand,
                DatabaseFunction.AddCommand,
                //DatabaseFunction.ImportCommand,
                //DatabaseFunction.ExportCommand,
            });

            return command;
        }
    }
}
