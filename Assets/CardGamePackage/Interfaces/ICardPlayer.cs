using Model.Player;

namespace CardGamePackage.Interfaces
{
    /// <summary>
    /// Interface defining methods for manipulating Player instances in turn-based card games.
    /// </summary>
    public interface ICardPlayer
    {
        /// <summary>
        /// The player's hand of cards.
        /// </summary>
        ICardCollection Hand { get; }
        /// <summary>
        /// Area for cards played by player.
        /// </summary>
        ICardCollection Play { get; }
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
        /// <summary>
        /// Draw cards from deck to hand up to a specified hand size limit.
        /// </summary>
        void DrawUpTo(int sizeLimit);
        /// <summary>
        /// Clean up player attributes at end of turn.
        /// </summary>
        void EndTurn();
        /// <summary>
        /// Helper function used to link other interfaces of command and player objects.
        /// </summary>
        void DecorateCommand(ICommand command);
    }
}