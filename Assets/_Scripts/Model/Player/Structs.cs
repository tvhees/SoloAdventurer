using UnityEngine;

namespace Model.Player
{

    /// <summary>
    /// Player movement value.
    /// </summary>
    public struct Movement
    {
        public int Value { get; private set; }
        public static Movement Zero
        {
            get { return new Movement(0); }
        }

        public Movement(int value) : this()
        {
            this.Value = value;
        }
    }

    /// <summary>
    /// Player reputation value and matching bonus/penalty to influence.
    /// </summary>
    public struct Reputation
    {
        public int Value { get; private set; }
        public int Bonus { get; private set; }

        public static Reputation Zero
        {
            get { return new Reputation(0); }
        }

        private static readonly int[] BonusTable = {-100, -5, -3, -2, -1, -1, 0, 0, 0, 1, 1, 2, 2, 3, 5};

        public Reputation(int value) : this()
        {
            this.Value = Mathf.Clamp(value, -7, 7);
            this.Bonus = BonusTable[Value + 7];
        }
    }
}