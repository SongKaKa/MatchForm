using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MatchForms.Model;

namespace MatchForms.Controller
{
    /// <summary>
    ///     Matching cards game controller
    /// </summary>
    public class GameController
    {
        private List<Button> _cardButtons;
        private CardMatchingGame _cardMatchingGame;

        private Label ScoreLabel { get; set; }

        private Label FlipsLabel { get; set; }

        private MatchForm MatchForm { get; set; }

        private int Flips { get; set; }

        /// <summary>
        ///     Constructor that sets our reference to the View
        /// </summary>
        /// <param name="matchForm"></param>
        public GameController(MatchForm matchForm)
        {
            MatchForm = matchForm;

            InitializeComponent();
        }

        private List<Button> CardButtons
        {
            get { return _cardButtons ?? (_cardButtons = new List<Button>()); }
        }

        /// <summary>
        ///     Property that gets the CardMatchingGame model
        /// </summary>
        public CardMatchingGame CardMatchingGame
        {
            get
            {
                return _cardMatchingGame ?? (_cardMatchingGame =
                    new CardMatchingGame(CardButtons.Count, new PlayingCardDeck()));
            }
        }

        private void InitializeComponent()
        {
            // Hook up FlipCard to all buttons.
            foreach (Button button in MatchForm.Controls[0].Controls[0].Controls.OfType<Button>())
            {
                if (button.Name.EndsWith("13"))
                {
                    button.Click += Deal;
                }
                else
                {
                    button.Click += FlipCard;
                    CardButtons.Add(button);
                }
            }

            ScoreLabel = MatchForm.Controls.Find("label1", true).First() as Label ?? new Label();
            FlipsLabel = MatchForm.Controls.Find("label2", true).First() as Label ?? new Label();
            UpdateUi();
        }

        private void UpdateUi()
        {
            foreach (Button cardButton in CardButtons)
            {
                Card card = CardMatchingGame.CardAtindex(CardButtons.IndexOf(cardButton));
                cardButton.Text = card.IsFaceUp ? card.Contents : "☺";
                cardButton.Enabled = card.IsPlayable;

                ScoreLabel.Text = String.Format("Score: {0}", CardMatchingGame.Score);
                FlipsLabel.Text = String.Format("Flips: {0}", Flips);
            }
        }

        /// <summary>
        ///     Method to flip card in model when a card button is clicked
        /// </summary>
        /// <param name="sender">Button that was clicked</param>
        /// <param name="e">EventArgs unused</param>
        public void FlipCard(object sender, EventArgs e)
        {
            
            var button = sender as Button;
            if (button != null)
            {
                CardMatchingGame.FlipCardAtIndex(CardButtons.IndexOf(button));
                Flips++;
                UpdateUi();
            }
        }

        public void Deal(object sender, EventArgs e)
        {
            Flips = 0;
            _cardMatchingGame = null;           
            UpdateUi();
        }
    }
}