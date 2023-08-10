BlockCoordinate bloc = new BlockCoordinate(5, 8);
Console.WriteLine(bloc);

Console.WriteLine("Moving north 2 times");
bloc += Direction.North;
bloc += Direction.North;
Console.WriteLine(bloc);

BlockOffset off = new BlockOffset(45, -13);
Console.WriteLine($"Setting an offset : {off}");

bloc += off;
Console.WriteLine(bloc);

Console.WriteLine($"Block row : {bloc[0]}");

public record BlockCoordinate (int Row, int Column)
{
    // Move with direction
    public static BlockCoordinate operator +(BlockCoordinate block, Direction dir) 
    {
        return dir switch 
        {
            Direction.North => new BlockCoordinate(block.Row - 1, block.Column),
            Direction.South => new BlockCoordinate(block.Row + 1, block.Column),
            Direction.East => new BlockCoordinate(block.Row, block.Column + 1),
            Direction.West => new BlockCoordinate(block.Row, block.Column - 1)
        };
    }
    // Invert as parameters are not same type
    public static BlockCoordinate operator +(Direction dir, BlockCoordinate block) => block + dir;

    // Move with offset
    public static BlockCoordinate operator +(BlockCoordinate block, BlockOffset offset) => new BlockCoordinate(block.Row + offset.RowOffset, block.Column + offset.ColumnOffset);

    // Invert
    public static BlockCoordinate operator +(BlockOffset offset, BlockCoordinate block) => block + offset;


    // Adding indexer
    public int this[int index]
    {
        get
        {
            if (index == 0) { return Row;}
            else            { return Column; }
        }
    }



}
public record BlockOffset (int RowOffset, int ColumnOffset); 
public enum Direction { North, East, West, South } 