using RSG;

namespace CardGamePackage.Interfaces
{
    /// <summary>
    /// Contract to implement Execute and Undo promises.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Returns the command's implementation as an IPromise.
        /// </summary>
        IPromise Execute();
        /// <summary>
        /// Returns the command's reverse implementation as an IPromise.
        /// </summary>
        IPromise Undo();
        /// <summary>
        /// Returns an instance of the command.
        /// </summary>
        ICommand Create(ICommandConfig config);
        /// <summary>
        /// Is the command impossible to Undo?
        /// </summary>
        bool IsPermanent { get; }
    }
}