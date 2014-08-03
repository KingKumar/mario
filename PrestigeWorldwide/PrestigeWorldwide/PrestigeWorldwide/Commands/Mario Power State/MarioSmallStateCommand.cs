using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide;

namespace PrestigeWorldwide.Commands
{
    class MarioSmallStateCommand : ICommand
    {
        Mario mario;
        Level level;

        public MarioSmallStateCommand(Mario mario, Level level)
        {
            this.mario = mario;
            this.level = level;
        }

        public void Execute()
        {
            mario.marioState = new SmallMarioState(mario, level);
            mario.marioState.MarioIdle();
        }
    }
}
