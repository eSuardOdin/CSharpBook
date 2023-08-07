/*
    The user enters his name, if not exists, create a file named as [username].txt

    The program must read the number of keys typed by user and save it in this file when exiting
    (or append them if any score already exists)

    It displays the top 3 scores and usernames associated with the users score
*/


/* Console.Write("Please enter your name : ");
var name = Console.ReadLine();
while (string.IsNullOrEmpty(name));
{
    Console.Write("Please enter a valid name : ");
    name = Console.ReadLine();
} 

if(!File.Exists("")) { File.Create()} */

Game game = new("./Scores");
SaveManager sm = new("./Scores");
Player player = sm.LoadPlayer("valid");
Console.WriteLine($"{player.Name} {player.Score}");
Console.Write("Entre un score pour le test : ");
int test;
Int32.TryParse(Console.ReadLine(), out test);
player.Score = test;
sm.SavePlayer(player);
Console.WriteLine($"UPDATE : {player.Name} {player.Score}");

public class Player
{
    public string Name { get; private set; }
    public int Score { get; /*private*/ set; }

    public Player(string name, int score)
    {
        Name = name;
        Score = score;
    }
}

public class Game
{
    private List<Player> Players { get; set; }
    private Player CurrentPlayer { get; set;}
    private string ScorePath { get; set; }
    public Game(string path)
    {
        Players = new List<Player>();
        ScorePath = path;
        if(!Directory.Exists(ScorePath)) { Directory.CreateDirectory(ScorePath); }
        foreach(var file in Directory.EnumerateFiles(ScorePath))
        {
            // Get player name
            string name = Path.GetFileNameWithoutExtension(file);
            // Get Player score, if no score, delete file.
            int score;
            if (Int32.TryParse(File.ReadAllText(file), out score))
            {
                Player player = new Player(name, score);
                Players.Add(player);
                Console.WriteLine($"Player : {player.Name}");
                Console.WriteLine($"Score : {player.Score}");
            }
            else
            {
                Console.WriteLine($"File '{file}' not in a valid format, deleting it");
                File.Delete(file);
            }          
        }

    }
}


public class SaveManager
{
    private string SavePath { get; set; }
    public SaveManager(string path)
    {
        SavePath = path;
        int score;
        // Delete invalid files in folder
        foreach(var fileName in Directory.EnumerateFiles(SavePath))
        {
           if (!Int32.TryParse(File.ReadAllText(fileName), out score)) { File.Delete(fileName); }
        }
    }

    public bool PlayerExists(string name)
    {
        foreach(var file in Directory.EnumerateFiles(SavePath))
        {
            if(Path.GetFileNameWithoutExtension(file) == name) { return true; }

        }
        return false;
    }

    public Player LoadPlayer(string name)
    {
        foreach(var file in Directory.EnumerateFiles(SavePath))
        {
            if(Path.GetFileNameWithoutExtension(file) == name) 
            {
                int score;
                if (Int32.TryParse(File.ReadAllText(file), out score))
                {
                    Player player = new Player(name, score);
                    return player;
                }
            }
        }
        return null;
    }

    public void SavePlayer(Player player)
    {
        File.WriteAllText($"{SavePath}/{player.Name}.txt", player.Score.ToString());
    }
}