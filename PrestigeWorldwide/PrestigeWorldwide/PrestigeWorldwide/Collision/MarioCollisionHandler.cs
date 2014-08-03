using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class MarioCollisionHandler
    {
        public Mario mario;
        public Level level;

        public MarioCollisionHandler(Mario mario, Level level)
        {
            this.mario = mario;
            this.level = level;
        }

        public void TakeDamage()
        {
            if (mario.marioState is SmallMarioState && mario.starPower == 0)
            {
                mario.xSpeed = 0;
                mario.ySpeed = -5;
                mario.marioState = new DeadMarioState(mario, level);
                level.game.sounds.MarioDeath();
            }
            else if (mario.marioState is BigMarioState && mario.starPower == 0)
            {
                mario.starPower = MarioConstants.starPower;
                mario.marioState = new SmallMarioState(mario, level);
                level.game.sounds.PowerDown();
            }
            else if ((mario.marioState is FireMarioState || mario.marioState is IceMarioState) && mario.starPower == 0)
            {
                mario.starPower = MarioConstants.starPower;
                mario.marioState = new BigMarioState(mario, level);
                mario.location.Y -= MarioConstants.spriteHeightCorrection;
                level.game.sounds.PowerDown();
            }
        }

        public void MarioKillEnemy()
        {
            mario.isJumping = true;
            mario.isBounce = true;
            mario.isRunning = false;
            level.gameStatus.score += MarioConstants.chainJumpMultiplier*mario.chainJump;
            mario.chainJump++;
            mario.ySpeed = 10;
            mario.canJump = true;

        }

        public void MarioSetFire()
        {
            mario.marioState = new FireMarioState(mario, level);
        }
        
        public void MarioSetBig()
        {
            if(mario.marioState is SmallMarioState)
                mario.marioState = new BigMarioState(mario, level);
        }

        public void MarioSetIce()
        {
            mario.marioState = new IceMarioState(mario, level);
        }

        public void MarioSetStar()
        {
            if(mario.starPower == 0)
                mario.starPower = MarioConstants.starDuration;
        }
    }
}
