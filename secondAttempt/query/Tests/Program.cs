List<GameObject> objects = new List<GameObject>();
objects.Add(new Ship {ID = 1, X = 0, Y = 0, Hp = 50, MaxHp = 100, PlayerID = 1});
objects.Add(new Ship {ID = 2, X = 3, Y = 8, Hp = 76, MaxHp = 100, PlayerID = 1});
objects.Add(new Ship {ID = 3, X = 5, Y = 5, Hp = 100, MaxHp = 100, PlayerID = 2});
objects.Add(new Ship {ID = 4, X = 10, Y = 0, Hp = 0, MaxHp = 100, PlayerID = 3});


List<Player> players = new List<Player>();
players.Add(new Player (1, "Player 1", "Red"));
players.Add(new Player (2, "Player 2", "Blue"));
players.Add(new Player (3, "Player 3", "Blue"));


// Most basic query 
IEnumerable<GameObject> everything = /*from clause*/   from obj in objects 
                                     /*select clause*/ select obj;

var ids = from obj in objects select obj.ID; // This results in IEnumerable<int> 
var healthText = from obj in objects select $"{obj.Hp}/{obj.MaxHp}"; // Result in IEnumerable<string> like "88/100", "50/100"...
public class GameObject
{
    public int ID { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public int MaxHp { get; set; }
    public int Hp { get; set; }
    public int PlayerID { get; set; }
}

public class Ship : GameObject { }

public record Player(int ID, string Username, string TeamColor);