using System.Linq;
using CardGamePackage.Interfaces;
using RSG;
using UnityEngine;

namespace CardGamePackage.Commands
{
    /// <summary>
    /// Container Command that returns all constituent commands as a collection wrapped in Promise.All().
    /// </summary>
    [CreateAssetMenu(menuName = "Commands/Combined/All")]
    public class AllCommand : ScriptableCommand
    {
        [SerializeField] private ScriptableCommand[] commands;

        // 'Child' commands of the returned clone also need to be cloned and initialised.
        // This prevents writing to the ScriptableObject assets directly.
        public override ICommand Create(ICommandConfig config)
        {
            var copy = CreateInstance<AllCommand>();
            copy.commands = this.commands.Select(c => c.Create(config) as ScriptableCommand).ToArray();
            copy.SetIsPermanent();
            return copy;
        }

        /// <summary>
        /// Determine whether this command should be permanent based on constituent commands.
        /// </summary>
        // If any constituent command is permanent, this command must also be so.
        public void SetIsPermanent()
        {
            isPermanent = commands.Any(c => c.IsPermanent);
        }

        public override IPromise Execute()
        {
            return Promise.All(commands.Select(c => c.Execute()));
        }

        public override IPromise Undo()
        {
            return Promise.All(commands.Select(c => c.Undo()));
        }
    }
}