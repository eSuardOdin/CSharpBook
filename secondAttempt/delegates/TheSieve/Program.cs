
Console.WriteLine("Please choose a function to check numbers : ");
Console.WriteLine("0 : Check if even");
Console.WriteLine("1 : Check if positive");
Console.WriteLine("2 : Check if 10 multiple");
Console.Write("Your choice  : ");

int choice;
Predicate<int> func;

while( !Int32.TryParse(Console.ReadLine(), out choice)) {
    Console.WriteLine("Please enter a valid number ! ");
}

Sieve sieve = choice switch 
{
    0 => new Sieve(IsEven),
    1 => new Sieve(IsPos),
    2 => new Sieve(n => n%10==0),
    
}; 


while(true)
{
    Console.WriteLine("Please enter a number : ");
    while( !Int32.TryParse(Console.ReadLine(), out choice)) {
        Console.WriteLine("Please enter a valid number ! ");
    }
    Console.WriteLine(sieve.IsGood(choice));
}




bool IsEven(int number) => number % 2 == 0;
bool IsPos(int number) => number >= 0;
bool IsModTen(int number) => number % 10 == 0; 