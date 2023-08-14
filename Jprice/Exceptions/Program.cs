// PAGE 169

Console.WriteLine("Before parsing");
Console.Write("How old are you: ");
string? input = Console.ReadLine();

try
{
    int age = int.Parse(input);
    Console.WriteLine($"You are {age} years old");
}

catch(FormatException)  // If you know the exception type
{
    Console.WriteLine("The input you entered is an invalid age format");
}
catch (Exception ex)   // If there is another (here, an overflow for instance)
{
    Console.WriteLine($"{ex.GetType} says \"{ex.Message}\"");
}


Console.WriteLine("After parsing");
