using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide
{
    public class LakituThrow : ILakituState
     {
        int frameDelay;
        int frameDelaySet=10;
        int currentFrame;
        int rows = 2;
        int columns = 10;
        Texture2D texture;
        int totalFrames;
        SpriteBatch spriteBatch;
        Level level;
        Rectangle collider = new Rectangle(0, 0, 0, 0);

        public LakituThrow(Level level)
        {
            this.level = level;
            this.texture = level.ContentLoad("Enemies/Lakitu/lakitu_throwing");
            this.spriteBatch = level.spriteBatch;
            totalFrames = rows * columns / 2;
            frameDelay = frameDelaySet;
        }
        public Rectangle Update(Vector2 location,int isMovingRight)
        {
            collider.Width = texture.Width / columns;
            collider.Height = texture.Height / rows;
            frameDelay--;
            if (frameDelay == 0)
            {
                
                currentFrame++;
                if (currentFrame == totalFrames / 2) { level.enemyFactory.Create_Spiny((int)location.X, (int)location.Y, isMovingRight); }
                if (currentFrame >= totalFrames - 1)
                {
                    collider.Height = 0;
                    currentFrame = 0;
                }
                frameDelay = frameDelaySet;
            }

            
            return collider;
        }
        public void Draw(Vector2 location, int isMovingRight, int isFrozen)
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int row = isMovingRight;
            int column = currentFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X-level.camera.X, (int)location.Y-level.camera.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, (isFrozen > 0) ? Color.Aquamarine : Color.White);
            spriteBatch.End();
        }
       
    }
}
