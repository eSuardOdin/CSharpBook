Sword original = new Sword(Material.iron, Gemstones.empty, 12.0f, 3.5f);
Console.WriteLine(original);
Sword second = original with {material = Material.binarium, gemstone = Gemstones.sapphire};
Console.WriteLine(second);

public record Sword(Material material, Gemstones gemstone, float length, float width);

public enum Material {
    wood,
    bronze,
    iron,
    steel,
    binarium
}

public enum Gemstones {
    emerald,
    amber,
    sapphire,
    diamond,
    bitsone,
    empty
}