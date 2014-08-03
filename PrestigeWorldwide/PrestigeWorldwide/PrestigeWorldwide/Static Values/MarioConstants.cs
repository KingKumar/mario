using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide.Static_Values
{
    static class MarioConstants
    {
        // Generic Mario field accounts
        public const int xPos = 50;
        public const int yPos = 100;
        public const int lifeCount = 3;
        public const int xSpeed = 0;
        public const int ySpeed = 4;
        public const int gravity = 5;
        public const int jumpCount = 50;
        public const int fallCounter = 10;
        public const int starPower = 100;
        public const int starDuration = 1000;

        // Mario State Constants 
        public const int spriteHeightCorrection = 22;
        public const int marioKillScore = 100;
        public const int mushroomScore = 1000;
        public const int flowerScore = 1500;
        public const int chainJumpMultiplier = 200;
        public const int coinScore = 100;
        public const int coinLifeGain = 100;
        public const int starScore = 500;
        
        public const int bigMarioIdleFrameCount = 1;
        public const int bigMarioCrouchFrameCount = 1;
        public const int bigMarioJumpFrameCount = 18;
        public const int bigMarioRunningFrameCount = 25;


        public const int fireMarioIdleFrameCount = 1;
        public const int fireMarioCrouchFrameCount = 1;
        public const int fireMarioJumpFrameCount = 8;
        public const int fireMarioRunningFrameCount = 8;

        public const int iceMarioIdleFrameCount = 1;
        public const int iceMarioCrouchFrameCount = 1;
        public const int iceMarioJumpFrameCount = 1;
        public const int iceMarioRunningFrameCount = 8;

        public const int smallMarioIdleFrameCount = 1;
        public const int smallMarioCrouchFrameCount = 1;
        public const int smallMarioJumpFrameCount = 18;
        public const int smallMarioRunningFrameCount = 25;

        public const int deathAnimation = 300;

        // Mario Projectile Constants
        public const int explosionDuration = 100;
        public const int bounce = 5;

        public const int fireBallMovingFrameCount = 8;
        public const int fireBallExplosionFrameCount = 7;

        public const int iceBallMovingFrameCount = 6;
        public const int iceBallExplosionFrameCount = 7;
    }
}
