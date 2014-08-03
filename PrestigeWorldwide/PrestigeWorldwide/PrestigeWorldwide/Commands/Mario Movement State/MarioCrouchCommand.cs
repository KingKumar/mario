using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    class MarioCrouchCommand : ICommand
    {
        Mario mario;

        public MarioCrouchCommand(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            if (!mario.isJumping && mario.canJump && !mario.stateLock)
            {
                mario.isCrouching = true;
                mario.isRunning = false;
                mario.isJumping = false;

                mario.marioState.MarioCrouch();
            }
        }

    }
}
