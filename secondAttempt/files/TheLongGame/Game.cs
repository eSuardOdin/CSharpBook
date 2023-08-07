namespace TheLongGame;

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