using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide.Commands.Level_Creator_Commands
{
    public class CameraPanUp: ICommand
    {
        public LevelCreator level;

        public CameraPanUp(LevelCreator level)
        {
            this.level = level;
        }
        public void Execute()
        {
            level.camera.PanUp();
        }

    }
}
