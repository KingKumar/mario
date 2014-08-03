﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide.Commands.Level_Creator_Commands
{
    public class CameraPanRight : ICommand
    {
        public LevelCreator level;

        public CameraPanRight(LevelCreator level)
        {
            this.level = level;
        }
        public void Execute()
        {
            level.camera.PanRight();
        }

    }
}
