// ---- C# II (Dor Ben Dor) ----
//         Amit Breiman
// -----------------------------


using GenericTypes;

class program
{
    public static void Main(string[] args)
    {
        int[] cardList = new int[40];
        for(int i = 0; i < cardList.Length; i++)
        {
            cardList[i] = Random.Shared.Next(20) + 1;
        }

        var deck = new Deck<int>(40, cardList.ToList());
        var dice = new Dice(20, 1, 0);

        DiceVDeck<int>(dice, deck);


    }


    public static void DiceVDeck<T>(Dice<T> dice, Deck<T> deck) where T : struct, IComparable<T>
    {
        int deckWins = 0;
        int diceWins = 0;
        int ties = 0;

        while(deck.TryDraw(out var card))
        {
            int res = card.CompareTo(dice.GetRandom());

            if (res == 0)
            {
                ties++;
                continue;
            }

            if(res < 0)
            {
                diceWins++;
                continue;
            }

            if(res > 0)
            {
                deckWins++;
                continue;
            }
            
        }

        Console.WriteLine("Results:");
        Console.WriteLine($"Deck Wins : {deckWins}");
        Console.WriteLine($"Dice Wins : {diceWins}");
        Console.WriteLine($"Ties : {ties}");
    }

}