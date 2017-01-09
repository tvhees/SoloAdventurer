using RSG;
using UnityEngine;

namespace CardGamePackage.Commands
{
    [CreateAssetMenu(menuName = "Commands/Undo")]
    public class UndoCommand : ScriptableCommand
    {
        public override IPromise Execute()
        {
            return new Promise((resolve, reject) =>
            {
                if (CommandStack.CanUndo) CommandStack.Undo();
            });
        }

        public override IPromise Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}