using CardGamePackage.Interfaces;

namespace CardGamePackage.Commands
{
    /// <summary>
    /// Struct containing input information for ICommand implementations.
    /// </summary>
    public struct CommandConfig : ICommandConfig
    {
        public ICardCollection Source { get { return source; } }
        public int SourceIndex { get { return sourceIndex; } }
        public ICardPlayer Player { get { return player; } }

        private readonly ICardCollection source;
        private readonly int sourceIndex;
        private readonly ICardPlayer player;

        public CommandConfig(ICardCollection source, int sourceIndex, ICardPlayer player)
        {
            this.source = source;
            this.sourceIndex = sourceIndex;
            this.player = player;
        }
    }
}