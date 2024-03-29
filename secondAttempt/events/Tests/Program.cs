﻿Ship ship = new Ship(3);
SoundEffectManager sem = new(ship);
var exploded = false;
while(ship.Health > 0)
{
    Console.WriteLine($"Ship's life : {ship.Health}");
    Console.Write("Press Enter");
    Console.ReadLine();
    ship.TakeDamage(1);
    Console.WriteLine("");
    if(ship.Health == 0 && !exploded) 
    { 
        ship.Regenerate(); 
        exploded = !exploded;    
    }
}

public class Ship
{
    //-----------------------------------------
    // public event Action<DateTime>? ShipExploded; -> Première version
    //-----------------------------------------

    private Action<DateTime>? _shipExploded;
    public event Action<DateTime>? ShipExploded
    {
        add
        {
            _shipExploded += value;
            Console.WriteLine("Event added to a listener");
        }
        remove {
            
            _shipExploded -= value;
            Console.WriteLine("Event removed from listener");
        
        }
    }
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
            //ShipExploded?.Invoke(DateTime.Now); // Check if null event (if no handlers attached) -> Première version
            _shipExploded?.Invoke(DateTime.Now); // Check if null event (if no handlers attached)
        }
    }

    public void Regenerate() => Health = 3; // Just for testing purpose
}



public class SoundEffectManager 
{
    private Ship ShipObj { get; set;}

    // We attach the method to the event in the constructor
    public SoundEffectManager(Ship ship)
    {
        ShipObj = ship;
        ShipObj.ShipExploded += OnShipExploded;
    }
    private void OnShipExploded(DateTime now)
    {
        PlaySound($"Boooooooooooom badaboum biiiiiing, ship exploded on {now}");
        // Cleanup after the first explosion, no event anymore
        Cleanup();
    }

    private void PlaySound(string message)
    {
        Console.WriteLine(message);
    }

    // To clean the event and let the garbage collector clean the object
    private void Cleanup()
    {
        ShipObj.ShipExploded -= OnShipExploded;
    }
}




