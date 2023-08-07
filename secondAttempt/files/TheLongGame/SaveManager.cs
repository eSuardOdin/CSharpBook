namespace TheLongGame;
public class SaveManager
{
    private string SavePath { get; set; }
    
    public SaveManager(string path)
    {
        SavePath = path;
        // Create dir if not exists
        if(!Directory.Exists(SavePath)) { Directory.CreateDirectory(SavePath); }
        int score;
        // Delete invalid files in folder
        foreach(var fileName in Directory.EnumerateFiles(SavePath))
        {
           if (!Int32.TryParse(File.ReadAllText(fileName), out score)) { File.Delete(fileName); }
        }
    }

    /// <summary>
    /// Checks if a player exists with this name
    /// </summary>
    /// <param name="name">Name to check</param>
    /// <returns>True if player exists</returns>
    public bool PlayerExists(string name)
    {
        foreach(var file in Directory.EnumerateFiles(SavePath))
        {
            if(Path.GetFileNameWithoutExtension(file) == name) { return true; }

        }
        return false;
    }

    /// <summary>
    /// Loads a player with the name specified on param. PS :
    /// This function is never supposed to return null, we have to check
    /// if player exists before calling it (to improve) 
    /// </summary>
    /// <param name="name">Name of the player to return</param>
    /// <returns>A player object</returns>
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

    /// <summary>
    /// Saves a player file
    /// </summary>
    /// <param name="player">The player whose score is being saved</param>
    public void SavePlayer(Player player)
    {
        File.WriteAllText($"{SavePath}/{player.Name}.txt", player.Score.ToString());
    }

    /// <summary>
    /// Checks if a text is valid to create a file
    /// </summary>
    /// <param name="text">Text to test</param>
    /// <returns>True if valid</returns>
    public bool IsStringValid(string text)
    {
        // If longer than 32 char, return false
        if(text.Length > 32) { return false; }
        // If null or empty, return false
        if(string.IsNullOrEmpty(text)) { return false; }
        // Not allowed characters
        string notAllowed = @" <>@{}[]#&()/|*-+$%~\";
        // If any forbidden char, return false
        foreach(char c in notAllowed)
        {
            if(text.Contains(c)) { return false; }
        }
        return true;
    }
}