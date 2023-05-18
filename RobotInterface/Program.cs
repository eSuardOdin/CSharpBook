
Robot robot = new Robot(6);
string commandPrompt;
for (int i = 0; i < robot.Commands.Length; i++)
{
    Console.Write($"Enter command {i+1}/{robot.Commands.Length}: ");
    commandPrompt = Console.ReadLine();
    IRobotCommand command = commandPrompt switch 
    {
        "west" => new West(),
        "north" => new North(),
        "south" => new South(),
        "east" => new East(),
        "on" => new On(),
        "off" => new Off(),
        "_" => new DefaultCommand(),
    };
    robot.Commands[i] = command;
}


foreach (var cmd in robot.Commands)
{
    robot.Run(cmd);
}

public class Robot 
{
    public bool IsPowered {get; set;}
    public int X {get; set;}
    public int Y {get; set;}
    public IRobotCommand?[] Commands {get; set;}

    public Robot(int commandNb) 
    {
        IsPowered = false;
        X = Y = 0;
        Commands = new IRobotCommand[commandNb];
    }
    public void Run(IRobotCommand command) 
    {
        if(command.Run(this)) Console.WriteLine($"Robot new status\nPosition -> X:{X} Y:{Y}\nPowered -> {IsPowered}");
        else Console.WriteLine("Robot is not powered, cannot run command");
        
    }
}


public interface IRobotCommand
{
    public bool Run(Robot robot);
}

public class West : IRobotCommand 
{
    public bool Run(Robot robot)
    {
        if(robot.IsPowered) 
        {
            robot.X++;
            return true;
        }
        return false;
    }
}

public class East : IRobotCommand 
{
    public bool Run(Robot robot)
    {
        if(robot.IsPowered) 
        {
            robot.X--;
            return true;
        }
        return false;
    }
}

public class North : IRobotCommand 
{
    public bool Run(Robot robot)
    {
        if(robot.IsPowered) 
        {
            robot.Y++;
            return true;
        }
        return false;
    }
}

public class South : IRobotCommand 
{
    public bool Run(Robot robot)
    {
        if(robot.IsPowered) 
        {
            robot.Y--;
            return true;
        }
        return false;
    }
}

public class On : IRobotCommand
{
    public bool Run(Robot robot) 
    {
        robot.IsPowered = true;
        return true;    
    }
}

public class Off : IRobotCommand
{
    public bool Run(Robot robot) 
    {
        robot.IsPowered = false;
        return true;
    }
}

public class DefaultCommand : IRobotCommand
{
    public bool Run(Robot robot)
    {
        Console.WriteLine("Default command. Robot idle");
        return true;
    }
}