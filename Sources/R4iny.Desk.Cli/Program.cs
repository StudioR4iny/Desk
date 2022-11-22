namespace R4iny.Desk.Cli;

internal class Program
{
    [STAThread] private static int Main(string[] args) => Args.Instance.Parse(args);
}
