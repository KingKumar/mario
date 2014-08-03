using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class LevelCreatorCamera
    {
        public int xPos;
        public int yPos;

        public LevelCreatorCamera(int xPos, int yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }

        public void PanUp()
        {
            yPos-=5;
        }

        public void PanDown()
        {
            yPos+=5;
        }
        public void PanRight()
        {
            xPos+=5;
        }
        public void PanLeft()
        {
            xPos-=5;
        }

    }
}
