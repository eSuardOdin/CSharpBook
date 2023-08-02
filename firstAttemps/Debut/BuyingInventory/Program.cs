System.Console.WriteLine("The following items are available :");
System.Console.WriteLine("1 - Rope\n2 - Torches\n3 - Climbing equipement\n4 - Clean water");
System.Console.WriteLine("5 - Machete\n6 - Canoe\n7 - Food supplies");
Console.Write("What number do you want to see the price of ? ");
int choice = Convert.ToInt32(Console.ReadLine());
Console.Write("What is your name ? ");
string name = Console.ReadLine();
if (choice > 0 && choice < 8) {
    string product;
    int price;
    product = "";
    price = 0;
    switch(choice) {
        case 1:
            product = "Rope";
            price = 15;
            break;
        case 2:
            product = "Torches";
            price = 15;
            break;
        case 3:
            product = "Climbing equipement";
            price = 25;
            break;
        case 4:
            product = "Clean Water";
            price = 1;
            break;
        case 5:
            product = "Machete";
            price = 20;
            break;
        case 6:
            product = "Canoe";
            price = 200;
            break;
        case 7:
            product = "Food Supplies";
            price = 1;
            break;
    }
    if(name == "Erwann") {
        System.Console.WriteLine($"{product} cost {price / 2} gold");
    } else {
        System.Console.WriteLine($"{product} cost {price} gold");
    }
} else {
    System.Console.WriteLine("Please enter a number between 1 and 7");
}