using UnityEngine;

namespace CardGamePackage.Interfaces
{
    public interface ICardDisplayInformation
    {
        /// <summary>
        /// Card display name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Card display colour.
        /// </summary>
        Color Colour { get; }
    }
}