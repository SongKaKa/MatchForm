using System.Collections.Generic;

namespace MatchForms.Model
{
    public class CardMatchingGame
    {
        private const int MatchBonus = 4;
        private const int MismatchPenalty = 2;
        private const int FlipCost = 1;

        public void FlipCardAtIndex(int index)
        {
            Card card = CardAtindex(index);
            if (card != null && card.IsPlayable)
            {
                if (!card.IsFaceUp)
                {
                    foreach (var otherCard in Cards)
                    {
                        if (otherCard.IsFaceUp && otherCard.IsPlayable)
                        {
                            int matchScore = card.Match(otherCard);
                            if (matchScore != 0)
                            {
                                card.IsPlayable = false;
                                otherCard.IsPlayable = false;
                                Score += matchScore*MatchBonus;
                            }
                            else
                            {
                                otherCard.IsFaceUp = false;
                                Score -= MismatchPenalty;
                            }
                        }
                    }
                    Score -= FlipCost;
                }
                card.IsFaceUp = !card.IsFaceUp;
            }
        }

        public Card CardAtindex(int index)
        {
            return index < Cards.Count ? Cards[index] : null;
        }

        private List<Card> _cards;

        public List<Card> Cards
        {
            get { return _cards ?? (_cards = new List<Card>()); }
        }

        public int Score { get; private set; }

        public CardMatchingGame(int count, Deck deck)
        {
            // TODO - Make sure count is less than deck.Count
            for (int i = 0; i < count; i++)
            {
                Card card = deck.DrawRandomCard();
                card.IsPlayable = true;
                Cards.Add(card);
            }
        }
    }
}
