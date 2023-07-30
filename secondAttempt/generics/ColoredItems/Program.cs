var bow = new Bow();
var axe = new Axe();
var sword = new Sword();

var blueSword = new ColoredItem<Sword>(sword, ConsoleColor.DarkBlue);
var redBow = new ColoredItem<Bow>(bow, ConsoleColor.Red);
var greenAxe = new ColoredItem<Axe>(axe, ConsoleColor.Green);
var invisibleSword = new ColoredItem<Sword>(sword, ConsoleColor.White);
public class Bow {}
public class Sword {}
public class Axe {}

public class ColoredItem<T> 
{
    public T Item { get; set;}
    public ConsoleColor Color{ get; set;}


    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
        Display();
    }

    private void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine($"This {Item.GetType()} is {Color}");
    }
}