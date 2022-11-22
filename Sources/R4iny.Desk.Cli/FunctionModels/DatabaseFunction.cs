using R4iny.Desk.Library.Data;
using System.CommandLine;

namespace R4iny.Desk.Cli.FunctionModels;

internal class DatabaseFunction
{
    public static void TopWork(bool forceResetFlag)
    {
        string message = "Check current database";
        Console.WriteLine(message);
        Console.WriteLine();

        DatabaseFunction.CheckCurrentEntry(forceResetFlag);

        Console.WriteLine();
        Console.WriteLine($"{message}... done");
    }

    public static Command CurrentCommand
    {
        get
        {
            Command command = new Command(
                name: "current",
                description: "Check current database");

            var forceResetFlagOption = new Option<bool>(
                name: "--forced",
                description: "If the database is existing, overwrite as a new one without confirmation.");
            forceResetFlagOption.AddAlias("-f");
            command.AddOption(forceResetFlagOption);

            command.SetHandler((bool forceResetFlag) =>
            {
                string message = command.Description;
                Console.WriteLine(message);
                Console.WriteLine();

                DatabaseFunction.CheckCurrentEntry(forceResetFlag);

                Console.WriteLine();
                Console.WriteLine($"{message}... done");
            }, forceResetFlagOption);

            return command;
        }
    }

    public static Command NewCommand
    {
        get
        {
            Command command = new Command(
                name: "new",
                description: "Create/Reset database");

            var forceResetFlagOption = new Option<bool>(
                name: "--forced",
                description: "If the database is existing, overwrite as a new one without confirmation.");
            forceResetFlagOption.AddAlias("-f");
            command.AddOption(forceResetFlagOption);

            command.SetHandler((bool forceResetFlag) =>
            {
                string message = command.Description;
                Console.WriteLine(message);
                Console.WriteLine();

                //DatabaseFunction.ActivateDatabase(forceResetFlag);

                //Console.WriteLine($"Writing... '{Path.GetFullPath(Settings.Instance.DatabasePath)}'");
                //Database.Reset(Settings.Instance.DatabasePath);

                Console.WriteLine();
                Console.WriteLine($"{message}... done");
            }, forceResetFlagOption);

            return command;
        }
    }

    public static Command ClearCommand
    {
        get
        {
            Command command = new Command(
                name: "clear",
                description: "Clear database");

            var forceResetFlagOption = new Option<bool>(
                name: "--forced",
                description: "If the database is existing, overwrite as a new one without confirmation.");
            forceResetFlagOption.AddAlias("-f");
            command.AddOption(forceResetFlagOption);

            command.SetHandler((bool forceResetFlag) =>
            {
                string message = command.Description;
                Console.WriteLine(message);
                Console.WriteLine();

                Database database = Database.Load(Args.DatabasePath);
                if (database == null)
                {
                    Console.WriteLine("Database doesn't exist. There is nothing to clear.");
                    Environment.Exit(1);
                }

                if (!forceResetFlag)
                {
                    Console.WriteLine("To ensure removing database, please add force flag");
                    Environment.Exit(1);
                }

                File.Delete(Args.DatabasePath);

                Console.WriteLine();
                Console.WriteLine($"{message}... done");
            }, forceResetFlagOption);

            return command;
        }
    }

    public static Command ImportCommand
    {
        get
        {
            Command command = new Command(
                name: "import",
                description: "Import database");

            var forceResetFlagOption = new Option<bool>(
                name: "--forced",
                description: "If the database is existing, overwrite as a new one without confirmation.");
            forceResetFlagOption.AddAlias("-f");
            command.AddOption(forceResetFlagOption);

            command.SetHandler((bool forceResetFlag) =>
            {
                string message = command.Description;
                Console.WriteLine(message);
                Console.WriteLine();

                //DatabaseFunction.ActivateDatabase(forceResetFlag);

                //Console.WriteLine($"Writing... '{Path.GetFullPath(Settings.Instance.DatabasePath)}'");
                //Database.Reset(Settings.Instance.DatabasePath);

                Console.WriteLine();
                Console.WriteLine($"{message}... done");
            }, forceResetFlagOption);

            return command;
        }
    }

    public static Command ExportCommand
    {
        get
        {
            Command command = new Command(
                name: "export",
                description: "Export database");

            var forceResetFlagOption = new Option<bool>(
                name: "--forced",
                description: "If the database is existing, overwrite as a new one without confirmation.");
            forceResetFlagOption.AddAlias("-f");
            command.AddOption(forceResetFlagOption);

            command.SetHandler((bool forceResetFlag) =>
            {
                string message = command.Description;
                Console.WriteLine(message);
                Console.WriteLine();

                //DatabaseFunction.ActivateDatabase(forceResetFlag);

                //Console.WriteLine($"Writing... '{Path.GetFullPath(Settings.Instance.DatabasePath)}'");
                //Database.Reset(Settings.Instance.DatabasePath);

                Console.WriteLine();
                Console.WriteLine($"{message}... done");
            }, forceResetFlagOption);

            return command;
        }
    }

    public static void CheckCurrentEntry(bool forceResetFlag)
    {
        Database database = Database.Load(Args.DatabasePath);
        if (database == null)
        {
            if (forceResetFlag)
            {
                Database.Reset(Args.DatabasePath);
                Console.WriteLine("db reset completed. try again");
                Environment.Exit(0);
            }

            Console.WriteLine("db is missing. please check");
            Environment.Exit(0);
        }

        Console.WriteLine("Current Database:");
        Console.WriteLine(database.ToJson());
    }
}
