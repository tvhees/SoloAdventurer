namespace Model.Player
{
    public class HandSize : Resource
    {
        private const int StartingHandSize = 5;

        public override void NewGame()
        {
            Value = StartingHandSize;
        }
    }
}