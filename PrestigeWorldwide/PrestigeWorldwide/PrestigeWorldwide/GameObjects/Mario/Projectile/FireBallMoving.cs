using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Interfaces.MarioProjectile;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide.Sprites.Mario.Projectile
{
    class FireBallMoving : IFireBallState
    {
        Texture2D texture;
        Level level;
        int currentFrame;
        int totalFrames;
        int frameDelay;
        int isMovingRight;
        Rectangle collider = new Rectangle(0, 0, 0, 0);

        public Texture2D Texture
        {
            get { return texture; }
        }

        public FireBallMoving(Level level)
        {
            this.level = level;
            this.texture = level.ContentLoad("Mario/Fire/FireBall");
            this.isMovingRight = level.mario.isMovingRight;
            this.currentFrame = 0;
            this.totalFrames = MarioConstants.fireBallMovingFrameCount;
        }

        public Rectangle Update()
        {
            frameDelay++;
            if (frameDelay == 2)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
                frameDelay = 0;
            }
            collider.Width = texture.Width / totalFrames;
            collider.Height = texture.Height / 2;
            return collider;
        }

        public void Draw(Vector2 location, int isMovingRight)
        {
            int width = texture.Width / totalFrames;
            int height = texture.Height / 2;
            int row = isMovingRight;
            int column = currentFrame;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X - level.camera.X, (int)location.Y - level.camera.Y, width, height);
            level.spriteBatch.Begin();
            level.spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            level.spriteBatch.End();
        }
    }
}
