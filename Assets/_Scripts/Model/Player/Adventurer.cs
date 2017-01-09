using CardGamePackage.Cards;
using CardGamePackage.Commands;
using CardGamePackage.Interfaces;
using Commands;
using UnityEngine;
using UnityEngine.Networking;

namespace Model.Player
{
    /// <summary>
    /// Object representing a single game player.
    /// </summary>
    public class Adventurer : MonoBehaviour, IAdventurer
    {
        [SerializeField] private string cardLoadPath;

        public ICardCollection Hand { get; private set; }
        public ICardCollection Play { get; private set; }
        public ICardCollection Deck { get; private set; }
        public ICardCollection Discard { get; private set; }

        public IResource Reputation { get; private set; }
        public IResource Movement { get; private set; }
        public IResource Influence { get; private set; }
        public IResource Attack { get; private set; }
        public IResource Block { get; private set; }
        public IResource Defense { get; private set; }
        public IResource HandSize { get; private set; }

        public string[] Resources
        {
            get
            {
                return new[]
                {
                    "Movement", Movement.Value.ToString(),
                    "Influence", Influence.Value.ToString(),
                    "Attack", Attack.Value.ToString(),
                    "Block", Block.Value.ToString()
                };
            }
        }

        /// <summary>
        /// Set up player for a new game
        /// </summary>
        public void Initialise()
        {
            CreateDecks();
            GetResources();
            DrawUpTo(HandSize.Value);
        }

        private void CreateDecks()
        {
            var cards = UnityEngine.Resources.LoadAll<CardBase>(cardLoadPath);
            this.Deck = new CardCollection(shuffle: true, collection: cards);
            this.Hand = new CardCollection();
            this.Play = new CardCollection();
            this.Discard = new CardCollection();
        }

        private void GetResources()
        {
            Movement = GetResource<Movement>();
            Influence = GetResource<Influence>();
            Reputation = GetResource<Reputation>();
            Attack = GetResource<Attack>();
            Block = GetResource<Block>();
            Defense = GetResource<Defense>();
            HandSize = GetResource<HandSize>();
        }

        private T GetResource<T>() where T : IResource
        {
            var resource = GetComponent<T>();
            resource.NewGame();
            return resource;
        }

        public void StartTurn()
        {
            Movement.NewGame();
        }

        public void EndTurn()
        {
            DrawUpTo(HandSize.Value);
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
            ((IAdventurerCommand)command).Adventurer = this;
        }
    }
}