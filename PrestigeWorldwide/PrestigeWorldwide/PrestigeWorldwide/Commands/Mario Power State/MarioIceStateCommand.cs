using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    class MarioIceStateCommand : ICommand
    {
        Mario mario;
        Level level;

        public MarioIceStateCommand(Mario mario, Level level)
        {
            this.mario = mario;
            this.level = level;
        }

        public void Execute()
        {
            mario.marioState = new IceMarioState(mario, level);
            mario.marioState.MarioIdle();
        }
    }
}
