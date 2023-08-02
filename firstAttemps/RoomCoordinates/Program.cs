Coordinate test = new Coordinate(2,5);
Coordinate test2 = new Coordinate(1,5);
Console.WriteLine($"Row : {test.Row}     Column : {test.Column}");
Console.WriteLine($"Row : {test2.Row}     Column : {test2.Column}");
Console.WriteLine(test.IsAdjacentTo(test2));
public struct Coordinate
{
    public int Row {get;}
    public int Column {get;}
    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public bool IsAdjacentTo(Coordinate otherRoom)
    {
        return (this.Row == otherRoom.Row -1   ||
            this.Row == otherRoom.Row +1       ||
            this.Column == otherRoom.Column -1 ||
            this.Column == otherRoom.Column +1 
        );
    }
}