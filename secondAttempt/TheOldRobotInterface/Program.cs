// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
/*
    Add robot commands and run it
*/
Robot rob = new Robot();
var on = new OnCommand();
var off = new OffCommand();
var west = new GoWest();   
var east = new GoEast();
var north = new GoNorth();
var south = new GoSouth();

rob.Commands[0] = off;
rob.Commands[1] = on;
rob.Commands[2] = east;
rob.Commands[3] = east;
rob.Commands[4] = off;
rob.Commands[5] = south;
rob.Commands[6] = on;
rob.Commands[7] = south;



rob.Run();



public class Robot 
{
    public int X {get; set;}
    public int Y {get; set;}
    public bool IsPowered {get; set;}
    public IRobotCommand?[] Commands = new IRobotCommand?[8];
    

    public void Run() 
    {
        foreach (var command in Commands)
        {
            command.Run(this);
            Console.WriteLine($"[{X} {Y} power: {(IsPowered ? "On" : "Off")}]");
        }
    }
}

public interface IRobotCommand
{
    public void Run(Robot robot);
}

public class OnCommand :IRobotCommand
{
    public void Run(Robot robot) { robot.IsPowered = true; }
}
public class OffCommand :IRobotCommand
{
    public void Run(Robot robot) { robot.IsPowered = false; }
}


public class GoSouth :IRobotCommand
{
    public void Run(Robot robot) 
    {
        if (robot.IsPowered) robot.Y--;
    }
}

public class GoNorth :IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y++; }
}

public class GoEast :IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X++; }
}

public class GoWest :IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X--; }
}