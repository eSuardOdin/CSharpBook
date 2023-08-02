int x, y;
string direction;
Console.Write("Enter x coordinate : ");
x = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter y coordinate : ");
y = Convert.ToInt32(Console.ReadLine());

if (x < 0) {
    if(y > 0) direction = "to the northwest !";
    else if (y == 0) direction = "to the west !";
    else direction = "to the southwest !";
} else if (x == 0) {
    if(y > 0) direction = "to the north !";
    else if (y == 0) direction = "here !";
    else direction = "to the south !";
} else {
    if(y > 0) direction = "to the northeast !";
    else if (y == 0) direction = "to the east !";
    else direction = "to the southeast !";
}
System.Console.WriteLine($"The enemy is {direction}");