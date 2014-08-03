using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide.Commands
{
    class CursorPlaceCommand : ICommand
    {
        public LevelCreator level;

        public CursorPlaceCommand(LevelCreator level)
        {
            this.level = level;
        }
        public void Execute()
        {
        }
    }
}
