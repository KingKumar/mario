using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide.GameMenus
{
    public class GameScoreManager
    {
        private int coin;
        private int score;

        int Coin
        {
            get
            { return coin; }
            set
            { coin = value; }
        }

        int Score
        {
            get { return score; }
            set { score = value; }
        }
        public GameScoreManager()
        {
            coin = 0;
            score = 0;
        }
    }
}
