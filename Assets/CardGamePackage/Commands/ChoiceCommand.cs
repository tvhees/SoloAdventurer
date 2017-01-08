using CardGamePackage.Interfaces;
using RSG;
using UnityEngine;

namespace CardGamePackage.Commands
{
    /// <summary>
    /// Container Command that returns all constituent commands as a collection wrapped in Promise.Race().
    /// </summary>
    public class ChoiceCommand : ScriptableMultiCommand
    {
        public override IPromise Execute()
        {
            throw new System.NotImplementedException();
        }

        public override IPromise Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}