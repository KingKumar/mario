using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide;
namespace PrestigeWorldwide
{
    class MarioFireStateCommand : ICommand 
    {

        Mario mario;
        Level level;

        public MarioFireStateCommand(Mario mario, Level level)
        {
            this.mario = mario;
            this.level = level;
        }

        public void Execute()
        {
            mario.marioState = new FireMarioState(mario, level);
            mario.marioState.MarioIdle();
        }

    }
}
