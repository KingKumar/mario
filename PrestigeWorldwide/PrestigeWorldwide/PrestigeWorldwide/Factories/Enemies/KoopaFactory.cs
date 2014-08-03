using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PrestigeWorldwide
{
    public static class KoopaFactory
    {


        public static IKoopaState CreateMovingKoopa(Level level)
        {
            return new KoopaMove(level);
        }

        public static IKoopaState CreateSpinningKoopa(Level level)
        {
            return new KoopaSpin(level);
        }

        public static IKoopaState CreateKoopaIntoShell(Level level)
        {
            return new KoopaIntoShell(level);
        }

        public static IKoopaState CreateKoopaOutOfShell(Level level)
        {
            return new KoopaOutOfShell(level);
        }

        public static IKoopaState CreateKoopaIdle(Level level)
        {
            return new KoopaIdle(level);
        }
    }
}
