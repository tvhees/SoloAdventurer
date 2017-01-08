using Model.Player;

namespace Commands
{
    public interface IAdventurerCommand
    {
        IAdventurer Adventurer { get; set; }
    }
}