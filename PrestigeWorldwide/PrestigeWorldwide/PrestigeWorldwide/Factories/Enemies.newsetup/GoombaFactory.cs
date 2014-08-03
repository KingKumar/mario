using System;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PrestigeWorldwide
{
    public static class GoombaFactory
    {
        public static IGoombaState CreateWalkingGoomba(Level level)
        {
            return new GoombaMovingSprite(level);
        }
        public static IGoombaState CreateDeadGoomba(Level level)
        {
            return new GoombaDeathSprite(level);
        }
    }
}
