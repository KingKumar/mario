using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide.Static_Values
{
    static class EnemyConstants
    {
        //Enemy Shared Variables
        public const int isMovingRight = 0;
        public const int fallCounter = 5;

        //Goomba Variables
        public const int goombaFrameDelaySet = 5;
        public const int movingGoombaTextureRows = 8;
        public const int movingGoombaTextureColumns = 2;
        public const int deadGoombaTextureRows = 2;
        public const int deadGoombaTextureColumns = 1;
        public const int deadGoombaFrameDelayMax = 10;
        public const int goombaXPos = 1;
        public const int goombaYPos = 1;

        //Koopa Variables
        public const int koopaIdleFrameDelaySet = 2;
        public const int koopaIdleTextureRows = 2;
        public const int koopaIdleTextureColumns = 6;

        public const int koopaMoveTextureRows = 2;
        public const int koopaMoveTextureColumns = 8;
        public const int koopaMoveFrameDelay = 2;

        public const int koopaIntoShellTextureRows = 2;
        public const int koopaIntoShellTextureColumns = 6;
        public const int koopaIntoShellFrameDelay = 5;

        public const int koopaOutOfShellTextureRows = 2;
        public const int koopaOutOfShellTextureColumns = 6;
        public const int koopaOutOfShellFrameDelay = 5;

        public const int koopaSpinTextureRows = 2;
        public const int koopaSpinTextureColumns = 6;
        public const int koopaSpinFrameDelay = 2;

        public const int koopaXPos = 1;
        public const int koopaYPos = 1;
        
    }
}
