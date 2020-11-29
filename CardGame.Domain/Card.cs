namespace CardGame.Domain
{
    public class Card
    {
        public Card(string suit, string face)
        {
            Face = face;
            Suit = suit;
        }

        public string Face { get; private set; }
        public string Suit { get; private set; }
        public override string ToString()
        {
            return $"{Face} of {Suit}";
        }
    }
}
