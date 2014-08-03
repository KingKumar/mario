using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    // This state will return the same sprite for all commands
    // Only implements IMarioState so it can be recognized from Mario.marioState
    class DeadMarioState : IMarioState
    {
        Mario mario;
        Level level;
        IAnimatedSprite marioSprite;
        int deathAnimation;
        Rectangle collider = new Rectangle(0, 0, 0, 0);

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

        public DeadMarioState(Mario mario, Level level)
        {
            this.mario = mario;
            this.level = level;
            deathAnimation = MarioConstants.deathAnimation;
            marioSprite = DeadMarioSpriteFactory.CreateDeadMarioSprite(level);
            level.gameStatus.lifeCount--;
            collider.Height = marioSprite.Texture.Height;
            collider.Width = marioSprite.Texture.Width;
            collider.X = (int)mario.location.X;
            collider.Y = (int)mario.location.Y;

        }

        public void MarioRunLeft(){}
        public void MarioRunRight(){}
        public void MarioCrouch(){}
        public void MarioJump(){}


        public void MarioIdle()
        {
            marioSprite = DeadMarioSpriteFactory.CreateDeadMarioSprite(level);
        }

        public Rectangle Collider()
        {
            return collider;
        }

        public void Update()
        {
            if (deathAnimation == 0)
            {
                level.mario.isAlive = false;
            }
            deathAnimation--;
        }

        public void Draw()
        {
           marioSprite.Draw();
        }

        public void MarioShoot(){}
    }
}
