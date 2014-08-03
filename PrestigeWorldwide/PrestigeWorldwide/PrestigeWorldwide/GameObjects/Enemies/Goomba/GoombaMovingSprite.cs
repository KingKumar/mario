using System;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
   public class GoombaMovingSprite : IGoombaState
    {
        // Fields
        int currentFrame = 0;
        int rows = EnemyConstants.movingGoombaTextureRows;
        int columns = EnemyConstants.movingGoombaTextureColumns;
        int totalFrames;
        int frameDelay;
        int frameDelaySet = EnemyConstants.goombaFrameDelaySet;
        Level level;
        Texture2D texture;
        SpriteBatch spriteBatch;
        Rectangle collider = new Rectangle(0, 0, 0, 0);

        // Constructor
        public GoombaMovingSprite(Level level)
        {
            this.level = level;
            this.texture = level.ContentLoad("Enemies/Goomba/goomba_walk");
            totalFrames = rows*columns/2;
            frameDelay = frameDelaySet;
        }

        // Methods
        public Rectangle Update()
        {
            // Handle animation
            frameDelay--;
            if (frameDelay == 0)
            {

                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
                frameDelay = frameDelaySet;
            }
            collider.Width = texture.Width / columns;
            collider.Height = texture.Height / rows;
            return collider;
        }

        public void Draw(Vector2 location,int isMovingRight, int isFrozen)
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int column = isMovingRight;
            int row = currentFrame;

            int speed = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 100;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X-level.camera.X, (int)location.Y-level.camera.Y, width, height);

            level.spriteBatch.Begin();
            level.spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, (isFrozen > 0) ? Color.Aquamarine : Color.White);
            level.spriteBatch.End();
        }
    }
}
