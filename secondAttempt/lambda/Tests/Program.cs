int[] test = {1, 34, -5, 12, 0, 500, 800, 489, -541, -8};
int negOrNull = ArrayOperations.Count(test, (int n) => n <= 0);
int even = ArrayOperations.Count(test, (int n) => n % 2 == 0);
Console.WriteLine($"Number of negative or null numbers : {negOrNull}");
Console.WriteLine($"Number of even numbers : {even}");


public static class ArrayOperations
{

    public static int Count(int[] input, Func<int, bool> func) 
    {
        int count = 0;
        foreach(int num in input)
        {
            if(func(num)) count++;
        }

        return count;
    }

}