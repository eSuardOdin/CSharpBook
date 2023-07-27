/*

    Define a new arrow class with fields for arrowheads type
    fletching type and length.
    Allow a user to pick each and then create a new arrow instance.
    Add a GetCost method that returns a float

    arrowheads : 
        -steel : 10 g
        -wood : 3g
        -obsidian 5g
    fletching :
        -plastic : 10g
        -turkey feathers : 5g
        -goose feathers : 3g
    length : 0.05 g/cm (60-100)

*/

int ChooseShaftLengt() 
{
    int choice = -1;
    while(choice < 60 || choice > 100) 
    {
        Console.Write($"Please choose the shaft length (60-100) : ");
        while(!int.TryParse(Console.ReadLine(), out choice)) 
        {
            Console.WriteLine("Please choose a valid length with a number !");
        }
        if(choice < 60 || choice > 100)
        {
            Console.WriteLine("Choose between 60-100 !");
        }
    }
    return choice;
}


T ListValues<T>()
{
    Console.WriteLine($"Choose the {typeof(T)}");
    int nbValues = Enum.GetValues(typeof(T)).Length;
    foreach(var value in Enum.GetValues(typeof(T)))
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


Arrow arrow = new Arrow (ChooseShaftLengt(), ListValues<Fletching>(), ListValues<Arrowhead>());
Console.WriteLine(arrow.GetCost());

public class Arrow 
{
    public int length;
    public Fletching fletching;
    public Arrowhead arrowhead;

    public Arrow(int length, Fletching fletching, Arrowhead arrowhead) 
    {
        this.length = length;
        this.fletching = fletching;
        this.arrowhead = arrowhead;
    } 

    public float GetCost() 
    {
        float price = 0;
        price += length * 0.05f;
        switch (this.fletching)
        {
            case Fletching.plastic:
                price += 10f;
                break;
            case Fletching.goose:
                price += 3f;
                break;
            case Fletching.turkey:
                price += 5f;
                break;
        }
        switch (this.arrowhead)
        {
            case Arrowhead.wood:
                price += 3f;
                break;
            case  Arrowhead.obsidian:
                price += 5f;
                break;
            case Arrowhead.steel:
                price += 10f;
                break;
        }
        return price;
    }

}

public enum Fletching { plastic, turkey, goose }
public enum Arrowhead { steel, obsidian, wood } 