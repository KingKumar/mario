using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Factories;
using PrestigeWorldwide.Commands;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    class BigMarioState : IMarioState
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
            { return marioSprite; }
            set
            { marioSprite = value; }
        }

        public BigMarioState(Mario mario, Level level)
        {
            this.mario = mario;
            this.level = level;
            nextFrame = 0;
            spriteFrameCount = MarioConstants.bigMarioIdleFrameCount;
            marioSprite = BigMarioSpriteFactory.CreateIdleMarioSprite(mario.isMovingRight, level, mario.location);
        }

        public void MarioCrouch()
        {
            spriteFrameCount = MarioConstants.bigMarioCrouchFrameCount;
                marioSprite = BigMarioSpriteFactory.CreateCrouchingMarioSprite(mario.isMovingRight, level, mario.location);
        }

        public void MarioJump()
        {
                mario.jumpCount = MarioConstants.jumpCount;
                spriteFrameCount = MarioConstants.bigMarioJumpFrameCount;

                marioSprite = BigMarioSpriteFactory.CreateJumpingMarioSprite(mario.isMovingRight, level, nextFrame, mario.location);
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
                spriteFrameCount = MarioConstants.bigMarioIdleFrameCount;
                marioSprite = BigMarioSpriteFactory.CreateIdleMarioSprite(mario.isMovingRight, level, mario.location);
            }
        }

        public void MarioRunRight()
        {
                spriteFrameCount = MarioConstants.bigMarioRunningFrameCount;
                marioSprite = BigMarioSpriteFactory.CreateRunningMarioSprite(mario.isMovingRight, level, nextFrame, mario.location);
        }

        public void MarioRunLeft()
        {
            spriteFrameCount = MarioConstants.bigMarioRunningFrameCount;
                marioSprite = BigMarioSpriteFactory.CreateRunningMarioSprite(mario.isMovingRight, level, nextFrame, mario.location);
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
        {        }

        public Rectangle ColliderProperty
        { get
            { return collider; }
            set
            { collider = value; }
        }
 }
}
