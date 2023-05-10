Countdown(22);


void Countdown(int nb){
    Console.WriteLine($"{nb}");
    if(nb == 1) return;
    Countdown(nb-1);
}