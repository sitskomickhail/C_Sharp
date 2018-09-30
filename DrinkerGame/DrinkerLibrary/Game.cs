using System;
using System.Collections.Generic;
using System.Linq;

namespace DrinkerLibrary
{
    public class Game
    {
        private List<Card> _cards;

        public Game()
        {
            _cards = new List<Card>();
            CreateCardDeck();
        }

        private void CreateCardDeck()
        {
            Array arrSuits = Enum.GetValues(typeof(Suits));
            Array arrValues = Enum.GetValues(typeof(Values));
            
            for (int i = 0; i < arrSuits.Length; i++)
            {
                for (int j = 0; j < arrValues.Length; j++)
                {
                    Card card = new Card((Suits)arrSuits.GetValue(i), (Values)arrValues.GetValue(j));
                    _cards.Add(card);
                }
            }
        }

        public bool SetPlayerCards(List<Player> players)
        {
            if (players.Count == 5 || players.Count < 2 || players.Count > 6)
                throw new ArgumentOutOfRangeException("Недопустимое число");
            if (_cards.Count == 0)
                return false;

            int cardCount = _cards.Count;
            for (int i = 0; i < players.Count; i++)
            {
                for (int j = 0; j < cardCount / players.Count; j++)
                {
                    players[i].PlayCard = _cards[0];
                    _cards.Remove(_cards[0]);
                }
            }
            return true;
        }

        public Player StartGame(List<Player> players)
        {
            List<Card> playingCards = new List<Card>();

            for (int i = 0; i < players.Count; i++)
            {
                Card card = players[i].RemoveCard();
                playingCards.Add(card);
            }
            int winIndex = IndexWinner(playingCards);
            if (winIndex == playingCards.Count)
            {
                List<Player> playersEquals = new List<Player>();
                List<int> poses = new List<int>();
                List<Card> demoCards = new List<Card>();

                for (int i = 0; i < players.Count - 1; i++)
                {
                    if (players[i].PlayCard == players[i + 1].PlayCard)
                    {
                        playersEquals.Add(players[i]);
                        playersEquals.Add(players[i + 1]);

                        if (poses.Exists(num => num == i)) { }
                        else poses.Add(i);
                        if (poses.Exists(num => num == i + 1)) { }
                        else poses.Add(i + 1);
                    }
                }
                for (int i = 0; i < playersEquals.Count; i++)
                {
                    Card card = playersEquals[i].RemoveCard();
                    playingCards.Add(card);
                    card = playersEquals[i].RemoveCard();
                    demoCards.Add(card);
                }
                int trVr = IndexWinner(demoCards);
                for (int i = 0; i < trVr; i++)
                {
                    winIndex = poses[i];
                }
            }

            for (int i = 0; i < playingCards.Count; i++)
            {
                players[winIndex].PlayCard = playingCards[i];
            }
            return players[winIndex];
        }

        public void Shuffle()
        {
            _cards = _cards.OrderBy((x => Randomer.Next())).ToList();
        }

        private int IndexWinner(List<Card> playingCards)
        {
            int winIndex = 0;
            int thisIs6;
            for (int i = 1; i < playingCards.Count - 1; i++)
            {
                if (playingCards[i].Value == Values.Six)
                {
                    thisIs6 = i;
                    for (int j = 0; j < playingCards.Count; j++)
                    {
                        if (playingCards[j].Value == Values.Ace)
                        {
                            winIndex = i;
                            return winIndex;
                        }
                    }
                }
                if (playingCards[winIndex] == playingCards[i + 1])
                    return playingCards.Count;
                if (playingCards[winIndex] > playingCards[i])
                {
                    winIndex = i;
                }
            }
            return winIndex;
        }
    }
}