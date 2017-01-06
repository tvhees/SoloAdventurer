using CardGamePackage.Commands;
using CardGamePackage.Interfaces;
using Model.Player;
using RSG;

namespace Commands
{
    public abstract class AdventurerCommand : ScriptableCommand, IAdventurerCommand
    {
        public IAdventurerPlayer AdventurerPlayer { get; set; }

        protected override ICommand Init(ICommandConfig config)
        {
            config.Player.DecorateCommand(this);
            return base.Init(config);
        }
    }
}