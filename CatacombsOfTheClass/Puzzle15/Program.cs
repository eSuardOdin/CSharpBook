
Puzzle puz = new Puzzle();

// Console.WriteLine(puz.VoidPosition);
Display.DisplayBoard(3, puz.Board);










public class Puzzle 
{
    private int X {get;}
    public int[] Board {get; private set;}
    public int VoidPosition {get; private set;}

    public Puzzle() {
        var rand = new Random();
        X = 3;
        PopulateBoard(X*X);
    }

    /// <summary>
    /// Populates the board with shuffled values from 0 to length
    /// </summary>
    /// <param name="length">The length of the board</param>
    private void PopulateBoard(int length) {
        Logger.Log("Entering PopulateBoard()");
        Board = new int[length];
        // Get numbers to pick from
        List<int> numberList = new List<int>();
        for(int i = 0; i < length; i++) {
            numberList.Add(i);
        }
        
        // Instance of random
        var rand = new Random();
        // Populate
        for(int i = 0; i < length; i++) {
            // Get random int from list and remove it
            int pick = numberList.ElementAt(rand.Next(numberList.Count()-1));
            numberList.Remove(pick);

            // Put it in Board and set VoidPosition if it's Zero
            Board[i] = pick;
            if(pick == 0) VoidPosition = i;
        }
    }
}


public static class Display 
{
    public static void DisplayBoard(int x, int[] board) {
        // foreach (var item in board)
        // {
        //     Console.WriteLine(item);
        // }
        int currentIndex = 0;
        string line;
        string boardString = "";
        for(int i = 0; i <= 2 * x; i++) { // Y axis
            line = "";
            for(int j = 0; j <= 3*x; j++) {// X axis
                if(i % 2 == 0){
                    if(j%3 == 0) line += "o";
                    else         line += "-";
                } else {
                    if(j%3 == 0) line += "|";
                    // Print of numbers
                    else {
                        if(board[currentIndex] < 10) {
                            if (j % 3 == 2) {
                                line += board[currentIndex].ToString();
                                if(currentIndex + 1 != board.Length) currentIndex++;
                            }
                            else {
                                line += " ";
                            }
                        }  
                    }        
                }
            }
            boardString += line + "\n";
        }
        Console.WriteLine(boardString);
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