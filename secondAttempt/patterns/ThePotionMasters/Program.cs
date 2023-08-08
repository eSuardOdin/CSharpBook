while(true)
{
    Potion potion = Potion.Water;
    while(potion != Potion.Ruined_Potion)
    {
        Console.WriteLine($"You have {potion.ToString()}, what ingredient do you add ?");
        Console.WriteLine("- 0 : Stardust");
        Console.WriteLine("- 1 : Snake venom");
        Console.WriteLine("- 2 : Dragon breath");
        Console.WriteLine("- 3 : Shadow glass");
        Console.WriteLine("- 4 : Eyeshine gem");
        Console.WriteLine("- 5 : Back to water potion");

        Console.Write("Your choice : ");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 5) { break; }
        // No error preventing at all, just for me.
        Ingredient ingredient = (Ingredient)choice;
        potion = Match(potion, ingredient);
        if(potion == Potion.Ruined_Potion) { Console.WriteLine("Oh no ! A ruined potion !"); }
        Console.WriteLine();
    }
}


Potion Match(Potion potion, Ingredient ingredient)
{

    return (potion, ingredient) switch 
    {
        (Potion.Water, Ingredient.Stardust)                     => Potion.Elixir,
        (Potion.Cloudy_Brew, Ingredient.Stardust)               => Potion.Wraith_Potion,
        (Potion.Elixir, Ingredient.Snake_Venom)                 => Potion.Poison_Potion,
        (Potion.Elixir, Ingredient.Dragon_Breath)               => Potion.Flying_Potion,
        (Potion.Elixir, Ingredient.Shadow_Glass)                => Potion.Invisibility_Potion,
        (Potion.Elixir, Ingredient.Eyeshine_Gem)                => Potion.Night_Sight_Potion,
        (Potion.Night_Sight_Potion, Ingredient.Shadow_Glass)    => Potion.Cloudy_Brew,
        (Potion.Invisibility_Potion, Ingredient.Eyeshine_Gem)   => Potion.Cloudy_Brew,
        _                                                       => Potion.Ruined_Potion

    };
}

public enum Potion
{
    Water,
    Elixir,
    Poison_Potion,
    Flying_Potion,
    Invisibility_Potion,
    Night_Sight_Potion,
    Cloudy_Brew,
    Wraith_Potion,
    Ruined_Potion
}

public enum Ingredient
{
    Stardust,
    Snake_Venom,
    Dragon_Breath,
    Shadow_Glass,
    Eyeshine_Gem
}
