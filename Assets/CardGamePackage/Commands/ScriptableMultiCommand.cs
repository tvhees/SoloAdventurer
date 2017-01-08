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
            var copy = CreateInstance<AllCommand>();
            copy.Commands = this.Commands.Select(c => c.Create(config) as ScriptableCommand).ToArray();
            copy.SetIsPermanent();
            return copy;
        }

        /// <summary>
        /// Determine whether this command should be permanent based on constituent commands.
        /// </summary>
        // If any constituent command is permanent, this command must also be so.
        protected void SetIsPermanent()
        {
            isPermanent = Commands.Any(c => c.IsPermanent);
        }
    }
}