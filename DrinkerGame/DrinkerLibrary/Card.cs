using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrinkerLibrary
{
    public class Card
    {
        public Suits Suit { get; private set; }
        public Values Value { get; private set; }

        public Card(Suits suit, Values value)
        {
            Suit = suit;
            Value = value;
        }
        public override string ToString()
        {
            return $"{Suit} {Value}";
        }
        

        public static bool operator > (Card card1, Card card2)
        {
            if (card1.Value > card2.Value)
                return true;
            return false;
        }

        public static bool operator <(Card card1, Card card2)
        {
            if (card1.Value < card2.Value)
                return true;
            return false;
        }
    }
}
