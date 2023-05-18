/* Create a Pack class to manage items
Each pack has three limits: The total number of items it can hold, the weight it can
carry and the volume it can hold. Each item has a weight and volume.

*/

Bow bow = new Bow();
Sword sword = new Sword();
Water water = new Water();
Food food = new Food();
Rope rope = new Rope();

Pack pack = new Pack(5, 15f, 12f);


string test;
do {
    Console.WriteLine("(B)ow");
    Console.WriteLine("(S)word");
    Console.WriteLine("(W)ater");
    Console.WriteLine("(F)ood");
    Console.WriteLine("(R)ope");

    Console.Write("Please add an item or press 'q' to quit : ");
    test = Console.ReadLine();
    
    switch(test.ToUpper()) {
        case "B":
            if(pack.AddItem(bow)) {
                Console.WriteLine(bow.GetType() + " Added");
            } else {
                Console.WriteLine("Cannot add " + bow.GetType());
            }
            break;
        case "R":
            if(pack.AddItem(rope)) {
                Console.WriteLine(rope.GetType() + " Added");
            } else {
                Console.WriteLine("Cannot add " + rope.GetType());
            }
            break;
        case "S":
            if(pack.AddItem(sword)) {
                Console.WriteLine(sword.GetType() + " Added");
            } else {
                Console.WriteLine("Cannot add " + sword.GetType());
            }
            break;
        case "W":
            if(pack.AddItem(water)) {
                Console.WriteLine(water.GetType() + " Added");
            } else {
                Console.WriteLine("Cannot add " + water.GetType());
            }
            break;
        case "F":
            if(pack.AddItem(food)) {
                Console.WriteLine(food.GetType() + " Added");
            } else {
                Console.WriteLine("Cannot add " + food.GetType());
            }
            break;
        
    }
    pack.DisplayPackInfo();
    Console.Write("Press enter to continue...");
    Console.ReadLine();
} while(test.ToUpper() != "Q");




public class Pack {
    public InventoryItem[] Items {get; private set;}
    public int AddedItems {get; private set;}
    public float MaxWeight {get;}
    public float MaxVolume {get;}
    
    public Pack(int itemsMax, float maxWeight, float maxVolume) {
        Items = new InventoryItem[itemsMax];
        MaxVolume = maxVolume;
        MaxWeight = maxWeight;
        AddedItems = 0;
    }

    public bool AddItem(InventoryItem item) {
        if(
            (item.Weight + this.GetWeight()) > MaxWeight ||
            (item.Volume + this.GetVolume()) > MaxVolume ||
            AddedItems + 1 > Items.Length 
        ) return false;

        Items[AddedItems] = item;
        AddedItems++;
        return true;
    }

    private float GetVolume() {
        if(AddedItems == 0) return 0;
        float sum = 0;
        for(int i = 0; i < AddedItems; i++) {
            sum += Items[i].Volume;
        }
        return sum;
    }
    private float GetWeight() {
        if(AddedItems == 0) return 0;
        float sum = 0;
        for(int i = 0; i < AddedItems; i++) {
            sum += Items[i].Weight;
        }
        return sum;
    }

    public void DisplayPackInfo() {
        Console.WriteLine($"-Weight : {GetWeight()}/{MaxWeight}\n-Volume : {GetVolume()}/{MaxVolume}\n-Items : {AddedItems}/{Items.Length}");
        DisplayPackItems();
    }

    private void DisplayPackItems(){

        Console.WriteLine("\nPACK : ");
        for(int i = 0; i < AddedItems; i++) {
            Items[i].GetItemType();
        }
    }
}




public abstract class InventoryItem {
    public float Weight {get; protected set;}
    public float Volume {get; protected set;}

    public InventoryItem(float weight, float volume) {
        Weight = weight;
        Volume = volume;
    }

    public abstract void GetItemType();
}


public class Arrow : InventoryItem {
    public Arrow() : base(0.1f, 0.05f) {}
    public override void GetItemType()
    {
        Console.WriteLine("\t- Arrow");
    }

}

public class Bow : InventoryItem {
    public Bow() : base(1f, 4f) {}
    public override void GetItemType()
    {
        Console.WriteLine("\t- Bow");
    }
}

public class Rope : InventoryItem {
    public Rope() : base(1f, 1.5f) {}
    public override void GetItemType()
    {
        Console.WriteLine("\t- Rope");
    }
}
public class Water : InventoryItem {
    public Water() : base(2f, 3f) {}
    public override void GetItemType()
    {
        Console.WriteLine("\t- Water");
    }
}
public class Food : InventoryItem {
    public Food() : base(1f, 0.5f) {}
    public override void GetItemType()
    {
        Console.WriteLine("\t- Food");
    }
}

public class Sword : InventoryItem {
    public Sword() : base(5f, 3f) {}
    public override void GetItemType()
    {
        Console.WriteLine("\t- Sword");
    }
}