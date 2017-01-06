using JetBrains.Annotations;
using Model.Player;

namespace Commands
{
    public interface IAdventurerCommand
    {
        IAdventurerPlayer AdventurerPlayer { get; set; }
    }
}