using System.Net.NetworkInformation;
using CardGamePackage.Interfaces;
using JetBrains.Annotations;

namespace Model.Player
{
    public interface IAdventurerPlayer
    {
        Reputation Rep { get; }
        int Movement { get; }
        int Influence { get; }
        int Attack { get; }
        int Block { get; }
        int Defense { get; }
        int HandSize { get; }

        void AddMovement(int value);
        void AddAttack(int value);
        void AddBlock(int value);
        void AddInfluence(int value);
        void AddReputation(int value);
    }
}