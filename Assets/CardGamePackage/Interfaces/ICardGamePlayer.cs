namespace CardGamePackage.Interfaces
{
    /// <summary>
    /// Interface defining methods for manipulating Player instances in turn-based card games.
    /// </summary>
    public interface ICardGamePlayer
    {
        /// <summary>
        /// The player's hand of cards.
        /// </summary>
        ICardCollection Hand { get; }
        /// <summary>
        /// The player's deck of cards.
        /// </summary>
        ICardCollection Deck { get; }
        /// <summary>
        /// The player's discard pile.
        /// </summary>
        ICardCollection Discard { get; }
        /// <summary>
        /// Set player attributes for a new turn.
        /// </summary>
        void StartTurn();
        /// <summary>
        /// Move a single card from the player's deck to their hand.
        /// </summary>
        void Draw();
        /// <summary>
        /// Move multiple cards from the player's deck to their hand.
        /// </summary>
        void Draw(int numberOfCards);
    }
}