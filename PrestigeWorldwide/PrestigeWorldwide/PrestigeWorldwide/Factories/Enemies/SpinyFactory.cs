using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    public static class SpinyFactory
    {
        public static ISpiny CreateSpinyMove(Level level)
        {
            return new SpinyMove(level);
        }

        public static ISpiny CreateSpinyThrown(Level level)
        {
            return new SpinyThrown(level);
        }

        public static ISpiny CreateSpinyGetUp(Level level)
        {
            return new SpinyGetUp(level);
        }
    }
}
