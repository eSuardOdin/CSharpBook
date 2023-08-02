
// Puzzle puz = new Puzzle();


// while(true) {
//     Display.DisplayBoard(puz.X, puz.Board);
//     Display.DisplayWellPlaced(puz.ReturnWellPlaced());
//     puz.MoveZero(InputHandler.GetPlayerMove());
// }
Game game = new Game();


/// <summary>
/// Will create puzzle based on difficulty inputed, check if win and keep track of number of plays
/// </summary>
public class Game {

    public int MovesPlayed {get; private set;}
    public Game() {
        MovesPlayed = 0;
        Puzzle puz = new Puzzle(GetSquareLength());
        Run(puz);
    }



    private bool CheckIfWin(int[] board, List<int> wellPlaced) {
        return board.Length - 1 == wellPlaced.Count();
    }
    private int GetSquareLength() {
        Console.Write("Please enter a length for the square sides (2-9) -> ");
        int res;
        do {
            while(!int.TryParse(Console.ReadLine(), out res)) {
                Console.Write("Must be a number : ");
            }
            if(res < 2 || res > 9) Console.WriteLine("Must be comprised between 2 and 9");
        } while(res < 2 || res > 9);
        return res;
    }

    public void Run(Puzzle puz) {
        do {
            Display.DisplayBoard(puz.X, puz.Board);
            Display.DisplayWellPlaced(puz.ReturnWellPlaced());
            Display.DisplayMoves(MovesPlayed);
            puz.MoveZero(InputHandler.GetPlayerMove());
            MovesPlayed++;
        } while(!CheckIfWin(puz.Board, puz.ReturnWellPlaced()));
        Display.DisplayBoard(puz.X, puz.Board);
        Display.DisplayWellPlaced(puz.ReturnWellPlaced());
        Console.WriteLine($"You won with {MovesPlayed} moves !");
    }

}




public class Puzzle 
{
    public int X {get;}
    public int[] Board {get; private set;}
    public int VoidPosition {get; private set;}

    public Puzzle(int x) {
        var rand = new Random();
        X = x; // Change to allow player 2² to 9²
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

    public void MoveZero(string move) {
        int tmp;
        if(move == "up" && (VoidPosition - X) >= 0) {
            tmp = Board[VoidPosition - X];
            Board[VoidPosition - X] = 0;
            Board[VoidPosition] = tmp;
            VoidPosition = VoidPosition - X;
        }
        else if(move == "down" && (VoidPosition + X) < Board.Length) {
            tmp = Board[VoidPosition + X];
            Board[VoidPosition + X] = 0;
            Board[VoidPosition] = tmp;
            VoidPosition = VoidPosition + X;
        }
        else if(move == "left" && (VoidPosition - 1) % X != X-1 && (VoidPosition - 1) != -1) {
            tmp = Board[VoidPosition - 1];
            Board[VoidPosition - 1] = 0;
            Board[VoidPosition] = tmp;
            VoidPosition = VoidPosition - 1;
        }
        else if(move == "right" && (VoidPosition + 1) % X != 0 && (VoidPosition + 1) != Board.Length) {
            tmp = Board[VoidPosition + 1];
            Board[VoidPosition + 1] = 0;
            Board[VoidPosition] = tmp;
            VoidPosition = VoidPosition + 1;
        }
    }


    public List<int> ReturnWellPlaced(){
        List<int> res = new List<int>();
        for (int i = 0; i < Board.Length; i++)
        {
            if(Board[i] == i+1) res.Add(Board[i]);
        }
        return res;
    }
}

public static class InputHandler {
    public static string GetPlayerMove() {
        ConsoleKeyInfo key;
        do {
            key = Console.ReadKey();
        } while(
            key.Key != ConsoleKey.RightArrow &&
            key.Key != ConsoleKey.LeftArrow &&
            key.Key != ConsoleKey.UpArrow &&
            key.Key != ConsoleKey.DownArrow
        );
        
        switch(key.Key) {
            case ConsoleKey.RightArrow:
                return "right";
            case ConsoleKey.LeftArrow:
                return "left";
            case ConsoleKey.UpArrow:
                return "up";
            case ConsoleKey.DownArrow:
                return "down";
        }
        return ""; // To improve
    }
}


public static class Display 
{
    public static void DisplayBoard(int x, int[] board) {
        Console.Clear();
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
                        // If the number is 1 char long
                        if(board[currentIndex] < 10) {
                            if (j % 3 == 2) { // If we're on number spot
                                if (board[currentIndex] != 0) line += board[currentIndex].ToString();
                                else                          line += " ";
                                if(currentIndex + 1 != board.Length) currentIndex++;
                            }
                            else line += " ";
                            
                        } else if (board[currentIndex] >= 10) {
                            if (j % 3 == 1) { // If we're on leftmost char of number
                                line += board[currentIndex].ToString()[0];
                            } else if (j % 3 == 2) { // If we're on rigthmost char
                                line += board[currentIndex].ToString()[1];
                                if(currentIndex + 1 != board.Length) currentIndex++;
                            } 
                            else line += " ";
                        }
                    }        
                }
            }
            boardString += line + "\n";
        }
        Console.WriteLine(boardString);
    }

    public static void DisplayWellPlaced(List<int> list) {
        if (list.Count() > 0) {
            string str = "Well placed numbers : [ ";
            foreach (int num in list)
            {
                str += num.ToString() + " ";
            }
            str+= "]";
            Console.WriteLine(str);
        }
        else {
            Console.WriteLine("No numbers well placed.");
        }
    }

    public static void DisplayMoves(int moves) {
        Console.WriteLine($"Moves played : {moves}");
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