using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Models
{
    public static class DirectionExtensions
    {
        public static Direction Left(this Direction d) => (Direction)(((int)d + 3) % 4);
        public static Direction Right(this Direction d) => (Direction)(((int)d + 1) % 4);

        /*Enums have underlying integers. We assume:
        Direction.NORTH = 0
        Direction.EAST = 1
        Direction.SOUTH = 2
        Direction.WEST = 3*/
        public static (int dx, int dy) Movement(this Direction d) => d switch
        {
            Direction.NORTH => (0, 1),
            Direction.EAST => (1, 0),
            Direction.SOUTH => (0, -1),
            Direction.WEST => (-1, 0),
            _ => (0, 0)
        };

        public static bool TryParse(string s, out Direction dir)
        {
            dir = default;
            return Enum.TryParse(s.Trim(), true, out dir);
        }
    }
}
