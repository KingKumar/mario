using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    class MarioRunRightCommand : ICommand
    {
        Mario mario;
        int runDelay = 0;

        public MarioRunRightCommand(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            if (!mario.stateLock)
            {
                mario.isMovingRight = 1;
                if (!mario.isCrouching)
                {
                    runDelay++;
                    if (runDelay % 5 == 0)
                    {
                        mario.xSpeed += 1;
                        if (mario.xSpeed < 0) { mario.xSpeed += 1; }
                        if (mario.xSpeed >= 4) { mario.xSpeed = 4; }
                    }

                    if (mario.isJumping == false && mario.canJump == true && !mario.isRunning)
                    {
                        mario.isRunning = true;
                        mario.marioState.MarioRunRight();
                    }
                }
            }
        }
    }
}
