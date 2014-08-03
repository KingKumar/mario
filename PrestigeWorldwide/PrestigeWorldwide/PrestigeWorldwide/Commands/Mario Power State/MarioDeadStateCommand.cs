using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    class MarioDeadStateCommand : ICommand
    {
        Mario mario;
        Level level;

        public MarioDeadStateCommand(Mario mario, Level level)
        {
            this.mario = mario;
            this.level = level;
        }

        public void Execute()
        {
            mario.marioState = new DeadMarioState(mario, level);
        }
    }
}
