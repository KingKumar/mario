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
    public class HintBlockUp
    {

        Level level;
        Vector2 location;
        int Height;
        int Width;

        public HintBlockUp(Level level, Vector2 location)
        {
            this.level = level;
            this.location = location;
            this.Width = Width;
            this.Height = Height;
        }

        private bool IsVisible()
        {
            if (location.X - level.camera.X < level.camera.width
            && location.X + Width - level.camera.X > 0
            && location.Y - level.camera.Y < level.camera.height
            && location.Y + Height - level.camera.Y > 0)
                return true;
            else
                return false;
        }

        public void Update()
        {
            if (IsVisible() == true)
            {
                if (level.camera.Y + level.camera.height - location.Y < Height)
                {
                    level.camera.Y = (int)location.Y - level.camera.height;
                }
                else
                {
                    level.camera.Y -= Height;
                }
            }
        }
    }
}