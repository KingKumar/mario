using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide
{
    static class IceMarioSpriteFactory
    {
        // New run sprite 
        public static IAnimatedSprite CreateRunningMarioSprite(int isMovingRight, Level level, int nextFrame, Vector2 location)
        {
            return new IceMarioRunningSprite(isMovingRight, level, nextFrame, location);
        }

        // New jump sprite 
        public static IAnimatedSprite CreateJumpingMarioSprite(int isMovingRight, Level level, int nextFrame, Vector2 location)
        {
            return new IceMarioJumpingSprite(isMovingRight, level, nextFrame, location);
        }


        // New crouch sprite 
        public static IAnimatedSprite CreateCrouchingMarioSprite(int isMovingRight, Level level, Vector2 location)
        {
            return new IceMarioCrouchingSprite(isMovingRight, level, location);
        }

        public static IAnimatedSprite CreateIdleMarioSprite(int isMovingRight, Level level, Vector2 location)
        {
            return new IceMarioIdleSprite(isMovingRight, level, location);
        }
    }
}
