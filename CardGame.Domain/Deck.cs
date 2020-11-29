using System;
using System.Linq;
using System.Collections.Generic;
namespace CardGame.Domain
{
    public class Deck
    {
        private const int NUMBER_OF_CARDS = 52;
        private readonly int _maxShuffling = 25;
        private readonly int _minShuffling = 5;
        private readonly IEnumerable<Card> _cards = new List<Card>(NUMBER_OF_CARDS);  // Define the capacity for optimization.
        private List<Card> _availableCards = new List<Card>(NUMBER_OF_CARDS);                                                                               //List internally uses an array with capacity of 8.

        private readonly string[] _faces = {"Ace","Two","Three","Four","Five","Six",
                "Seven","Eight","Nine","Ten","Jack","Queen","King"};

        private readonly string[] _suits = { "Hearts", "Clubs", "Diamonds", "Spades" };

        /// <summary>
        /// Constructor
        /// </summary>
        public Deck()
        {
            _cards = ConstructDeckSolution3();
            _availableCards = new List<Card>(_cards);
            ShuffleCard();


        }
        /// <summary>
        /// Constructing the Deck
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Card> ConstructDeckSolution3()
        {
            foreach (var suit in _suits)
            {
                foreach (var face in _faces)
                {
                    yield return new Card(suit: suit, face: face); //  Named parameter to  prevent error
                }
            }
        }
        /// <summary>
        /// Start the Game
        /// </summary>
        /// <returns></returns>
        public Card StartGameOrThrowNextCard()
        {
            var topCard = _availableCards.LastOrDefault();//Throwing top card.
            if (topCard != null)
            {
                _availableCards.Remove(topCard);
                return topCard;
            }
            throw new CardNotAvailableException("No card available in the Deck.");

        }


        /// <summary>
        /// Shuffling the Card
        /// </summary>
        /// <returns></returns>
        public void ShuffleCard()
        {
            var shuffleCount = new Random().Next(_minShuffling, _maxShuffling);
            int shuffleStart = 0;
            //Suffling the card based on the Random Value to simulate Real Time Shuffling
            while (shuffleStart != shuffleCount)
            {
                int nextSwap = new Random().Next(1, _availableCards.Count - 1);
                for (int i = 0; i < _availableCards.Count; i++)
                {
                    var tempCard = _availableCards[nextSwap];
                    _availableCards[nextSwap] = _availableCards[i];
                    _availableCards[i] = tempCard;
                }
                shuffleStart++;
            }
            //PrintDeck();
        }
        /// <summary>
        /// Restart the game.
        /// </summary>
        public void RestartGame()
        {
            _availableCards = new List<Card>(_cards);
            ShuffleCard();
            //PrintDeck();
        }
        /// <summary>
        /// Print the available card in the deck if required.
        /// </summary>
        public void PrintDeck()
        {
            int cardNumber = 1;
            foreach (var deck in _availableCards)
            {
                Console.WriteLine(cardNumber + " " + deck.ToString());
                cardNumber++;
            }
        }
    }
}
