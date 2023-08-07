namespace TheLongGame;
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