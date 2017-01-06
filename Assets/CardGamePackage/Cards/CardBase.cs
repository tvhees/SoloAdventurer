using CardGamePackage.Commands;
using CardGamePackage.Interfaces;
using UnityEngine;

namespace CardGamePackage.Cards
{
    /// <summary>
    /// Base class for all card objects.
    /// </summary>
    [CreateAssetMenu(menuName = "Cards/Base")]
    [System.Serializable]
    public class CardBase : ScriptableObject, ICard
    {
        [SerializeField] private ScriptableCommand effect;
        [SerializeField] private CardDisplayInformation openCardDisplayInformation;
        [SerializeField] private CardDisplayInformation hiddenCardDisplayInformation;

        public ICardDisplayInformation GetInfo(bool hidden){
            return hidden ? hiddenCardDisplayInformation : openCardDisplayInformation;
        }

        public ICommand Effect {
            get { return effect; }
        }
    }
}
