using System;
using System.Linq;
using CardGamePackage.Interfaces;
using RSG;
using UnityEngine;

namespace CardGamePackage.Commands
{
    /// <summary>
    /// Container Command that returns all constituent commands as a collection wrapped in Promise.Sequence().
    /// </summary>
    [CreateAssetMenu(menuName = "Commands/Combined/Sequence")]
    public class SequenceCommand : ScriptableMultiCommand
    {
        public override IPromise Execute()
        {
            return Promise.Sequence(Commands.Select(c => c.Execute().AsFunc()));
        }

        public override IPromise Undo()
        {
            return Promise.Sequence(Commands.Select(c => c.Undo().AsFunc()));
        }
    }
}