using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Windows.Forms;

namespace PrestigeWorldwide
{
    public class Camera
    {

        Level level;
        int destX;
        public int destY;
        public int X;
        public int Y;
        public int height;
        public int width;
        public int screenRegion = 1;
        bool isCastle = false;
        public int customXLock = 0;
        public int customYLock = -50;

        public Camera(Level level,int width, int height)
        {
            this.level = level;
            this.width = width;
            this.height = height;
        }

        public void Update()
        {
            if (level.levelName == "CastleLevel" && isCastle == false) 
            {
                screenRegion = 3;
                isCastle = true;
            }
            if (level.levelName != "MarioDoodleJump")
            {
                destX += level.trap.X - 250;
                destY += level.trap.Y - 100;
                X += (destX - X);
                Y += (destY - Y);
                destX = 0;
                destY = 0;
            }

            if (screenRegion == 1)
            {
                if (Y > customYLock) { Y = customYLock; }
                //if (Y < -50) { Y = -50; }
                if (X < customXLock) { X = customXLock; }
            }
            if (screenRegion == 2)
            {
                if (Y > 500) { Y = 500; }
                if (Y < 440) { Y = 440; }
                if (X < 0) { X = 0; }
                if (X > 40) { X = 40; }
            }
            if (screenRegion == 3)
            {
                if (Y < -50) { Y = -50; }
                if (Y > 440) { Y = 440; }
                if (X < 0) { X = 0; }
                if (X > 2220) { X = 2220; }
            }
            if (screenRegion == 4)
            {
                if (X > 3220) { X = 3220; }
            }
             
        }
    }
}