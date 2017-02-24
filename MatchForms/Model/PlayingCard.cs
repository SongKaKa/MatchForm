using System;
using System.Linq;

namespace MatchForms.Model
{
    public class PlayingCard : Card
    {
        private int _rank;
        private string _suit;

        /// <summary>
        ///     Valid suits for a playing card
        /// </summary>
        public static string[] ValidSuits
        {
            get { return new[] {"♠", "♣", "♥", "♦"}; }
        }

        /// <summary>
        ///     The suit of the card
        /// </summary>
        /// <remarks>A suit is one of several categories into which the cards of a deck are divided</remarks>
        public string Suit
        {
            get { return !String.IsNullOrEmpty(_suit) ? _suit : "?"; }
            set { if (value != null & ValidSuits.Contains(value)) _suit = value; }
        }

        /// <summary>
        ///     The rank of the card
        /// </summary>
        public int Rank
        {
            get { return _rank; }
            set { if (value >= 0 & value <= MaxRank) _rank = value; }
        }

        /// <summary>
        ///     Strings that go with the ranks
        /// </summary>
        public static string[] RankStrings
        {
            get { return new[] {"?", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"}; }
        }

        /// <summary>
        ///     Gets the maximum allowed rank
        /// </summary>
        public static int MaxRank
        {
            get { return RankStrings.Length - 1; }
        }

        /// <summary>
        ///     String that is on the card
        /// </summary>
        public override string Contents
        {
            get { return String.Format("{0}{1}", RankStrings[Rank], Suit); }
            // TODO - Implement setter
        }

        /// <summary>
        ///     Match PlayingCards based on Suit and Rank
        /// </summary>
        /// <param name="otherCard">Another PlayingCard</param>
        /// <returns>Goodness of match</returns>
        public override int Match(Card otherCard)
        {
            int score = 0;

            var otherPlayingCard = otherCard as PlayingCard;
            if (otherPlayingCard != null)
            {
                if (otherPlayingCard.Suit.Equals(Suit))
                    score = 1;
                else if (otherPlayingCard.Rank == Rank)
                    score = 4;
            }

            return score;
        }
    }
}