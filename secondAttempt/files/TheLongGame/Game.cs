namespace TheLongGame;

public class Game
{
    // private List<Player> Players { get; set; }
    private Player CurrentPlayer { get; set;}
    private SaveManager GameSaveManager { get; set; }
    private string ScorePath { get; set; }
    public Game(string path)
    {
        Console.Clear();
        // Players = new List<Player>();
        ScorePath = path;
        GameSaveManager = new SaveManager(ScorePath);
        CurrentPlayer = GetCurrentPlayer();
        GameLoop();
    }

    
    /// <summary>
    /// Asks the user to provide a name, if a filename
    /// already exists, load the player, else, creates
    /// a new one.
    /// </summary>
    /// <returns>The current player</returns>
    private Player GetCurrentPlayer()
    {

        string name = null;
        while(string.IsNullOrEmpty(name))
        {
            Console.Write("Please enter your player name : ");
            name = Console.ReadLine();
            if(!GameSaveManager.IsStringValid(name)) 
            {
                Console.WriteLine("The name must not be null or contain special chars. Max length : 32 char.");
                name = "";
            }
        }

        // Name is now valid, checking if the player already exists.
        if(GameSaveManager.PlayerExists(name))
        {
            return GameSaveManager.LoadPlayer(name);
        }
        else
        {
            return new Player(name, 0);
        }

    }

    /// <summary>
    /// Reads the keys typed before any key is Enter
    /// returns the number of keys typed
    /// </summary>
    /// <returns></returns>
    private int KeysTyping()
    {
        int typed = 0;
        ConsoleKeyInfo test;
        do
        {
            test = Console.ReadKey();
            // Console.WriteLine($"{test.Key} typed");
            if(test.Key != ConsoleKey.Enter) { typed++; }
        } while(test.Key != ConsoleKey.Enter);
        return typed;
    }


    private void GameLoop()
    {
        Console.WriteLine($"Welcome {CurrentPlayer.Name}");
        Console.WriteLine($"Current score : {CurrentPlayer.Score}");
        CurrentPlayer.AddToScore(KeysTyping());
        Console.WriteLine($"Great job {CurrentPlayer.Name}, your score is now {CurrentPlayer.Score} !");
        GameSaveManager.SavePlayer(CurrentPlayer);
    }
}