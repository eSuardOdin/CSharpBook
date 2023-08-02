Ship ship = new Ship(3);
SoundEffectManager sem = new(ship);

while(ship.Health > 0)
{
    Console.WriteLine($"Ship's life : {ship.Health}");
    Console.Write("Press Enter");
    Console.ReadLine();
    ship.TakeDamage(1);
    Console.WriteLine("");
}

public class Ship
{
    public event Action<DateTime>? ShipExploded;
    public int Health { get; private set; }

    public Ship(int health)
    {
        Health = health;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0) 
        {
            ShipExploded(DateTime.Now);
        }
    }
}



public class SoundEffectManager 
{

    // We attach the method to the event in the constructor
    public SoundEffectManager(Ship ship)
    {
        ship.ShipExploded += OnShipExploded;
    }
    private void OnShipExploded(DateTime now) => PlaySound($"Boooooooooooom badaboum biiiiiing, ship exploded on {now}");

    public void PlaySound(string message)
    {
        Console.WriteLine(message);
    } 
}