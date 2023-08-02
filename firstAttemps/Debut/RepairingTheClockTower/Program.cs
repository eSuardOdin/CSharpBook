System.Console.Write("Enter a number: ");
int nb = Convert.ToInt32(Console.ReadLine());
string res = (nb % 2 == 0) ? "Tick" : "Tock";
System.Console.WriteLine(res);
