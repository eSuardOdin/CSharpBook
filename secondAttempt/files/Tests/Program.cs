// --------------------------------------------------
// WriteAllText / ReadAllText methods
/*
if (File.Exists("./message"))
{
    string previous = File.ReadAllText("./message");
    Console.WriteLine($"Last time you said : \"{previous}\"");
}
Console.Write("What do you want me to say on the next execution ? ");
string? message = Console.ReadLine();
if(!string.IsNullOrEmpty(message))
{
    File.WriteAllText("./message", message);
}
*/
// --------------------------------------------------

List<Score> test = MakeDefaultScores();
SaveScores(test);
List<Score> newList = LoadHighScores();

List<Score> MakeDefaultScores() 
{
    return new List<Score>()
    {
        new Score("C3PO", 12200, 14),
        new Score("R2D2", 5000, 8),
    };
}
// On utilise WriteAllLines qui a besoin d'une collection de string
void SaveScores(List<Score> scores)
{
    List<string> lines = new List<string>();
    foreach(Score score in scores)
    {
        lines.Add($"{score.Name},{score.Points},{score.Level}");
    }
    File.WriteAllLines("scores.csv", lines);
}
List<Score> LoadHighScores()
{
    string[] scoresString = File.ReadAllLines("scores.csv");
    List<Score> scores = new List<Score>();
    foreach(string line in scoresString)
    {
        string[] tokens = line.Split(",");
        Score score = new Score(
            tokens[0],
            Convert.ToInt32(tokens[1]),
            Convert.ToInt32(tokens[2])
        );
        scores.Add(score);
        Console.WriteLine($"Score : {score.Name} {score.Points} {score.Level} read !");
    }

    return scores;
}

public record Score(string Name, int Points, int Level);
