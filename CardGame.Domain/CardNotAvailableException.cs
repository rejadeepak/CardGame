using System;
namespace CardGame.Domain
{
    public class CardNotAvailableException : Exception
    {
        public CardNotAvailableException()
        {
        }

        public CardNotAvailableException(string message)
        : base(message)
        {
        }

        public CardNotAvailableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
