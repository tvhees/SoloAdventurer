using System.Collections.Generic;
using CardGamePackage.Cards;

namespace CardGamePackage.Interfaces
{
    /// <summary>
    /// Interface defining methods for manipulating collections of cards.
    /// Cards are represented by an integer corresponding to their index in the array of all cards.
    /// </summary>
    public interface ICardCollection : IList<int>
    {
        /// <summary>
        /// Return true if this collection has no cards in it.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Return the display info of the ith card in this collection.
        /// </summary>
        ICardDisplayInformation GetInfo(int i, bool hidden = false);

        /// <summary>
        /// Return the command attached to the ith card in this collection.
        /// </summary>
        ICommand Effect(int i);

        /// <summary>
        /// Move the ith card of this collection to the end of another collection.
        /// </summary>
        void MoveCardTo(ICardCollection other, int index);

        /// <summary>
        /// Move the ith card of this collection to a specific index in another collection.
        /// </summary>
        void MoveCardTo(ICardCollection other, int index, int insertIndex);
    }
}