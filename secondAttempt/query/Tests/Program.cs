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
var healthStatus = from obj in objects select (obj, $"{obj.Hp}/{obj.MaxHp}"); // Tuple (GameObject, string



// Filtering with a where clause
var livingShipsID = from obj in objects 
                    where obj.Hp > 0 
                    select obj.ID;

// As many "where" as needed
var livingShipsIDP1 = from obj in objects 
                    where obj.Hp > 0
                    where obj.PlayerID == 1 
                    select obj.ID;


// Select ships, lowest Hp will be first
var weakestLivingShip = 
    from obj in objects
    where obj.Hp > 0
    orderby obj.Hp, obj.PlayerID // Second orderby is there to resolve tie
    select obj;

var strongestLivingShip = 
    from obj in objects
    where obj.Hp > 0
    orderby obj.Hp descending // Reversing order here (ascending is default)
    select obj;



// Join 
var objectColor = 
    from obj in objects
    join p in players on obj.PlayerID equals p.ID
    select (obj, p.TeamColor); // -> Permet d'associer la couleur d'équipe du joueur possédant le ship à celui ci


// La clause let permet de définir une variable à la volée
var testLet =
    from obj in objects
    let percentHealth = obj.Hp != 0 ? (Convert.ToDecimal(obj.Hp) / obj.MaxHp) * 100 : 0
    select $"Object has {percentHealth}% hp left";


// La clause into permet d'utiliser le select precedent
var test = 
    from obj in objects
    where obj.PlayerID == 1
    select obj // Get ships from p1
into objAlive
    where objAlive.Hp != 0
    select objAlive.ID;
// Gets alive objects from p1

foreach(var str in testLet) { Console.WriteLine(str); }
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