using UnityEngine;

namespace Model.Player
{
    public interface IResource
    {
        /// <summary>
        /// Current value of the resource.
        /// </summary>
        int Value { get; }
        /// <summary>
        /// Increase value by specified amount.
        /// </summary>
        void Add(int amount);
        /// <summary>
        /// Return to base value.
        /// </summary>
        void NewGame();
    }

    public abstract class Resource : MonoBehaviour, IResource
    {
        public int Value { get; protected set; }
        public void Add(int amount)
        {
            Value += amount;
        }

        public virtual void NewGame()
        {
            Value = 0;
        }
    }
}