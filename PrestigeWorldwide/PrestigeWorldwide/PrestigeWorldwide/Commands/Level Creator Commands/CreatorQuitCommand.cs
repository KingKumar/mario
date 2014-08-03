using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PrestigeWorldwide.Commands
{
    class CreatorQuitCommand : ICommand
    {
        public LevelCreator level;

        public CreatorQuitCommand(LevelCreator level)
        {
            this.level = level;
        }
        public void Execute()
        {
            level.Quit();
        }
    }
}