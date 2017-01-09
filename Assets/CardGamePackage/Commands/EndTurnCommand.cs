using System;
using Microsoft.Win32;
using RSG;
using UnityEngine;

namespace CardGamePackage.Commands
{
    // TODO: Make a new interface for non-stack 'commands'
    [CreateAssetMenu(menuName = "Commands/End Turn")]
    public class EndTurnCommand : ScriptableCommand
    {
        public override IPromise Execute()
        {
            return new Promise((resolve, reject) =>
            {
                Helper.OnTurnEnded.Invoke();
            });
        }

        public override IPromise Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}