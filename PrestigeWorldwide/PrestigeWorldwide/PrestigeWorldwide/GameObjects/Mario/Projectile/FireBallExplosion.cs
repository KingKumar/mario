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
    class FireBallExplosion : IFireBallState
    {
        int totalFrame;
        int currentFrame;
        int frameDelay;
        Level level;
        Texture2D texture;
        bool isDone = false;
        Rectangle collider = new Rectangle(0, 0, 0, 0);

        public Texture2D Texture { get { return texture; } }

        public FireBallExplosion(Level level)
        {
            this.level = level;
            this.texture = level.ContentLoad("Mario/Fire/FireballExplosion");
            totalFrame = MarioConstants.fireBallExplosionFrameCount;
            currentFrame = 0;
            frameDelay = 0;
        }

        public Rectangle Update()
        {
            frameDelay++;
            if (frameDelay == 2)
            {
                currentFrame++;
                if (currentFrame == totalFrame)
                {
                    isDone = true;
                    currentFrame = 0;
                }
                frameDelay = 0;
            }
            collider.Width = 0;
            collider.Height = 0;
            return collider;
        }

        public void Draw(Vector2 location, int isMovingRight)
        {
            if (!isDone)
            {
                int width = texture.Width / totalFrame;
                int height = texture.Height;
                int column = currentFrame;

                Rectangle sourceRectangle = new Rectangle(width * column, 0, width, height);
                Rectangle destinationRectangle = new Rectangle((int)location.X - level.camera.X, (int)location.Y - level.camera.Y, width, height);
                level.spriteBatch.Begin();
                level.spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                level.spriteBatch.End();
            }
        }
    }
}
