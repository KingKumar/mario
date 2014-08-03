using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    class StillSmallBush : IBackground
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

        // Constructor
        public StillSmallBush(Texture2D texture, SpriteBatch spriteBatch, int totalFrames)
        {
            // Rendering
            this.Texture = texture;
            this.spriteBatch = spriteBatch;

            // Animation
            this.currentFrame = 0;
            this.frameDelay = 0;
            this.totalFrames = totalFrames;

            // Moving
            xPosition = 600;
            this.location = new Vector2(xPosition, 366);
        }

        // Methods
        public void Update()
        {
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
            location = new Vector2(xPosition, 366);
        }

        public void Draw()
        {
            int width = Texture.Width;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(0, 0, 567, 292);
            Rectangle destinationRectangle = new Rectangle(xPosition, 366, 70, 45);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
