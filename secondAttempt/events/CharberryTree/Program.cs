var charberryTree = new CharberryTree();
var notifier = new Notifier(charberryTree);
var harvester = new Harvester(charberryTree);
Console.WriteLine("Harvest season starts");
while(harvester.Fruits < 10)
{
    charberryTree.MaybeGrow();
}
Console.WriteLine("Ten fruits harvested !");


public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set;}
    public event Action<DateTime>? Ripened;

    public CharberryTree()
    {
        Ripe = false;
    }

    public void MaybeGrow()
    {
        if(_random.NextDouble() < 0.00000001 && !Ripe)
        {   
            Ripe = true;
            Ripened?.Invoke(DateTime.Now);
        }
    }
}



public class Notifier
{
    private CharberryTree Tree { get; set; }
    public Notifier(CharberryTree tree)
    {
        Tree = tree;
        tree.Ripened += HandleRipe;
    }

    private void HandleRipe(DateTime now)
    {
        Console.WriteLine($"A fruit riped on {now}");
    }
}



public class Harvester
{
    private CharberryTree Tree { get; set; }
    public int Fruits { get; private set; }
    public Harvester(CharberryTree tree)
    {
        Fruits = 0;
        Tree = tree;
        Tree.Ripened += Harvest;
    }
    private void Harvest(DateTime _)
    {
        Fruits++;
        Console.WriteLine("Fruit has been harvested, tree is now growing a new one.");
        Console.WriteLine($"Harvested fruits : {Fruits}");
        Console.WriteLine();
        Tree.Ripe = false;
    }
}