Console.WriteLine("Multi dimensionnal array :");

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


for(int row = grid.GetLowerBound(0); row <= grid.GetUpperBound(0); row++)
{
    for(int col = grid.GetLowerBound(1); col <= grid.GetUpperBound(1); col++)
    {
        Console.WriteLine($"Row: {row}, Column {col} : '{grid[row, col]}'");
    }
}

Console.WriteLine("");



Console.WriteLine("Jagged array :");

string [][] jagged = new[] // array of string arrays
{
    new[] {"Alpha", "Beta", "Gamma"},
    new[] {"Anne", "Ben", "Charlie", "Doug"},
    new[] {"Aardvark", "Bear"}
};
Console.WriteLine($"Upper bound of array of arrays is: {jagged.GetUpperBound(0)}");

for (int i = 0; i <= jagged.GetUpperBound(0); i++)
{
    Console.WriteLine($"Upper bound of array n°{i} is: {jagged[i].GetUpperBound(0)}");
}

Console.WriteLine("");


Console.WriteLine("Pattern matching :");

int[] sequentialNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int[] oneTwoNumbers = new int[] { 1, 2 };
int[] oneTwoTenNumbers = new int[] { 1, 2, 10 };
int[] oneTwoThreeTenNumbers = new int[] { 1, 2, 3, 10 };
int[] primeNumbers = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
int[] fibonacciNumbers = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55,
89 };
int[] emptyNumbers = new int[] { };
int[] threeNumbers = new int[] { 9, 7, 5 };
int[] sixNumbers = new int[] { 9, 7, 5, 4, 2, 10 };

Console.WriteLine($"{nameof(sequentialNumbers)} : {CheckSwitch(sequentialNumbers)}");
Console.WriteLine($"{nameof(oneTwoNumbers)}: {CheckSwitch(oneTwoNumbers)}");
Console.WriteLine($"{nameof(oneTwoTenNumbers)}: {CheckSwitch(oneTwoTenNumbers)}");
Console.WriteLine($"{nameof(oneTwoThreeTenNumbers)}: {CheckSwitch(oneTwoThreeTenNumbers)}");
Console.WriteLine($"{nameof(primeNumbers)}: {CheckSwitch(primeNumbers)}");
Console.WriteLine($"{nameof(fibonacciNumbers)}: {CheckSwitch(fibonacciNumbers)}");
Console.WriteLine($"{nameof(emptyNumbers)}: {CheckSwitch(emptyNumbers)}");
Console.WriteLine($"{nameof(threeNumbers)}: {CheckSwitch(threeNumbers)}");
Console.WriteLine($"{nameof(sixNumbers)}: {CheckSwitch(sixNumbers)}");
static string CheckSwitch(int[] values) => values switch
{
 [] => "Empty array",
 [1, 2, _, 10] => "Contains 1, 2, any single number, 10.",
 [1, 2, .., 10] => "Contains 1, 2, any range including empty, 10.",
 [1, 2] => "Contains 1 then 2.",
 [int item1, int item2, int item3] =>
 $"Contains {item1} then {item2} then {item3}.",
 
 [0, _] => "Starts with 0, then one other number.",
 [0, ..] => "Starts with 0, then any range of numbers.",
 [2, .. int[] others] => $"Starts with 2, then {others.Length} more numbers.",
 [..] => "Any items in any order.",
};