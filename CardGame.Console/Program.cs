using System;
using CardGame.Domain;
using System.Linq;

namespace CardGame
{
    public class Program
    {
        static int[] _validInputs = { 1, 2, 3, 999 };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Card Game. Following are the choices.");
            CardGameContext();
            Console.WriteLine("Game finished.");
        }

        private static void CardGameContext()
        {
            int userInput = default;
            Deck deck = new Deck();
            while (userInput != 999)
            {
                PrintUserOptions();
                Int32.TryParse(Console.ReadLine(), out userInput);

                if (!ValidateUserInput(userInput))
                {
                    Console.WriteLine("Invalid Input, please enter the valid Input");
                    continue;
                }
                switch (userInput)
                {
                    case 1:
                        try
                        {
                            PlayGame(deck);
                        }
                        catch (CardNotAvailableException ex)
                        {
                            Console.WriteLine("Deck is empty.");
                        }
                        break;
                    case 2:
                        deck.ShuffleCard();
                        break;
                    case 3:
                        deck.RestartGame();
                        break;
                }
            }
        }

        private static void PlayGame(Deck deck)
        {
            Console.WriteLine("Enter 'Stop' to stop throwing the card Or Press 'Enter' to continue.");
            while (true)
            {
                Console.WriteLine(deck.StartGameOrThrowNextCard().ToString());
                if (Console.ReadLine().Equals("stop", StringComparison.InvariantCultureIgnoreCase))
                    break;
            }
        }
        private static void PrintUserOptions()
        {
            Console.WriteLine("Enter 1: Play a game or Resume.");
            Console.WriteLine("Enter 2: Shuffle the deck.");
            Console.WriteLine("Enter 3: Restart the game.");
            Console.WriteLine("Enter 999 to exit the Card Game");
        }

        private static bool ValidateUserInput(int userInput)
        {
            return _validInputs.Contains(userInput);
        }
    }
}
