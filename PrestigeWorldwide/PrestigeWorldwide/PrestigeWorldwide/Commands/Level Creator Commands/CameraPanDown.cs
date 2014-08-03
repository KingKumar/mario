using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide.Commands.Level_Creator_Commands
{
    public class CameraPanDown : ICommand
    {
        public LevelCreator level;

        public CameraPanDown(LevelCreator level)
        {
            this.level = level;
        }
        public void Execute()
        {
            level.camera.PanDown();
        }

    }
}
