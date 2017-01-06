namespace CardGamePackage.Interfaces
{
    public interface ICommandConfig
    {
        /// <summary>
        /// The collection from which the command was triggered.
        /// </summary>
        ICardCollection Source { get; }
        /// <summary>
        /// The index of the collection element that triggered the command.
        /// </summary>
        int SourceIndex { get; }
        /// <summary>
        /// The player that triggered the command.
        /// </summary>
        ICardGamePlayer Player { get; }
    }
}