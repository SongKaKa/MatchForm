namespace MatchForms.Model
{
    internal class PlayingCardDeck : Deck
    {
        /// <summary>
        ///     Default construct a PlayingCardDeck
        /// </summary>
        public PlayingCardDeck()
        {
            foreach (string suit in PlayingCard.ValidSuits)
            {
                for (int rank = 1; rank <= PlayingCard.MaxRank; rank++)
                {
                    var card = new PlayingCard {Rank = rank, Suit = suit};
                    AddCard(card, true);
                }
            }
        }
    }
}