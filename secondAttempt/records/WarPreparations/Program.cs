Sword basicSword = new Sword(Material.iron, null, 130, 10);
Sword betterSword = basicSword with {Material = Material.binarium, Gemstone = Gemstone.bitsone};
Console.WriteLine(basicSword);
Console.WriteLine(betterSword);


public record Sword (Material Material, Gemstone? Gemstone, int Length, int Width);
public enum Material { wood, bronze, iron, steel, binarium }
public enum Gemstone { emerald, amber, sapphire, diamond, bitsone }