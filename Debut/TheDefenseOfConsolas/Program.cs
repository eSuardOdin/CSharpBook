int row, col;
Console.Title = "The defense of consolas";
Console.Write("Taget row : ");
row = Convert.ToInt32(Console.ReadLine());

Console.Write("Taget column : ");
col = Convert.ToInt32(Console.ReadLine());

Console.ForegroundColor = ConsoleColor.Green;
System.Console.WriteLine("Deploy to:");
System.Console.WriteLine($"({row}, {col-1})");
System.Console.WriteLine($"({row-1}, {col})");
System.Console.WriteLine($"({row}, {col+1})");
System.Console.WriteLine($"({row+1}, {col})");
Console.Beep(220, 300);