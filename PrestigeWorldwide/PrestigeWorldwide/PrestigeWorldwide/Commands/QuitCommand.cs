using System;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide
{
    public class QuitCommand : ICommand
    {
        Level level;

        public QuitCommand(Level level)
        {
            this.level = level;
        }

        // Method specific to this command
        public void Execute()
        {
            level.Quit();
        }
    }
}


