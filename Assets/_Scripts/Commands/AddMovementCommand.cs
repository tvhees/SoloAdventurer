using CardGamePackage.Commands;
using Model.Player;
using RSG;
using UnityEngine;

namespace Commands
{
    [CreateAssetMenu(menuName = "Commands/Add Movement")]
    public class AddMovementCommand : AdventurerCommand
    {
        [SerializeField] private int value;

        public override IPromise Execute()
        {
            return new Promise((resolve, reject) => Adventurer.Movement.Add(value));
        }

        public override IPromise Undo()
        {
            return new Promise((resolve, reject) => Adventurer.Movement.Add(-value));
        }
    }
}