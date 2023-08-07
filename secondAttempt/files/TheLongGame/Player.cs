namespace TheLongGame;

public class Player
{
    public string Name { get; private set; }
    public int Score { get; private set; }

    public Player(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public void AddToScore(int score)
    {
        Score += score;
    }

    public string PlayerInfo()
    {
        return ($"Welcome {Name}\nCurrent score : {Score}");
    }
}
