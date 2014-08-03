using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    class MarioRunLeftCommand : ICommand
    {
        Mario mario;
        int runDelay = 0;

        public MarioRunLeftCommand(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            if (!mario.stateLock)
            {
                mario.isMovingRight = 0;
                if (!mario.isCrouching)
                {
                    runDelay++;
                    if (runDelay % 5 == 0)
                    {
                        mario.xSpeed -= 1;
                        if (mario.xSpeed > 0) { mario.xSpeed -= 1; }
                        if (mario.xSpeed <= -4) { mario.xSpeed = -4; }
                    }
                    if (!mario.isJumping && mario.canJump && !mario.isRunning)
                    {
                        mario.isRunning = true;
                        mario.marioState.MarioRunLeft();
                    }
                }
            }
        }
    }
}
