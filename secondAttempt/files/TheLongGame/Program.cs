/*
    The user enters his name, if not exists, create a file named as [username].txt

    The program must read the number of keys typed by user and save it in this file when exiting
    (or append them if any score already exists)

    It displays the top 3 scores and usernames associated with the users score
*/

using TheLongGame;
/* Console.Write("Please enter your name : ");
var name = Console.ReadLine();
while (string.IsNullOrEmpty(name));
{
    Console.Write("Please enter a valid name : ");
    name = Console.ReadLine();
} 

if(!File.Exists("")) { File.Create()} */

Game game = new("./Scores");
SaveManager sm = new("./Scores");
Player player = sm.LoadPlayer("valid");
Console.WriteLine($"{player.Name} {player.Score}");
Console.Write("Entre un score pour le test : ");
int test;
Int32.TryParse(Console.ReadLine(), out test);
player.Score = test;
sm.SavePlayer(player);
Console.WriteLine($"UPDATE : {player.Name} {player.Score}");






