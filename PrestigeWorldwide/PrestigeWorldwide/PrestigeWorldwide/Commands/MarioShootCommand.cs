using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide.Commands
{
    class MarioShootCommand:ICommand
    {
        Mario mario;

        public MarioShootCommand(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            mario.marioState.MarioShoot();
        }
    }
}
