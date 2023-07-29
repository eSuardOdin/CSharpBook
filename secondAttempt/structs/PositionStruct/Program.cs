Coordinate a = new Coordinate(0, 0);
Coordinate b = new Coordinate(5, -1);

Console.WriteLine($"{a.IsAdjacent(b)}");
public struct Coordinate
{
    public readonly int X {get;}
    public readonly int Y {get;}
    public Coordinate(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public bool IsAdjacent(Coordinate other) => 
        this.X == other.X + 1 || this.Y == other.Y + 1 || 
        this.X == other.X - 1 || this.Y == other.Y - 1; 
}
