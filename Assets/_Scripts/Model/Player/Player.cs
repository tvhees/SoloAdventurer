using CardGamePackage.Cards;
using CardGamePackage.Interfaces;
using UnityEngine;

namespace Model.Player
{
    /// <summary>
    /// Object representing a single game player.
    /// </summary>
    public class Player : ICardGamePlayer
    {
        private Reputation reputation;
        private Movement movement;
        private const int StartingHandSize = 5;

        public ICardCollection Hand { get; private set; }
        public ICardCollection Deck { get; private set; }
        public ICardCollection Discard { get; private set; }

        /// <summary>
        /// Construct a new player set up for the start of a game.
        /// </summary>
        public Player()
        {
            this.reputation = Reputation.Zero;
            this.movement = Movement.Zero;
            this.Deck = new CardCollection(shuffle: true, collection: Resources.LoadAll<CardBase>("Cards"));
            this.Hand = new CardCollection();
            this.Discard = new CardCollection();
            Draw(StartingHandSize);
        }

        #region ICardGamePlayer

        /// <summary>
        /// Set player properties for a new turn.
        /// </summary>
        public void StartTurn()
        {
            movement = Movement.Zero;
        }

        /// <summary>
        /// Draw the top card of the player's deck to hand.
        /// </summary>
        public void Draw()
        {
            Deck.MoveCardTo(Hand, Deck.Count-1);
        }

        /// <summary>
        /// Draw the first n cards of the player's deck to hand.
        /// </summary>
        public void Draw(int numberOfCards)
        {
            for (var i = 0; i < numberOfCards; i++)
                Draw();
        }

        #endregion ICardGamePlayer
    }
}