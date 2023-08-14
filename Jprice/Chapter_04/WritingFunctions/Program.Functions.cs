partial class Program
{
    /// <summary>
    /// Print a time table of a specified format
    /// </summary>
    /// <param name="number">The number's time table to print</param>
    /// <param name="size">The number of multiplications to perform</param>
    static void TimesTable(byte number, byte size = 12)
    {
        Console.WriteLine($"This is the {number} time table with {size} rows");
        for(int row = 1; row <= size; row++)
        {
            Console.WriteLine($"{row} x {number} = {row*number}");
        }
        Console.WriteLine("");
    }




    static int Factorial(int number)
    {
        if(number < 0)
        {
            throw new ArgumentException(message: $"The factorial function is defined for positive numbers. You provided {number}.");
        }
        else if (number == 0 )
        {
            return 1;
        }
        else
        {
            return number * Factorial(number - 1);
        }
    }
}


