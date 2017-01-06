using CardGamePackage.Cards;
using CardGamePackage.Interfaces;
using Commands;
using UnityEngine;

namespace Model.Player
{
    /// <summary>
    /// Object representing a single game player.
    /// </summary>
    public partial class Player : IPlayer
    {
        private const int StartingHandSize = 5;

        public ICardCollection Hand { get; private set; }
        public ICardCollection Deck { get; private set; }
        public ICardCollection Discard { get; private set; }

        /// <summary>
        /// Construct a new player set up for the start of a game.
        /// </summary>
        public Player()
        {
            this.Rep = Reputation.Zero;
            this.Deck = new CardCollection(shuffle: true, collection: Resources.LoadAll<CardBase>("Cards"));
            this.Hand = new CardCollection();
            this.Discard = new CardCollection();
            DrawUpTo(StartingHandSize);
        }

        public void StartTurn()
        {
            Movement = 0;
        }

        public void EndTurn()
        {
            DrawUpTo(HandSize);
        }

        public void Draw()
        {
            Deck.MoveCardTo(Hand, Deck.Count - 1);
        }

        public void Draw(int numberOfCards)
        {
            for (var i = 0; i < numberOfCards; i++)
                Draw();
        }

        public void DrawUpTo(int sizeLimit)
        {
            Draw(sizeLimit - Hand.Count);
        }

        public void DecorateCommand(ICommand command)
        {
            ((IAdventurerCommand)command).AdventurerPlayer = this;
        }
    }

    public partial class Player : IAdventurerPlayer
    {
        public Reputation Rep { get; private set; }
        public int Movement { get; private set; }
        public int Influence { get; private set; }
        public int Attack { get; private set; }
        public int Block { get; private set; }
        public int Defense { get; private set; }
        public int HandSize { get; private set; }

        public void AddMovement(int value)
        {
            Movement += value;
        }

        public void AddAttack(int value)
        {
            Attack += value;
        }

        public void AddBlock(int value)
        {
            Block += value;
        }

        public void AddInfluence(int value)
        {
            Influence += value;
        }

        public void AddReputation(int value)
        {
            Rep = new Reputation(Rep.Value + value);
        }
    }
}