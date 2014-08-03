using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    class HighLeftMovingCloud : IBackground
    {
        // Properties
        Texture2D Texture { get; set; }

        // Fields
        int currentFrame;
        int totalFrames;
        int frameDelay;
        int xPosition;
        SpriteBatch spriteBatch;
        Vector2 location;
        Level level;

        // Constructor
        public HighLeftMovingCloud(Texture2D texture, SpriteBatch spriteBatch, int totalFrames,Level level)
        {
            this.level = level;
            // Rendering
            this.Texture = texture;
            this.spriteBatch = spriteBatch;

            // Animation
            this.currentFrame = 0;
            this.frameDelay = 0;
            this.totalFrames = totalFrames;

            // Moving
            xPosition = 900;
            this.location = new Vector2(xPosition, 25);
        }

        // Methods
        public void Update()
        {
            // Reset Cloud path
            if (xPosition < 10)
            {
                xPosition = 900;
            }

            // Handle sprite animation
            frameDelay++;
            if (frameDelay == 10)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
                frameDelay = 0;
            }

            // Handle background position
            location = new Vector2(xPosition, 0);
            xPosition--;
        }

        public void Draw()
        {
            int width = Texture.Width;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(0, 0, 585, 414);
            Rectangle destinationRectangle = new Rectangle(xPosition-level.camera.X, 25-level.camera.Y, 73, 51);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }


    }
}
