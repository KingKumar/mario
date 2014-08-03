using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Sprites;
using PrestigeWorldwide.Sprites.Mario;

namespace PrestigeWorldwide
{
    static class BigMarioSpriteFactory
    {
        public static IAnimatedSprite CreateRunningMarioSprite(int isMovingRight, Level level, int nextFrame, Vector2 location)
        {
            return new BigMarioRunningSprite(isMovingRight, level, nextFrame, location);
        }

        public static IAnimatedSprite CreateJumpingMarioSprite(int isMovingRight, Level level, int nextFrame, Vector2 location)
        {
            return new BigMarioJumpingSprite(isMovingRight, level, nextFrame, location);
        }

        public static IAnimatedSprite CreateCrouchingMarioSprite(int isMovingRight, Level level, Vector2 location)
        {
            return new BigMarioCrouchingSprite(isMovingRight, level, location);
        }

        public static IAnimatedSprite CreateIdleMarioSprite(int isMovingRight, Level level, Vector2 location)
        {
            return new BigMarioIdleSprite(isMovingRight, level, location);   
        }
    }
}
