
Console.WriteLine("");

Car car = new Car();
Train train = new Train();
var goW = new GoWest();
var goE = new GoEast();
var goN = new GoNorth();
var goS = new GoSouth();

car.Commands[0] = goW;
car.Commands[1] = goW;
car.Commands[2] = goW;
car.Commands[3] = goN;
car.Commands[4] = goN;

train.Commands[0] = goS;
train.Commands[1] = goS;
train.Commands[2] = goE;

car.Run();
train.Run();
public class Car : Vehicule
{
    public Car() : base("Tuuuuuut tuuuuuuut", 3, 5){}
    public override void Honking()
    {
        Console.WriteLine($"{this.Honk} [{this.X}, {this.Y}]");
    }
}

public class Train : Vehicule
{
    public Train() : base("Tchou tchou", 7, 3){}
    public override void Honking()
    {
        Console.WriteLine($"{this.Honk} im a train ! [{this.X}, {this.Y}]");
    }
}

public abstract class Vehicule
{
    protected string Honk { get; }
    public int Speed { get; }
    public int X { get; set; }
    public int Y { get; set; }
    protected int Count { get;}
    public ICommand[] Commands { get; set; }

    public Vehicule(string honk, int speed, int count)
    {
        this.Count = count;
        this.Honk = honk;
        this.Speed = speed;
        this.X = 0;
        this.Y = 0;
        this.Commands = new ICommand[Count];
    }
    public void Run()
    {
        foreach(var cmd in Commands)
        {
            cmd.Run(this);
            this.Honking();
        }
    }

    public abstract void Honking();
}


public interface ICommand
{
    public void Run(Vehicule vehicule);
}

public class GoEast : ICommand
{
    public void Run (Vehicule vehicule) { vehicule.X += vehicule.Speed; }
}
public class GoWest : ICommand
{
    public void Run (Vehicule vehicule) { vehicule.X -= vehicule.Speed; }
}
public class GoSouth : ICommand
{
    public void Run (Vehicule vehicule) { vehicule.Y -= vehicule.Speed; }
}
public class GoNorth : ICommand
{
    public void Run (Vehicule vehicule) { vehicule.Y += vehicule.Speed; }
}