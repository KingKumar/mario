using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PrestigeWorldwide.Commands;
using PrestigeWorldwide.Factories;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    class SmallMarioState : IMarioState
    {
        Mario mario;
        Level level;
        int nextFrame;
        int spriteFrameCount;
        IAnimatedSprite marioSprite;
        public Rectangle collider = new Rectangle(0, 0, 0, 0);

        public IAnimatedSprite MarioSprite
        {
            get
            {
                return marioSprite;
            }
            set
            {
                marioSprite = value;
            }
        }

        public SmallMarioState(Mario mario, Level level)
        {
            this.mario = mario;
            this.level = level;
            nextFrame = 0;
            spriteFrameCount = MarioConstants.smallMarioIdleFrameCount;
            marioSprite = SmallMarioSpriteFactory.CreateIdleMarioSprite(mario.isMovingRight, level, mario.location);
        }

        public void MarioCrouch()
        {
            spriteFrameCount = MarioConstants.smallMarioCrouchFrameCount;
            marioSprite = SmallMarioSpriteFactory.CreateCrouchingMarioSprite(mario.isMovingRight, level, mario.location);
        }

        public void MarioJump()
        {
            spriteFrameCount = MarioConstants.smallMarioJumpFrameCount;
            mario.jumpCount = MarioConstants.jumpCount;
            mario.location.Y -= (mario.ySpeed);
            marioSprite = SmallMarioSpriteFactory.CreateJumpingMarioSprite(mario.isMovingRight, level, nextFrame, mario.location);
            level.game.sounds.MarioJump();
        }

        public void MarioIdle()
        {
            if (mario.isJumping == false)
            {
                if (mario.isCrouching == true)
                {
                    mario.location.Y -= MarioConstants.spriteHeightCorrection;
                }
                mario.isCrouching = false;
                mario.isRunning = false;
                spriteFrameCount = MarioConstants.smallMarioIdleFrameCount;
                marioSprite = SmallMarioSpriteFactory.CreateIdleMarioSprite(mario.isMovingRight, level, mario.location);
            }
        }

        public void MarioRunRight()
        {
            spriteFrameCount = MarioConstants.smallMarioRunningFrameCount;
            marioSprite = SmallMarioSpriteFactory.CreateRunningMarioSprite(mario.isMovingRight, level, nextFrame, mario.location);
        }

        public void MarioRunLeft()
        {
            spriteFrameCount = MarioConstants.smallMarioRunningFrameCount;
            marioSprite = SmallMarioSpriteFactory.CreateRunningMarioSprite(mario.isMovingRight, level, nextFrame, mario.location);
        }

        public Rectangle Collider()
        {
            collider.Height = marioSprite.Texture.Height/2;
            collider.Width = marioSprite.Texture.Width/spriteFrameCount;
            collider.X = (int)mario.location.X;
            collider.Y = (int)mario.location.Y;
            return collider;
        }
        public void Update()
        {
            marioSprite.Update();
        }

        public void Draw()
        {
            marioSprite.Draw();
        }

        public void MarioShoot()
        {
        }
    }
}
