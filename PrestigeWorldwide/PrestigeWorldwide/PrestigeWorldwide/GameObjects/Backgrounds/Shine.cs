using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class Shine : IBackground
    {
        // Properties
        Texture2D texture { get; set; }

        // Fields
        int currentFrame;
        int totalFrames;
        int frameDelay;
        SpriteBatch spriteBatch;
        Vector2 location;
        Level level;

        // Constructor
        public Shine(Texture2D texture, SpriteBatch spriteBatch, int totalFrames, Vector2 location,Level level)
        {
            this.level = level;

            // Rendering
            this.texture = texture;
            this.spriteBatch = spriteBatch;

            // Animation
            this.currentFrame = 0;
            this.frameDelay = 0;
            this.totalFrames = totalFrames;

            // Moving and Position
            this.location = location;
        }

        // Methods
        public void Update()
        {
            // Reset Shine path
            if (location.X < -10)
            {
                location.X = BackgroundConstants.shineResetX;
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
            // location.X--;
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, BackgroundConstants.shineSourceWidth, BackgroundConstants.shineSourceHeight);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, BackgroundConstants.shineDestinationWidth, BackgroundConstants.shineDestinationHeight);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }


    }
}
