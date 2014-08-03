using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide.Commands
{
    public class ToggleMouseCommand: ICommand
    {
         public LevelCreator level;

        public ToggleMouseCommand(LevelCreator level)
        {
            this.level = level;
        }
        public void Execute()
        {
                level.cursor.isInMouseState = !level.cursor.isInMouseState;
        }
    }
}
