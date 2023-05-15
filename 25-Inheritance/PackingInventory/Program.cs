/* Create a Pack class to manage items
Each pack has three limits: The total number of items it can hold, the weight it can
carry and the volume it can hold. Each item has a weight and volume.

*/
Bow bow = new Bow();
System.Console.WriteLine(bow.Volume);







public class Pack {
    public int MaxItems {get;}
    public float MaxWeight {get;}
    public float MaxVolume {get;}
}




public class InventoryItem {
    public float Weight {get; protected set;}
    public float Volume {get; protected set;}

    public InventoryItem(float weight, float volume) {
        Weight = weight;
        Volume = volume;
    }
}


public class Arrow : InventoryItem {
    public Arrow() : base(0.1f, 0.05f) {}
}


public class Bow : InventoryItem {
    public Bow() : base(1f, 4f) {}
}