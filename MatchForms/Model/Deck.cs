using System;
using System.Collections.Generic;

namespace MatchForms.Model
{
    /// <summary>
    ///     A deck of cards
    /// </summary>
    public class Deck
    {
        private List<Card> _cards;
        private Random _random;

        private List<Card> Cards
        {
            get { return _cards ?? (_cards = new List<Card>()); }
        }

        private Random Random
        {
            get { return _random ?? (_random = new Random()); }
        }

        /// <summary>
        ///     Add card to deck
        /// </summary>
        /// <param name="card">Card to add</param>
        /// <param name="isAddToTop">If true add at top, else add at bottom</param>
        public void AddCard(Card card, bool isAddToTop)
        {
            if (card == null) return;

            if (isAddToTop)
                Cards.Insert(0, card);
            else
                Cards.Add(card);
        }

        /// <summary>
        ///     Draw a random card from deck
        /// </summary>
        /// <returns>Random card</returns>
        public Card DrawRandomCard()
        {
            int index = Random.Next(Cards.Count);
            Card randomCard = Cards[index];
            Cards.RemoveAt(index);

            return randomCard;
        }
    }
}