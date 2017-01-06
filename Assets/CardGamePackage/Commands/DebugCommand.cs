using System.Collections;
using RSG;
using UnityEngine;

namespace CardGamePackage.Commands
{
    /// <Summary>
    /// Represents a Command for printing a generic debug messages.
    /// </Summary>
    [CreateAssetMenu(menuName = "Commands/Debug")]
    public class DebugCommand : ScriptableCommand
    {
        public override IPromise Execute()
        {
            return new Promise((resolve, reject)
                => CrHelper.Run(ExecCoroutine()));
        }

        public override IPromise Undo()
        {
            return new Promise((resolve, reject)
                => CrHelper.Run(UndoCoroutine()));
        }

        private IEnumerator ExecCoroutine()
        {
            yield return new WaitForSeconds(Delay);

            Debug.Log("Executing debug command");
        }

        private IEnumerator UndoCoroutine()
        {
            yield return new WaitForSeconds(Delay);

            Debug.Log("Undoing debug command");
        }
    }
}