namespace MatchForms.Model
{
    /// <summary>
    ///     Generic card model
    /// </summary>
    public class Card
    {
        /// <summary>
        ///     String that is on the card
        /// </summary>
        public virtual string Contents { get; set; }

        /// <summary>
        ///     Card is face up or face down
        /// </summary>
        public bool IsFaceUp { get; set; }

        /// <summary>
        ///     Matched cards are no longer playable
        /// </summary>
        public bool IsPlayable { get; set; }

        /// <summary>
        ///     Match this card against other cards
        /// </summary>
        /// <param name="otherCard">Another card to match</param>
        /// <returns>Match score</returns>
        public virtual int Match(Card otherCard)
        {
            int score = 0;

            if (Contents != null && otherCard != null && otherCard.Contents != null &&
                Contents.Equals(otherCard.Contents))
                score = 1;

            return score;
        }
    }
}