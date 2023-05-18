Robot robot = new Robot();
for(int i = 0; i < robot.Commands.Length; i++) {
    Console.Write("Enter next command : ");
    string? input = Console.ReadLine();
    RobotCommand? command = input switch
    {
        "on" => new OnRobot(),
        "off" => new OffRobot(),
        "west" => new WestCommand(),
        "east" => new EastCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        _ => new OffRobot(),
    };
    robot.Commands[i] = command;
}
robot.Run();




public class Robot
{
    public int X {get; set;}
    public int Y {get; set;}
    public bool IsPowered {get;set;}
    public RobotCommand?[] Commands {get;} = new RobotCommand?[3];

    public void Run() {
        foreach(RobotCommand? command in Commands) {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}


public abstract class RobotCommand {
    public abstract void Run(Robot robot);
}

public class SouthCommand : RobotCommand {
    public override void Run(Robot robot)
    {
        if(robot.IsPowered) robot.Y++;
    }
}

public class NorthCommand : RobotCommand {
    public override void Run(Robot robot)
    {
        if(robot.IsPowered) robot.Y--;
    }
}

public class WestCommand : RobotCommand {
    public override void Run(Robot robot)
    {
        if(robot.IsPowered) robot.X--;
    }
}

    public class EastCommand : RobotCommand {
    public override void Run(Robot robot)
    {
        if(robot.IsPowered) robot.X++;
    }
}

public class OffRobot : RobotCommand {
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class OnRobot : RobotCommand {
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

