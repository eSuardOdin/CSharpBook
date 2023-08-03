if (File.Exists("./message"))
{
    string previous = File.ReadAllText("./message");
    Console.WriteLine($"Last time you said : \"{previous}\"");
}
Console.Write("What do you want me to say on the next execution ? ");
string? message = Console.ReadLine();
if(!string.IsNullOrEmpty(message))
{
    File.WriteAllText("./message", message);
}