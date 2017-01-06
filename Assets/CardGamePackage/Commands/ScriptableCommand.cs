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
        protected ICommandConfig Config;
        public bool IsPermanent {
            get { return isPermanent; }
        }
        [SerializeField] protected bool isPermanent;
        [SerializeField] protected float Delay;
        public abstract IPromise Execute();
        public abstract IPromise Undo();

        public virtual ICommand Create(ICommandConfig config)
        {
            return Instantiate(this).Init(config);
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