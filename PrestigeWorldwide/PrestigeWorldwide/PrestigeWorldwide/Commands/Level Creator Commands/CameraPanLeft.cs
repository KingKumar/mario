using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide.Commands.Level_Creator_Commands
{
    public class CameraPanLeft : ICommand
    {
        public LevelCreator level;

        public CameraPanLeft(LevelCreator level)
        {
            this.level = level;
        }
        public void Execute()
        {
            level.camera.PanLeft();
        }

    }
}
