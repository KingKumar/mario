using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide
{
    class IceMarioJumpingSprite : IAnimatedSprite
    {

        // Fields
        int currentFrame;
        int totalFrames;
        int frameDelay;
        int isMovingRight;
        Level level;
        Texture2D texture;
        Vector2 location;

        public Texture2D Texture { get { return texture; } }

        // Constructor
        public IceMarioJumpingSprite(int isMovingRight, Level level, int nextFrame, Vector2 location)
        {
            this.isMovingRight = isMovingRight;
            this.level = level;
            this.texture = level.ContentLoad("Mario/Ice/IceJumpingMario");
            currentFrame = nextFrame;
            frameDelay = 0;
            totalFrames = 1;

            this.location = location;
        }

        // Methods
        public void Update()
        {
            // Handle animation
            frameDelay++;
            if (frameDelay == 1)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
                frameDelay = 0;
            }

            isMovingRight = level.mario.isMovingRight;
            location = level.mario.location;
        }

        public void Draw()
        {
            int width = texture.Width / 1;
            int height = texture.Height/2;
            int row = level.mario.isMovingRight;
            int column = currentFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X-level.camera.X, (int)location.Y-level.camera.Y, width, height);

            level.spriteBatch.Begin();
            level.spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White * ((level.mario.starPower + 2) % 10));
            level.spriteBatch.End();
        }
    }
}
