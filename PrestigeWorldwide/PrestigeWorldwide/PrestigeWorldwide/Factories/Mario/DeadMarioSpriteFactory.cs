using System;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide
{
    static class DeadMarioSpriteFactory
    {
        public static IAnimatedSprite CreateDeadMarioSprite(Level level)
        {
            return new DeadMarioSprite(level);
        }
    }
}
