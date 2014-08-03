using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    class KoopaSpin : IKoopaState
    {
        int frameDelay;
        int frameDelaySet=EnemyConstants.koopaSpinFrameDelay;
        int currentFrame;
        int rows = EnemyConstants.koopaSpinTextureRows;
        int columns = EnemyConstants.koopaSpinTextureColumns;
        Texture2D texture;
        int totalFrames;
        SpriteBatch spriteBatch;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        Level level;


        public KoopaSpin(Level level)
        {
            this.level = level;
            this.texture = level.ContentLoad("Enemies/Koopa/Shell_Spin");
            this.spriteBatch = level.spriteBatch;
            totalFrames = rows * columns / 2;
            frameDelay = frameDelaySet;
        }

        public Rectangle Update()
        {
            frameDelay--;
            if (frameDelay == 0)
            {
                currentFrame++;
                if (currentFrame >= totalFrames)
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
