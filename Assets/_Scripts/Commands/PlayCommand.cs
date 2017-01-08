using CardGamePackage.Commands;
using RSG;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

namespace Commands
{
    [CreateAssetMenu(menuName = "Commands/Play")]
    public class PlayCommand : ScriptableCommand
    {
        public override IPromise Execute()
        {
            return new Promise((resolve, reject)
                => Config.Source.MoveCardTo(Config.Player.Play, Config.SourceIndex));
        }

        public override IPromise Undo()
        {
            return new Promise((resolve, reject)
                => Config.Player.Play.MoveCardTo(Config.Source, 0, Config.SourceIndex));
        }
    }
}