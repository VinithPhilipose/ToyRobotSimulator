using ToyRobotSimulator.Models;
using ToyRobotSimulator.Robot;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class CommandProcessorTests
    {
        [Fact]
        public void FullScenario_MatchesExpected()
        {
            var table = new TableTop();
            var robot = new ToyRobotSimulator.Robot.Robot(table);
            var processor = new CommandProcessor(robot);

            processor.Execute("PLACE 1,2,EAST");
            processor.Execute("MOVE");
            processor.Execute("MOVE");
            processor.Execute("LEFT");
            processor.Execute("MOVE");
            var report = processor.Execute("REPORT");

            Assert.Equal("3,3,NORTH", report);
        }
    }
}
