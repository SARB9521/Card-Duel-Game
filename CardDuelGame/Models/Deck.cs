using System;
using System.Collections.Generic;
using System.Linq;

namespace CardDuelGame.Models
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            cards = new List<Card>();
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    cards.Add(new Card
                    {
                        Rank = rank,
                        Suit = suit,
                        Value = GetValue(rank)
                    });
                }
            }

            Shuffle();
        }

        private int GetValue(string rank) =>
            rank switch
            {
                "J" => 11,
                "Q" => 12,
                "K" => 13,
                "A" => 14,
                _ => int.Parse(rank)
            };

        private void Shuffle()
        {
            Random rand = new Random();
            cards = cards.OrderBy(c => rand.Next()).ToList();
        }

        public Card Draw()
        {
            if (cards.Count == 0) return new Card { Rank = "?", Suit = "?", Value = 0 };
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}
