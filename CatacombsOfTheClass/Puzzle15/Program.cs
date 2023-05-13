
Puzzle puz = new Puzzle();

Console.WriteLine(puz.VoidPosition);












public class Puzzle 
{
    private int X {get;}
    public int[] Board {get; private set;}
    public int VoidPosition {get; private set;}

    public Puzzle() {
        var rand = new Random();
        X = 4;
        PopulateBoard(X*X);

        foreach (var i in Board!)
        {
            Console.Write(i + " | ");
        }
        
    }

    private void PopulateBoard(int length) {
        Logger.Log("Entering PopulateBoard()");
        Board = new int[length];
        // Get numbers to pick from
        List<int> numberList = new List<int>();
        string logList = "";
        for(int i = 0; i < length; i++) {
            numberList.Add(i);
            logList += i.ToString();
            if(i != length - 1) logList += " | ";
        }
        
        Logger.Log($"Number list [{logList}]");

        // Instance of random
        var rand = new Random();
        // Populate
        for(int i = 0; i < length; i++) {
            // Get random int from list and remove it
            int pick = numberList.ElementAt(rand.Next(numberList.Count()));
            numberList.Remove(pick);

            // Put it in Board and set VoidPosition if it's Zero
            Board[i] = pick;
            if(pick == 0) VoidPosition = i;
        }

    }
}

public static class Logger {

    public static void Log(string text) {
        // Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("-----log----");
        Console.WriteLine(text);
        Console.WriteLine("------------");
        Console.ResetColor();
    }
}