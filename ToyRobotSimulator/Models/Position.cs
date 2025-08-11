using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Models
{
    public readonly struct Position
    {
        public int X { get; }
        public int Y { get; }
        public Position(int x, int y) => (X, Y) = (x, y);
        public Position Translate(int dx, int dy) => new Position(X + dx, Y + dy);
        public override string ToString() => $"{X},{Y}";
    }
}
