var rand = new Random();
var picked = new List<int>();
int losing = rand.Next(10);
Console.WriteLine($"Losing number : {losing}");

try 
{
    GameLoop(losing, picked);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

void GameLoop(int losingNb, List<int> picked) 
{
    int playerPick;
    string pickedList = "";
    while(true)
    {
        Console.WriteLine("Please, pick a number between 0 and 9 that has not been picked yet");
        for(int i = 0; i < picked.Count; i++) 
        {
            pickedList += $"{picked[i].ToString()} " ;
        }
        Console.WriteLine($"Already picked : {pickedList}");


        Console.Write("Your choice : ");
        if(Int32.TryParse(Console.ReadLine(), out playerPick))
        {
            if (picked.Contains(playerPick)) { Console.WriteLine("Number already in the list ! "); }
            else if (playerPick < 0 || playerPick > 9) { Console.WriteLine("Number must be between 0-9 !"); }
            else if (playerPick == losingNb) { throw new Exception("There is a problem, this number is a losing one !"); }
            else { picked.Add(playerPick); }
        }
        else
        {
            Console.WriteLine("Please enter a valid number !");
        }

        Console.WriteLine();
        pickedList = "";
    }
}
