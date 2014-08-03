using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Sprites.Mario;

namespace PrestigeWorldwide.Factories
{
    static class FireMarioSpriteFactory
    {
        // New run sprite 
        public static IAnimatedSprite CreateRunningMarioSprite(int isMovingRight, Level level, int nextFrame, Vector2 location)
        {
            return new FireMarioRunningSprite(isMovingRight, level, nextFrame, location);
        }

        // New jump sprite 
        public static IAnimatedSprite CreateJumpingMarioSprite(int isMovingRight, Level level, int nextFrame, Vector2 location)
        {
            return new FireMarioJumpingSprite(isMovingRight, level, nextFrame, location);
        }

        // New crouch sprite 
        public static IAnimatedSprite CreateCrouchingMarioSprite(int isMovingRight, Level level, Vector2 location)
        {
            return new FireMarioCrouchingSprite(isMovingRight, level, location);
        }

        public static IAnimatedSprite CreateIdleMarioSprite(int isMovingRight, Level level, Vector2 location)
        {
            return new FireMarioIdleSprite(isMovingRight, level, location);
        }
    }
}
