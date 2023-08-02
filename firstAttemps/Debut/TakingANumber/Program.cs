int test = AskForNumberInRange("Write a number", 10, 28);
System.Console.WriteLine($"You choose {test}");


int AskForNumber(string text) {
    int res;
    Console.Write(text);
    while(!int.TryParse(Console.ReadLine(), out res)) {
        Console.Write("Please enter a valid number : ");
    }
    return res;
}

int AskForNumberInRange(string text, int min, int max) {
    int res;
    Console.Write($"{text} ({min}-{max}) : ");
    while(true) {
        while(!int.TryParse(Console.ReadLine(), out res)) {
            Console.Write("Please enter a valid number : ");
        }
        if (res >= min && res <= max) break;
        Console.Write($"Number must be between {min}-{max} : ");
    }
    return res;
}
