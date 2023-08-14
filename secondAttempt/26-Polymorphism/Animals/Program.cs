var sheep = new Sheep();
sheep.Battlecry();


public abstract class Animal
{
    protected bool IsCarnivor { get; set; }
    public string Name { get; set; }

    public Animal(bool isCarnivor, string name)
    {
        IsCarnivor = isCarnivor;
        Name = name;
    }

    public abstract void Battlecry();

    protected string Food() => IsCarnivor ? "Flesh" : "Leaf";
} 


public class Sheep : Animal
{
    public Sheep() : base(false, "Sheep") {}
    public override void Battlecry() 
    {
        Console.WriteLine($"I'm a sheep and I eat {this.Food()}");
    }
}