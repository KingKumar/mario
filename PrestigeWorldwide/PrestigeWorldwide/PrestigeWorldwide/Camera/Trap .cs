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
    public class Trap
    {
        Level level;
        Rectangle trapBorder = new Rectangle(0, 0, 0, 0);
        Rectangle marioCollider = new Rectangle(0, 0, 0, 0);
        Mario mario;

        public Trap(Level level,int width,int height,Vector2 location)
        {
            this.level = level;
            this.mario = level.mario;
            trapBorder.Width = width;
            trapBorder.Height = height;
            trapBorder.X = (int)location.X;
            trapBorder.Y = (int)location.Y;
        }

        public int X { get { return trapBorder.X; } }
        public int Y { get { return trapBorder.Y; } }

        public void Update()
        {
            marioCollider = mario.Collider();
            if (marioCollider.X + marioCollider.Width > trapBorder.X + trapBorder.Width)
            {
                //Adjust lookahead
                trapBorder.X += (marioCollider.X + marioCollider.Width) - (trapBorder.X + trapBorder.Width);
            }
            if (marioCollider.X < trapBorder.X)
            {
                //Adjust lookahead
                trapBorder.X += marioCollider.X - trapBorder.X;
            }
            if (marioCollider.Y + marioCollider.Height > trapBorder.Y + trapBorder.Height)
            {
                trapBorder.Y += (marioCollider.Y + marioCollider.Height) - (trapBorder.Y + trapBorder.Height);
            }
            if (marioCollider.Y < trapBorder.Y)
            {
                trapBorder.Y += marioCollider.Y - trapBorder.Y;
            }
        }
    }
}