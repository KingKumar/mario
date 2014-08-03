using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Sprites;
using Microsoft.Xna.Framework.Content;
using PrestigeWorldwide.Sprites.Mario;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide.Factories
{
    static class SmallMarioSpriteFactory
    {
        // New run sprite 
        public static IAnimatedSprite CreateRunningMarioSprite(int isMovingRight, Level level, int nextFrame, Vector2 location)
        {
            return new SmallMarioRunningSprite(isMovingRight, level, nextFrame, location);
        }

        // New jump sprite 
        public static IAnimatedSprite CreateJumpingMarioSprite(int isMovingRight, Level level, int nextFrame, Vector2 location)
        {
            return new SmallMarioJumpingSprite(isMovingRight, level, nextFrame, location);
        }


        // New crouch sprite 
        public static IAnimatedSprite CreateCrouchingMarioSprite(int isMovingRight, Level level, Vector2 location)
        {
            return new SmallMarioCrouchingSprite(isMovingRight, level, location);
        }

        public static IAnimatedSprite CreateIdleMarioSprite(int isMovingRight, Level level, Vector2 location)
        {
            return new SmallMarioIdleSprite(isMovingRight, level, location);
        }
    }
}
