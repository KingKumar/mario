using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide
{
    class DeadMarioSprite : IAnimatedSprite
    {
        // Fields
        private Level level;
        private Texture2D texture;
        Vector2 location;


        public Texture2D Texture { get { return texture; } }

        public DeadMarioSprite(Level level)
        {
            this.level = level;
            texture = level.ContentLoad("Mario/Dead/DeadMario");
            this.location = level.mario.location;

        }

        public void Update()
        {


        }

        public void Draw()
        {
            int width = texture.Width;
            int height = texture.Height;
            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X - level.camera.X, (int)location.Y -level.camera.Y, width, height);
            level.spriteBatch.Begin();
            level.spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            level.spriteBatch.End();
        }
    }
}
