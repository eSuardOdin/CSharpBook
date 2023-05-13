


Game game = new Game();
while (true)
{
    game.PlayRound();
}





public class Game {

    public Player Player1{get;} 
    public Player Player2{get;}
    private int P1Score {get; set;} 
    private int P2Score {get; set;} 
    private int DrawScore {get; set;} 
    private int RoundNumber {get; set;}
    private List<string> History {get;}

    public Game() {
        History = new List<string>();
        // Characters creation
        (string p1,string p2) = CreatePlayers();
        Player1 = new Player(p1);
        Player2 = new Player(p2);
        RoundNumber = 1;
        P1Score = 0;
        P2Score = 0;
        DrawScore = 0;
    }

    private (string p1, string p2) CreatePlayers() {
        string p1, p2;
        Console.Clear();
        do
        {
            Console.Write("Player 1, enter your name : ");
            p1 = Console.ReadLine();
        } while (p1 == null || p1 == "");
        Console.Clear();
        do
        {
            Console.Write("Player 2, enter your name : ");
            p2 = Console.ReadLine();
            if(p1==p2) Console.WriteLine("Cannot be named like Player 1");
        } while (p2 == null || p2 == "" || p1 == p2);
        return (p1, p2);
    }

    public void PlayRound() {
        Console.Clear();
        Round round = new Round(RoundNumber);
        string p1Move = round.GetPlayerMove(Player1);
        string p2Move = round.GetPlayerMove(Player2);
        int winner = round.GetWinner(p1Move, p2Move);
        string result;
        
        Console.WriteLine("--------------------");
        Console.WriteLine($"      Round {RoundNumber}");
        Console.WriteLine("--------------------");
        
        switch (winner)
        {
            case 1:
                P1Score++;
                result = $"{Player1.Name} won round n°{RoundNumber} with {p1Move} VS {p2Move}";
                break;
            case 2:
                P2Score++;
                result = $"{Player2.Name} won round n°{RoundNumber} with {p2Move} VS {p1Move}";
                break;
            default:
                DrawScore++;
                result = $"{Player1.Name} and {Player2.Name} draws on round n°{RoundNumber} with {p1Move}";
                break;
        }
        result += $"\n- {Player1.Name} : {P1Score}\n- {Player2.Name} : {P2Score}\n- Draws : {DrawScore}";
        Console.WriteLine(result);
        Console.Write("Type enter to continue...");
        Console.ReadLine();
        RoundNumber++;
        History.Add(result);
    }

}

public class Round {
    public int Number {get;}

    public Round(int number) {
        Number = number;
    }


    /// <summary>
    /// Wait for player input and returns its move
    /// </summary>
    /// <param name="player">The players wich turn it is</param>
    /// <returns>Move played</returns>
    public string GetPlayerMove(Player player) {
        Console.Clear();
        string choice;
        while(true)
        {
            Console.WriteLine("r : Rock");
            Console.WriteLine("p : Paper");
            Console.WriteLine("s : Scissors");
            Console.Write($"{player.Name}, make a move : ");
            choice = Console.ReadLine();
            if (choice != "r" && choice != "p" && choice != "s") Console.WriteLine("\n\n----------\n!!!!!!!!!!\nIncorrect input !\n!!!!!!!!!!\n----------\n");
            else {
                switch (choice)
                {
                    case "r":
                        return "Rock";
                        break;
                    case "p":
                        return "Paper";
                        break;
                    case "s":
                        return "Scissors";
                        break;
                }
            }
            
        } 
    }
    /// <summary>
    /// Returns the winner of the round as integer 
    /// </summary>
    /// <param name="p1Move">Move of player 1</param>
    /// <param name="p2Move">Move of player 2</param>
    /// <returns>Winner (1 for p1, 2 for p2, 0 for draw)</returns>
    public int GetWinner(string p1Move, string p2Move) {
        if(p1Move == p2Move) return 0;
        if(p1Move == "Rock")    return (p2Move == "Scissors") ? 1 : 2;
        if(p1Move == "Paper")    return (p2Move == "Rock") ? 1 : 2; 
        if(p1Move == "Scissors")    return (p2Move == "Paper") ? 1 : 2; 
        return -1;
    }
}

// Just a placeholder for player's name
public class Player {
    public string Name {get;}

    public Player(string name) {
        Name = name;
    }
}
