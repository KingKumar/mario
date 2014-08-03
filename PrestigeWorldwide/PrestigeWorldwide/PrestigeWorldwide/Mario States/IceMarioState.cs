using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Sprites.Mario;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    class IceMarioState : IMarioState
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

        public IceMarioState(Mario mario, Level level)
        {
            this.mario = mario;
            this.level = level;
            nextFrame = 0;
            spriteFrameCount = MarioConstants.iceMarioIdleFrameCount;
            marioSprite = IceMarioSpriteFactory.CreateIdleMarioSprite(mario.isMovingRight, level, mario.location);
        }

        public void MarioCrouch()
        {
            spriteFrameCount = MarioConstants.iceMarioCrouchFrameCount;
            marioSprite = IceMarioSpriteFactory.CreateCrouchingMarioSprite(mario.isMovingRight, level, mario.location);
        }

        public void MarioJump()
        {
            spriteFrameCount = MarioConstants.iceMarioJumpFrameCount;
            mario.jumpCount = MarioConstants.jumpCount;
            mario.location.Y -= (4*mario.ySpeed);
            marioSprite = IceMarioSpriteFactory.CreateJumpingMarioSprite(mario.isMovingRight, level, nextFrame, mario.location);
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
                mario.isRunning = false;
                spriteFrameCount = MarioConstants.iceMarioIdleFrameCount;
                mario.isCrouching = false;
                marioSprite = IceMarioSpriteFactory.CreateIdleMarioSprite(mario.isMovingRight, level, mario.location);
            }
        }

        public void MarioRunRight()
        {
            spriteFrameCount = MarioConstants.iceMarioRunningFrameCount;
            marioSprite = IceMarioSpriteFactory.CreateRunningMarioSprite(mario.isMovingRight, level, nextFrame, mario.location);
        }

        public void MarioRunLeft()
        {
            spriteFrameCount = MarioConstants.iceMarioRunningFrameCount;
            marioSprite = IceMarioSpriteFactory.CreateRunningMarioSprite(mario.isMovingRight, level, nextFrame, mario.location);
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
            if (mario.canShoot)
            {
                mario.canShoot = false;
                IceBall projectile = new IceBall(level, mario.isMovingRight, mario.location);
                level.marioProjectileList.Add(projectile);
                level.game.sounds.FireBall();

            }
        }
    }
}
