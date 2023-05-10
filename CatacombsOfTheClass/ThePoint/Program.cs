Point pointA = new Point();
pointA.PrintPoint();

System.Console.WriteLine(pointA.X);


Point pointB = new Point(2, 3);
pointB.PrintPoint();
System.Console.WriteLine(pointB.X);


Point pointC = new Point(-4, 0);
pointC.PrintPoint();
System.Console.WriteLine(pointC.X);

public class Point {


    public int X {get;}
    public int Y {get;}

    public Point(int x, int y) {
        X = x;
        Y = y;
    }

    public Point() {
        X = 0;
        Y = 0;
    }

    public void PrintPoint() {
        Console.WriteLine($"({X}, {Y})");
    }
}