using System.Collections;
using CardGamePackage.Commands;
using RSG;
using UnityEngine;

namespace Commands
{
    /// <Summary>
    /// Represents a Command for moving a card from hand to discard pile.
    /// </Summary>
    [CreateAssetMenu(menuName = "Commands/Discard")]
    public class DiscardCommand : ScriptableCommand
    {
        public override IPromise Execute()
        {
            return new Promise((resolved, rejected)
                => Helper.Run(ExecCoroutine()));
        }

        public override IPromise Undo()
        {
            return new Promise((resolved, rejected)
                => Helper.Run(UndoCoroutine()));
        }

        private IEnumerator ExecCoroutine()
        {
            yield return new WaitForSeconds(Delay);

            Config.Source.MoveCardTo(Config.Player.Discard, Config.SourceIndex);
        }

        private IEnumerator UndoCoroutine()
        {
            yield return new WaitForSeconds(Delay);

            Config.Player.Discard.MoveCardTo(Config.Source, Config.Player.Discard.Count-1, Config.SourceIndex);
        }
    }
}