using System;

class Program
{
    static void Main(string[] args)
    {
        Item[] items = {
            new Item("audit", 120, "log"),
            new Item("notes", 20, "txt"),
            new Item("trace", 80, "log"),
            new Item("empty", 0, "log")
        };

        if (args.Length > 0 && args[0] == "empty")
            items = Array.Empty<Item>();
        if (args.Length > 0 && args[0] == "zero")
            items = new[] { new Item("zero", 0, "log") };
        if (args.Length > 0 && args[0] == "upper")
            items = new[] { new Item("x", 10, "LOG") };
        if (args.Length > 0 && args[0] == "custom")
            items = new[] {
                new Item("system", 50, "log"),
                new Item("config", 5, "ini"),
                new Item("app", 300, "log"),
                new Item("backup", 7, "Log")
            };

        Item[] selected = Selection.Apply(items);
        foreach (Item item in selected)
            Console.WriteLine(Formatter.Format(item));

        string summary = Summary.Build(selected);
        if (summary.Length > 0)
            Console.WriteLine(summary);
    }
}
