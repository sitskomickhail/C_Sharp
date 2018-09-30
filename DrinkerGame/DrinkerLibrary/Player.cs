using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrinkerLibrary
{
    public class Player
    {
        private List<Card> _cards;

        public Player()
        {
            _cards = new List<Card>();
        }

        public Card RemoveCard()
        {
                Card reCard = _cards[0];
                _cards.RemoveAt(0);
                return reCard;
        }

        public Card PlayCard
        {
            get
            {
                return _cards[0];
            }
            internal set { _cards.Add(value); }
        }


        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int CCount { get { return _cards.Count; } }

    }
}
