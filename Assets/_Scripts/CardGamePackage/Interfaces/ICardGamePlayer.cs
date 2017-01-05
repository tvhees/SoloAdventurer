namespace CardGamePackage.Interfaces
{
    /// <summary>
    /// Interface defining methods for manipulating Player instances in turn-based card games.
    /// </summary>
    public interface ICardGamePlayer
    {
        ICardCollection Hand { get; }
        ICardCollection Deck { get; }
        ICardCollection Discard { get; }
        void StartTurn();
        void Draw();
        void DrawMultiple(int n);
    }
}