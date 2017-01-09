using System.Linq;
using CardGamePackage.Interfaces;
using UnityEngine;

namespace CardGamePackage.Commands
{
    public abstract class ScriptableMultiCommand : ScriptableCommand
    {
        [SerializeField] protected ScriptableCommand[] Commands;

        // 'Child' commands of the returned clone also need to be cloned and initialised.
        // This prevents writing to the ScriptableObject assets directly.
        public override ICommand Create(ICommandConfig config)
        {
            //TODO: Clean up the ordering here
            var copy = CreateInstance<AllCommand>();
            copy.Commands = this.Commands.Select(c => c.Create(config) as ScriptableCommand).ToArray();
            UndoType = copy.Commands.Max(c => c.UndoType);
            return copy;
        }
    }
}