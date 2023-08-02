Color colA = new Color(12,25,48);
colA.GetColor();

Color white = Color.White();
white.GetColor();




public class Color {
    public byte Red {get;}
    public byte Green {get;}
    public byte Blue {get;}

    public Color(byte r, byte g, byte b) {
        Red = r;
        Green = g;
        Blue = b;
    }

    public void GetColor() {
        Console.WriteLine($"(R: {Red}, G: {Green}, B: {Blue})");
    } 

    public static Color White() => new Color(255, 255, 255);
}