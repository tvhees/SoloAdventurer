using UnityEngine;

namespace Model.Player
{
    /// <summary>
    /// Player reputation value and matching bonus/penalty to influence.
    /// </summary>
    public struct Rep
    {
        public int Value { get; private set; }
        public int Bonus { get; private set; }

        public static Rep Zero
        {
            get { return new Rep(0); }
        }

        private static readonly int[] BonusTable = {-100, -5, -3, -2, -1, -1, 0, 0, 0, 1, 1, 2, 2, 3, 5};

        public Rep(int value) : this()
        {
            this.Value = Mathf.Clamp(value, -7, 7);
            this.Bonus = BonusTable[Value + 7];
        }
    }
}