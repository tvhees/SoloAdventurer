using UnityEngine;

namespace Model.Player
{
    public class Reputation : MonoBehaviour, IResource
    {
        private Rep reputation;

        public int Value { get { return reputation.Value; } }

        public void Add(int amount)
        {
            reputation = new Rep(Value + amount);
        }

        public void NewGame()
        {
            reputation = Rep.Zero;
        }
    }
}