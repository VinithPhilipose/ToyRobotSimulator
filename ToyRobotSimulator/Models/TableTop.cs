using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Models
{
    public class TableTop
    {
        public int Width { get; }
        public int Height { get; }

        public TableTop(int width = 5, int height = 5)
        {
            if (width < 0 || height < 0) throw new ArgumentException("Width and Height must be positive");
            Width = width;
            Height = height;
        }

        public bool IsValid(Position p) => p.X >= 0 && p.X < Width && p.Y >= 0 && p.Y < Height;
    }
}
