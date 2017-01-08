using System.Collections.Generic;
using CardGamePackage.Commands;
using CardGamePackage.Interfaces;
using Commands;
using UnityEngine;

namespace View
{
    public class PlayView : CardView
    {
        private ScriptableCommand discardCommand;

        protected override void Start()
        {
            base.Start();
            discardCommand = Resources.Load<DiscardCommand>("Commands/Discard");
        }

        public void EndTurn()
        {
            var config = new CommandConfig(Collection, 0, Owner);
            for (var i = 0; i < Collection.Count; i++)
            {
                CommandStack.Execute(discardCommand.Create(config));
            }
        }
    }
}