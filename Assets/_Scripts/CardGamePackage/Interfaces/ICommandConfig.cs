namespace CardGamePackage.Interfaces
{
    public interface ICommandConfig
    {
        ICardCollection Source { get; }
        int SourceIndex { get; }
        ICardGamePlayer Player { get; }
    }
}