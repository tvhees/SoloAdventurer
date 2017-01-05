using CardGamePackage.Cards;

namespace CardGamePackage.Interfaces
{
    public interface ICard
    {
        /// <summary>
        /// Returns this card's display information.
        /// </summary>
        /// <param name="hidden">Whether the card face is hidden.</param>
        ICardDisplayInformation GetInfo(bool hidden);

        /// <summary>
        /// Returns this card's effect as an ICommand implementation.
        /// </summary>
        ICommand Effect { get; }
    }
}