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
            if (string.IsNullOrWhiteSpace(line)) return null;
            var tokens = line.Trim().Split(' ', 2);
            var cmd = tokens[0].ToUpperInvariant();

            switch (cmd)
            {
                case "PLACE": return HandlePlace(tokens.Length > 1 ? tokens[1] : null);
                case "MOVE": _robot.Move(); break;
                case "LEFT": _robot.Left(); break;
                case "RIGHT": _robot.Right(); break;
                case "REPORT":
                    var r = _robot.Report();
                    Console.WriteLine("Output:"+ r);
                    return r;
            }
            return null;
        }

        private string HandlePlace(string args)
        {
            if (string.IsNullOrWhiteSpace(args)) return null;
            var parts = args.Split(',');
            if (parts.Length != 3) return null;
            if (!int.TryParse(parts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out var x)) return null;
            if (!int.TryParse(parts[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out var y)) return null;
            if (!DirectionExtensions.TryParse(parts[2], out var dir)) return null;

            return _robot.Place(new Position(x, y), dir) ? "PLACED" : null;
        }
    }
    
}
