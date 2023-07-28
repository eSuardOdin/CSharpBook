Console.WriteLine("Ta race");

public class InventoryItem
{
    public float Weight { get; }
    public float Volume { get; }
    public InventoryItem(float Weight, float volume)
    {
        Weight = Weight;
        Volume = volume;
    }
}

public class Arrow : InventoryItem 
{
    public Arrow() : base(0.1f, 0.05f) {}
}
public class Bow : InventoryItem 
{
    public Bow() : base(1f, 4f) {}
}
public class Rope : InventoryItem 
{
    public Rope() : base(1f, 1.5f) {}
}
public class Water : InventoryItem 
{
    public Water() : base(2f, 3f) {}
}
public class Food : InventoryItem 
{
    public Food() : base(1f, 0.5f) {}
}
public class Sword : InventoryItem 
{
    public Sword() : base(5f, 3f) {}
}

public class Pack
{
    public float MaxWeight {get;}
    public float MaxVolume {get;}
    private int MaxItems {get;}
    private InventoryItem[] InventoryItems {get;}
    private int AddedItems {get; set;}
    public Pack(float maxWeight, float maxVolume)
    {
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
        InventoryItems = new InventoryItem[MaxItems];
        AddedItems = 0;
    }


    public bool Add(InventoryItem item)
    {
        if(
            GetVolume() + item.Volume > MaxVolume ||
            GetWeight() + item.Weight > MaxWeight ||
            AddedItems == MaxItems
        ) return false;

        InventoryItems[AddedItems] = item;
        AddedItems++;
        return true;
    }

    private float GetWeight() 
    {
        float Weight = 0;
        for (int i = 0; i < AddedItems; i++)
        {
            Weight += InventoryItems[i].Weight;
        }
        return Weight;
    }
    private float GetVolume() 
    {
        float volume = 0;
        for (int i = 0; i < AddedItems; i++)
        {
            volume += InventoryItems[i].Volume;
        }
        return volume;
    }
}