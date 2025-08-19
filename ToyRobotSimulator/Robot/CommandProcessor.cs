using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Robot
{
    public class CommandProcessor
    {
        private readonly Robot _robot;

        public CommandProcessor(Robot robot) => _robot = robot;

        public string Execute(string line)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(line))
                    throw new ArgumentException("Input line cannot be empty.");
                var tokens = line.Trim().Split(' ', 2);
                var cmd = tokens[0].ToUpperInvariant();

                switch (cmd)
                {
                    case "PLACE": return HandlePlace(tokens.Length > 1 ? tokens[1] : string.Empty);
                    case "MOVE": _robot.Move(); break;
                    case "LEFT": _robot.Left(); break;
                    case "RIGHT": _robot.Right(); break;
                    case "REPORT":
                        var r = _robot.Report();
                        Console.WriteLine("Output:" + r);
                        return r;
                }
                return String.Empty;
            }

            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return String.Empty;
        }

        private string HandlePlace(string args)
        {
            try
            {
                if (string.IsNullOrEmpty(args))
                    throw new ArgumentException("Place command cannot be empty.");
                var parts = args.Split(',');
                if (parts.Length != 3)
                    throw new ArgumentException("Incorrect part length.");
                if (!int.TryParse(parts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out var x)) return String.Empty;
                if (!int.TryParse(parts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out var y)) return String.Empty;
                if (!DirectionExtensions.TryParse(parts[2], out var dir))
                    throw new ArgumentException("Invalid Direction");

                return _robot.Place(new Position(x, y), dir) ? "PLACED" : "Not PLACED";
            }

            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
                return String.Empty;
            }
            
        }
    }
    
}
