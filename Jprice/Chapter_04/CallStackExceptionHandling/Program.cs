using System.ComponentModel;
using CallStackExceptionHandlingLib;
using static System.Console;

WriteLine("in Main");
Alpha();

void Alpha()
{
    WriteLine("in Alpha");
    Beta();
}

void Beta()
{
    WriteLine("in Beta");
    try
    {
        Calculator.Gamma();
    }
    catch (System.Exception ex)
    {   
        WriteLine($"Caught this ---> \" {ex.Message} \"");
        throw;
    }
}