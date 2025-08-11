using ToyRobotSimulator.Models;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class RobotTests
    {
        [Fact]
        public void Move_Valid()
        {
            var table = new TableTop();
            var robot = new ToyRobotSimulator.Robot.Robot(table);
            robot.Place(new Position(0, 0), Direction.NORTH);
            robot.Move();
            Assert.Equal("0,1,NORTH", robot.Report());
        }

        [Fact]
        public void Move_Invalid_ShouldIgnore()
        {
            var table = new TableTop();
            var robot = new ToyRobotSimulator.Robot.Robot(table);
            robot.Place(new Position(0, 0), Direction.SOUTH);
            robot.Move();
            Assert.Equal("0,0,SOUTH", robot.Report());
        }

        [Fact]
        public void Rotation_Works()
        {
            var table = new TableTop();
            var robot = new ToyRobotSimulator.Robot.Robot(table);
            robot.Place(new Position(1, 1), Direction.NORTH);
            robot.Left();
            Assert.Equal("1,1,WEST", robot.Report());
            robot.Right();
            Assert.Equal("1,1,NORTH", robot.Report());
        }
    }
}
