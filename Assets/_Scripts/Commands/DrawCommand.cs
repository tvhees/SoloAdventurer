using CardGamePackage.Commands;
using RSG;
using UnityEngine;

namespace Commands
{
    [CreateAssetMenu(menuName = "Commands/Draw")]
    public class DrawCommand : ScriptableCommand
    {
        public override IPromise Execute()
        {
            return new Promise((resolve, reject) => Config.Player.Draw());
        }

        public override IPromise Undo()
        {
            return new Promise((resolve, reject) => Config.Player.Hand.MoveCardTo(Config.Player.Deck, Config.Player.Hand.Count-1));
        }
    }
}