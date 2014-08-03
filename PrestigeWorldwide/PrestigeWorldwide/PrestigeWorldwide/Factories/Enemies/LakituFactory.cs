using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    public static class LakituFactory
    {
        public static ILakituState CreateLakituMove(Level level)
        {
            return new LakituMove(level);
        }

        public static ILakituState CreateLakituThrow(Level level)
        {
            return new LakituThrow(level);
        }
    }
}
