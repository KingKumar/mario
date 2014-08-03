using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    class MarioBigStateCommand : ICommand
    {
        Mario mario;
        Level level;

        public MarioBigStateCommand(Mario mario, Level level)
        {
            this.mario = mario;
            this.level = level;
        }

        public void Execute()
        {
            if (mario.marioState is SmallMarioState && (!(mario.marioState is FireMarioState) || !(mario.marioState is IceMarioState)))
            {
                mario.marioState = new BigMarioState(mario, level);
            }
        }
    }
}
