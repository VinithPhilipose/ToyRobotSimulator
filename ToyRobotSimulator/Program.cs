using ToyRobotSimulator.Models;
using ToyRobotSimulator.Robot;

var table = new TableTop(5, 5);
var robot = new Robot(table);
var processor = new CommandProcessor(robot);

if (args.Length > 0 && File.Exists(args[0]))
{
    foreach (var line in File.ReadLines(args[0]))
        processor.Execute(line);
}
else
{
    Console.WriteLine("Toy Robot Simulator — type commands (Ctrl+C to exit):");
    while (true)
    {
        Console.Write("> ");
        var line = Console.ReadLine();
        if (line == null) break;
        processor.Execute(line);
    }
}