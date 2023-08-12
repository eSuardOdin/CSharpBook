var lnb = new LastNumbers();
Thread thread = new Thread(GenerateNumber);

thread.Start(lnb);

bool isDuplicate;
while(true)
{
    Console.ReadKey(false);
    lock(lnb)
    {
        isDuplicate = lnb.A == lnb.B;
    }

    if(isDuplicate) 
    {
        Console.WriteLine();
        Console.WriteLine($"You found a duplicate with number {lnb.A} !");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine($"Error. No duplicates.");
        Console.WriteLine();
    } 
}




void GenerateNumber(object? obj) 
{
    if(obj == null) return;
    LastNumbers lastNumbers = (LastNumbers)obj;
    var rand = new Random();
    while(true)
    {
        lock (lastNumbers)
        {
            lastNumbers.B = lastNumbers.A;
            lastNumbers.A = rand.Next(0, 10);
        }
        Console.WriteLine($"Number A : {lastNumbers.A}    Number B : {lastNumbers.B}");
        Thread.Sleep(1000);
    }
}


class LastNumbers
{
    public int A { get; set;}
    public int B { get; set;}
}