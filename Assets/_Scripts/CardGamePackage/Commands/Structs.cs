using CardGamePackage.Interfaces;

namespace CardGamePackage.Commands
{
    public struct CommandConfig : ICommandConfig
    {
        public ICardCollection Source { get; }
        public int SourceIndex { get; }
        public ICardGamePlayer Player { get; }

        public CommandConfig(ICardCollection source, int sourceIndex, ICardGamePlayer player)
        {
            Source = source;
            SourceIndex = sourceIndex;
            Player = player;
        }
    }
}