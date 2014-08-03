using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    public static class PositionRounder
    {
        public static int RoundNearestTwenty(int i)
        {
            return ((int)Math.Round(i / 22.0)) * 22;
        }
    }
}
