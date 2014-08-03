using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide.Static_Values
{
    static class ObstacleConstants
    {
        //Brick Block Constants
        public const int brickIdleRows = 1;
        public const int brickIdleColumns = 4;
        public const int brickBumpedRows = 1;
        public const int brickBumpedColumns = 7;
        public const int brickFrameDelay = 6;
        public const int brickMinCoins = 2;
        public const int brickMaxCoins = 10;
        public const int brickBlockMidpoint = 11;
        public const int brickBumpedSpeed = 2;

        //Castle Portal Constant
        public const int segmentTwoStartPositionX = 5;
        public const int segmentTwoStartPositionY = 0;

        //Castle Brick Block Constants
        public const int castlebrickIdleRows = 1;
        public const int castlebrickIdleColumns = 4;
        public const int castlebrickBumpedRows = 1;
        public const int castlebrickBumpedColumns = 7;
        public const int castlebrickFrameDelay = 6;
        public const int castlebrickMinCoins = 2;
        public const int castlebrickMaxCoins = 10;
        public const int castlebrickBlockMidpoint = 11;
        public const int castlebrickBumpedSpeed = 2;

        //Question Block Constants
        public const int questionIdleRows = 1;
        public const int questionIdleColumns = 4;
        public const int questionBumpedRows = 1;
        public const int questionBumpedColumns = 1;
        public const int questionFrameDelay = 6;
        public const int questionBumpedSpeed = 2;

        //Brick Blocklet Constants
        public const int numOfBlocklets = 4;
        public const int blockletLifeSpan = 15;
        public const int blockletFastSpeed = 2;
        public const int blockletSlowSpeed = 1;

        //Castle Brick Blocklet Constants
        public const int castlenumOfBlocklets = 4;
        public const int castleblockletLifeSpan = 15;
        public const int castleblockletFastSpeed = 2;
        public const int castleblockletSlowSpeed = 1;
    }
}
