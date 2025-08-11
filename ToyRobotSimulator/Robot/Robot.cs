using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Robot
{
    public class Robot
    {
        private readonly TableTop _table;
        private Position _position;
        private Direction _direction;
        public bool IsPlaced { get; private set; }

        public Robot(TableTop table) => _table = table ?? throw new ArgumentNullException(nameof(table));

        public bool Place(Position pos, Direction dir)
        {
            if (!_table.IsValid(pos)) return false;
            _position = pos;
            _direction = dir;
            IsPlaced = true;
            return true;
        }

        public void Move()
        {
            if (!IsPlaced) return;
            var (dx, dy) = _direction.Movement();
            var newPos = _position.Translate(dx, dy);
            if (_table.IsValid(newPos)) _position = newPos;
        }

        public void Left()
        {
            if (!IsPlaced) return;
            _direction = _direction.Left();
        }

        public void Right()
        {
            if (!IsPlaced) return;
            _direction = _direction.Right();
        }

        public string Report() => IsPlaced ? $"{_position.X},{_position.Y},{_direction}" : "Robot not placed";
    }
}
