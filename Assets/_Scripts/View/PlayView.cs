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
            Helper.OnTurnEnded.AddListener(DiscardAll);
        }

        private void DiscardAll()
        {
            Debug.Log(Collection.Count);
            for (var i = Collection.Count - 1; i >= 0; i--)
            {
                var config = new CommandConfig(Collection, i, Owner);
                CommandStack.Execute(discardCommand.Create(config));
            }
        }
    }
}