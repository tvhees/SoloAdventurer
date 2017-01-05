using CardGamePackage.Interfaces;
using UnityEngine;

namespace CardGamePackage.Cards
{
    /// <summary>
    /// Struct containing display data for a card.
    /// </summary>
    [System.Serializable]
    public struct CardDisplayInformation : ICardDisplayInformation
    {
        public string Name {
            get { return name; }
        }

        public Color Colour {
            get { return colour; }
        }

        [SerializeField] private string name;
        [SerializeField] private Color colour;

        public CardDisplayInformation(string name, Color colour) : this()
        {
            this.name = name;
            this.colour = colour;
        }
    }
}
