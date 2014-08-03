using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class Flag : IBackground
    {
        // Properties
        Texture2D Texture { get; set; }

        // Fields
        SpriteBatch spriteBatch;
        Vector2 location;
        Level level;

        // Constructor
        public Flag(Texture2D texture, SpriteBatch spriteBatch, Vector2 location, Level level)
        {
            this.level = level;
            // Rendering
            this.Texture = texture;
            this.spriteBatch = spriteBatch;

            // Moving and Position
            this.location = location;
        }

        // Methods
        public void Update()
        {
            if (level.victoryAnimation.isPlaying && location.Y < 325)
            {
                location.Y++;
            }
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, BackgroundConstants.flagSourceWidth, BackgroundConstants.flagSourceHeight);
            Rectangle destinationRectangle = new Rectangle((int)location.X - level.camera.X, (int)location.Y - level.camera.Y, BackgroundConstants.flagDestinationWidth, BackgroundConstants.flagDestinationHeight);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }


    }
}
