using CardGamePackage.Interfaces;
using RSG;
using UnityEngine;

namespace CardGamePackage.Commands
{
    /// <summary>
    /// Represents the ICommand interface in a storeable format.
    /// </summary>
    [System.Serializable]
    public abstract class ScriptableCommand : ScriptableObject, ICommand
    {
        public enum UndoTypes { Undoable, Permanent, BypassStack }

        protected ICommandConfig Config;

        [SerializeField] public UndoTypes UndoType;
        public bool IsPermanent {
            get { return UndoType == UndoTypes.Permanent; }
        }
        public bool IsBypassingStack {
            get { return UndoType == UndoTypes.BypassStack; }
        }

        [SerializeField] protected float Delay;
        public abstract IPromise Execute();
        public abstract IPromise Undo();

        public virtual ICommand Create(ICommandConfig config)
        {
            var command = IsBypassingStack ? this : Instantiate(this);
            return command.Init(config);
        }

        /// <summary>
        /// Initialise this command with the supplied configuration
        /// </summary>
        protected virtual ICommand Init(ICommandConfig config)
        {
            this.Config = config;
            return this;
        }
    }
}