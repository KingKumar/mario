using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide
{
    public class LevelOne : IBackground
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
        public LevelOne(Texture2D texture, SpriteBatch spriteBatch, int totalFrames,Level level)
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
            this.xPosition = 0;
            this.location = new Vector2(0, 0);
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
            location = new Vector2(xPosition, 0);
        }

        public void Draw()
        {
            int width = Texture.Width;
            int height = Texture.Height;

            Rectangle sourceRectangle = new Rectangle(0, 0, 600, 384);
            Rectangle destinationRectangle = new Rectangle(0-level.camera.X, 0-level.camera.Y, 800, 484);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
