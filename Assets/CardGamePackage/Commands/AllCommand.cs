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
    public class AllCommand : ScriptableMultiCommand
    {
        public override IPromise Execute()
        {
            return Promise.All(Commands.Select(c => c.Execute()));
        }

        public override IPromise Undo()
        {
            return Promise.All(Commands.Select(c => c.Undo()));
        }
    }
}