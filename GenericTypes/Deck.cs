// ---- C# II (Dor Ben Dor) ----
//         Amit Breiman
// -----------------------------

namespace GenericTypes
{
    class Deck<T> : IRandomProvider<T> where T : struct, IComparable<T>
    {
        private Stack<T> _pile;
        private List<T> _discard;

        public int Size { get; init; }
        public int Remaining { get { return _pile.Count; } }


        public Deck(int size, List<T> cardList)
        {
            Size = size;
            _pile = new Stack<T>();
            _discard = cardList;

            Reshuffle();
        }


        public bool TryDraw(out T card)
        {
            if(_pile.Count == 0)
            {
                card = default(T);
                return false;
            }

            card = _pile.Pop();
            _discard.Add(card);
            return true;
        }

        public T Peek()
        {
            if(_pile.Count == 0)
                return default(T);
            return _pile.Peek();
        }

        public void Reshuffle()
        {
            while(TryDraw(out T card))
            {
                // Empties the deck into the discard pile.
            }

            // Using Fisher-Yates shuffle algorithm on the discard pile.
            for (int i = _discard.Count - 1; i > 0; --i)
            {
                int k = Random.Shared.Next(i + 1);
                T temp = _discard[i];
                _discard[i] = _discard[k];
                _discard[k] = temp;
            }

            // Move the cards from the discard pile to the deck pile while keeping their shuffled order.

            while(_discard.Count > 0)
            {
                _pile.Push(_discard.Last());
                _discard.RemoveAt(_discard.Count - 1);
            }
        }

        public void Shuffle()
        {
            List<T> tempPile = new List<T>();
            tempPile = _pile.ToList();

            // Using Fisher-Yates shuffle algorithm on the temp pile
            for (int i = tempPile.Count - 1; i > 0; --i)
            {
                int k = Random.Shared.Next(i + 1);
                T temp = tempPile[i];
                tempPile[i] = tempPile[k];
                tempPile[k] = temp;
            }

            _pile.Clear(); 

            while (tempPile.Count > 0)
            {
                _pile.Push(tempPile.Last());
                tempPile.RemoveAt(tempPile.Count - 1);
            }

        }





        public T GetRandom()
        {
            T card;
            TryDraw(out card);
            return card;
        }

        

    }
}
