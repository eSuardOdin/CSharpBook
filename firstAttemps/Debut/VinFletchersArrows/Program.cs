using System.Diagnostics;

// Arrowhead arrowhead = ListValues<Arrowhead>();
// Fletching fletching = ListValues<Fletching>();
// int shaft = ChooseShaftLength();

Arrows arrow = Arrows.MakeEliteArrow();

System.Console.WriteLine(arrow.Arrowhead);
System.Console.WriteLine(arrow.Fletching);
System.Console.WriteLine(arrow.Shaft);




int ChooseShaftLength()
{
    int distance = -1;
    while (distance < 60 || distance > 100)
    {
        Console.Write($"Please choose the shaft length (60-100) : ");
        while (!int.TryParse(Console.ReadLine(), out distance))
        {
            Console.Write("Please enter a numeric value (60-100) : ");
        }
        if (distance < 60 || distance > 100)
        {
            Console.WriteLine("Value must be between 60 and 100.");
        }
    }
    return distance;
}

T ListValues<T>()
{
    Console.WriteLine($"Choose the {typeof(T)}");
    int nbValues = Enum.GetValues(typeof(T)).Length;
    foreach (var value in Enum.GetValues(typeof(T)))
    {
        Console.WriteLine($"- {value}\t\t{(int)value}");
    }
    int choice = -1;
    while (choice < 0 || choice > nbValues - 1)
    {
        Console.Write("Please chose a value with it's index : ");
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.Write("Please, enter a numeric value : ");
        }
    }
    Console.WriteLine();
    return (T)Enum.ToObject(typeof(T), choice);
}


class Arrows
{
    private Arrowhead _arrowhead;
    public Arrowhead GetArrowhead() => _arrowhead;
    private Fletching _fletching;
    public Fletching GetFletching() => _fletching;
    private int _shaft;
    public Arrowhead Arrowhead {get => _arrowhead; set => _arrowhead = value;}
    public Fletching Fletching {get => _fletching; set => _fletching = value;}
    public int Shaft {get => _shaft; set => _shaft = value;}
    public int GetShaft() => _shaft;
    
    public Arrows(Arrowhead arrowhead, Fletching fletching, int shaft)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _shaft = shaft;
    }
    public static Arrows MakeEliteArrow() => new Arrows(Arrowhead.steel, Fletching.plastic, 100);
    public void GetCost()
    {
        float price = 0;
        switch(_arrowhead)
        {
            case Arrowhead.steel:
                price += 10;
                break;
            case Arrowhead.wood:
                price += 3;
                break;
            case Arrowhead.obisdian:
                price += 5;
                break;
        }
        switch(_fletching)
        {
            case Fletching.plastic:
                price += 10;
                break;
            case Fletching.goose:
                price += 3;
                break;
            case Fletching.turkey:
                price += 5;
                break;
        }
        price += (float)0.05 * _shaft;
        Console.WriteLine($"Arrow costs {price} gold");
    }
}

enum Arrowhead
{
    steel,
    wood,
    obisdian
}
enum Fletching
{
    plastic,
    turkey,
    goose
}


