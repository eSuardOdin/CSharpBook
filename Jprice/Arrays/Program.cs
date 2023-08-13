string[,] grid = new[,] 
{
    { "Hello", "Bonjour" },
    { "Good Morning", "Bonjour" },
    { "Hi", "Salut"},
};

Console.WriteLine($"Grid lower bound of first dimension is {grid.GetLowerBound(0)}");
Console.WriteLine($"Grid upp bound of first dimension is {grid.GetUpperBound(0)}");
Console.WriteLine($"Grid lower bound of second dimension is {grid.GetLowerBound(1)}");
Console.WriteLine($"Grid upp bound of second dimension is {grid.GetUpperBound(1)}");
