using CardGamePackage.Interfaces;
using JetBrains.Annotations;

namespace Model.Player
{
    public interface IAdventurer : ICardPlayer
    {
        void Initialise();

        IResource Reputation { get; }
        IResource Movement { get; }
        IResource Influence { get; }
        IResource Attack { get; }
        IResource Block { get; }
        IResource Defense { get; }
        IResource HandSize { get; }
        string[] Resources { get; }
    }
}