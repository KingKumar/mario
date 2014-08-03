using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class DarkRoom : IBackground
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
        public DarkRoom(Texture2D texture, SpriteBatch spriteBatch, int totalFrames, Vector2 location, Level level)
        {
            this.level = level;

            // Rendering
            this.Texture = texture;
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
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, BackgroundConstants.darkRoomSourceWidth, BackgroundConstants.darkRoomSourceHeight);
            Rectangle destinationRectangle = new Rectangle((int)location.X - level.camera.X, (int)location.Y - level.camera.Y, BackgroundConstants.darkRoomDestinationWidth, BackgroundConstants.darkRoomDestinationHeight);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
