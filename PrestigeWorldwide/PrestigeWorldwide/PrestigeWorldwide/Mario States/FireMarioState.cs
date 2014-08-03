using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Commands;
using PrestigeWorldwide.Factories;
using PrestigeWorldwide.Sprites.Mario;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    class FireMarioState : IMarioState
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

        public FireMarioState(Mario mario, Level level)
        {
            this.mario = mario;
            this.level = level;
            nextFrame = 0;
            spriteFrameCount = MarioConstants.fireMarioIdleFrameCount;
            marioSprite = FireMarioSpriteFactory.CreateIdleMarioSprite(mario.isMovingRight, level, mario.location);
        }

        public void MarioCrouch()
        {
            spriteFrameCount = MarioConstants.fireMarioCrouchFrameCount;
                marioSprite = FireMarioSpriteFactory.CreateCrouchingMarioSprite(mario.isMovingRight, level, mario.location);
        }

        public void MarioJump()
        {
            spriteFrameCount = MarioConstants.fireMarioJumpFrameCount;
            mario.jumpCount = MarioConstants.jumpCount;
            mario.location.Y -= (int)(0.5*mario.ySpeed);
            marioSprite = FireMarioSpriteFactory.CreateJumpingMarioSprite(mario.isMovingRight, level, nextFrame, mario.location);
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
                mario.isCrouching = false;
                spriteFrameCount = MarioConstants.fireMarioIdleFrameCount;
                marioSprite = FireMarioSpriteFactory.CreateIdleMarioSprite(mario.isMovingRight, level, mario.location);
            }
        }

        public void MarioRunRight()
        {
            spriteFrameCount = MarioConstants.fireMarioRunningFrameCount;
            marioSprite = FireMarioSpriteFactory.CreateRunningMarioSprite(mario.isMovingRight, level, nextFrame, mario.location);
        }

        public void MarioRunLeft()
        {
            spriteFrameCount = MarioConstants.fireMarioRunningFrameCount;
            marioSprite = FireMarioSpriteFactory.CreateRunningMarioSprite(mario.isMovingRight, level, nextFrame, mario.location);
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
                FireBall projectile = new FireBall(level, mario.isMovingRight, mario.location);
                level.marioProjectileList.Add(projectile);
                level.game.sounds.FireBall();
            }
        }
    }
}
