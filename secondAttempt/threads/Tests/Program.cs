/* // CountTo100();
Thread thread = new Thread(CountTo100);
Thread thread1 = new Thread(CountTo100);
thread.Start();
thread1.Start();
Console.WriteLine("Hello world");
Console.WriteLine("Hello world");
Console.WriteLine("Hello world");
Console.WriteLine("Hello world");
Console.WriteLine("Hello world");
Console.WriteLine("Hello world");
Console.WriteLine("Hello world");
Console.WriteLine("Hello world");
Console.WriteLine("Good bye world");
Console.WriteLine("It's been good to see you");
Console.WriteLine("Please, have a nice day");
Console.WriteLine("Main Thread done");




void CountTo100()
{
    for(int index = 0; index < 100; index++)
    {
        Console.WriteLine("" + index);
    }
} */


var mul = new MultiplicationProblem { A = 5, B = 2 };
Thread thread = new Thread(Multiply);
thread.Start(mul);
Console.WriteLine(mul.Result);  // May not be over yet

thread.Join();

Console.WriteLine(mul.Result);



void Multiply(object? obj)
{
    if (obj == null) return;
    MultiplicationProblem problem = (MultiplicationProblem)obj;
    problem.Result = problem.A * problem.B;
}

class MultiplicationProblem
{
    public double A { get; set; }
    public double B { get; set; }
    public double Result { get; set; }
}