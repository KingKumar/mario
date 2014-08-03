using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide
{
    class MarioJumpCommand : ICommand
    {
        Mario mario;

        public MarioJumpCommand(Mario mario)
        {
            this.mario = mario;
        }

        public void Execute()
        {
            if (!mario.isCrouching && mario.canJump && !mario.isJumping && !mario.stateLock)
            {
                mario.isJumping = true;
                mario.isRunning = false;
                mario.canJump = false;

                mario.ySpeed = 10;
                mario.marioState.MarioJump();
            }
            else { mario.marioState.MarioIdle(); }

        }
    }
    }
