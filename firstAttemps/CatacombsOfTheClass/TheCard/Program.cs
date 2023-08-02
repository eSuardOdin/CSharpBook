
// Create a list of cards and add every card in it
List<Card> Deck = new List<Card>();
foreach(Color color in Enum.GetValues(typeof(Color))){
    foreach(Rank rank in Enum.GetValues(typeof(Rank))) {
        Card card = new Card(color, rank);
        Deck.Add(card);
    }
} 

// Print cards 
foreach (Card card in Deck)
{
    card.GetCardDescription();
    card.GetCardStatus();
}


class Card
{
    public Color Color {get;}
    public Rank Rank {get;}
    public Card(Color color, Rank rank) {
        Color = color;
        Rank = rank;
    }

    public void GetCardDescription() {
        Console.WriteLine($"- The {Color} {Rank}");
    }

    public void GetCardStatus() {
        if ((int)Rank < 10) Console.WriteLine("This card is a number");
        else Console.WriteLine("This card is a symbol");
    }

}

enum Color {Red, Green, Blue, Yellow}
enum Rank  {One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand}