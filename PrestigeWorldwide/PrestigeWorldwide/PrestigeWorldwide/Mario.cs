using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Factories;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class Mario
    {
        public Level level;
        public IMarioState marioState;
        public int isMovingRight;
        public Boolean stateLock;
        public int starPower;

        public Vector2 location;
        public int xSpeed;
        public int ySpeed;
        public int gravity;
        public MarioCollisionHandler marioCollisionHandler;

        public int chainJump;

        public bool isAlive;
        public bool isCrouching;
        public bool isJumping = false;
        public bool canJump = false;
        public bool isRunning = false;
        public bool isBounce = false;
        public bool canShoot = true;

        private int fallCounter = MarioConstants.fallCounter;
        public int jumpCount = MarioConstants.jumpCount;
        private int jumpDelay = 0;
        private int idleDelay = 0;

        public Mario(Level level)
        {
            this.level = level;
            isMovingRight = 1;
            isAlive = true;
            isCrouching = false;
            chainJump = 0;
            starPower = MarioConstants.starPower;
            location = new Vector2(MarioConstants.xPos, MarioConstants.yPos); 
            xSpeed = MarioConstants.xSpeed;
            ySpeed = MarioConstants.ySpeed;
            gravity = MarioConstants.gravity;
            marioState = new SmallMarioState(this, this.level);
            marioCollisionHandler = new MarioCollisionHandler(this, level);       
        }

        public Rectangle Collider()
        {
            Rectangle collider = marioState.Collider();
            collider.X = (int)location.X;
            collider.Y = (int)location.Y;

            // Mario Doodle Jump part
            if (level.levelName == "MarioDoodleJump" && starPower > 0)
                return new Rectangle(0, 0, 0, 0);
            else
                return marioState.Collider();
        }
        
        public void Bump(int X, int Y)
        {
            fallCounter = MarioConstants.fallCounter;
            if (Y < 0 && X == 0) 
            { 
                gravity = 1;
                canJump = true;
                isJumping = false;
                isBounce = false;
            }
            location.X += X;
            location.Y += Y;
            chainJump = 0;
        }

        public void Update()
        {
            location.Y -= (ySpeed - gravity);
            jumpDelay++;
            if (jumpDelay % 5 == 0) { ySpeed--; }
            if (ySpeed < 0) { ySpeed = 0; }

            starPower--;
            if (starPower < 0) { starPower = 0; }

            fallCounter--;
            if (fallCounter == 0) { gravity = MarioConstants.gravity; }

            marioState.Update();
            location.X += xSpeed;
            idleDelay++;
            if (idleDelay % 5 == 0)
            {
                if (xSpeed > 0 && !isRunning && !isJumping &&canJump) { xSpeed--; }
                if (xSpeed < 0 && !isRunning && !isJumping && canJump) { xSpeed++; }
            }

            // Falls to death 
            if((location.X + marioState.Collider().Width < level.camera.X || location.X > level.camera.X + level.camera.width || location.Y > level.camera.Y + level.camera.height) && !(marioState is DeadMarioState))
            {
                level.game.sounds.MarioDeath();
                marioState = new DeadMarioState(this, level);
            }
        }

        public void Draw()
        {
            marioState.Draw();
        }
    }
}
