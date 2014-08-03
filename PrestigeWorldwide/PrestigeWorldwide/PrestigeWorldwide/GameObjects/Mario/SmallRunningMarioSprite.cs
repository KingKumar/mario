using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide.Sprites.Mario
{
    class SmallRunningMarioSprite : IAnimatedSprite
    {
        // Properties
        Texture2D Texture { get; set; }

        // Fields
        int yPosition;
        int isFacingRight;
        SpriteBatch spriteBatch;
        Vector2 location;

        Rectangle sourceRectangle;
        Rectangle destinationRectangle;

        // Constructor
        public SmallRunningMarioSprite(Texture2D runningMario, SpriteBatch spriteBatch, int isFacingRight)
        {
            this.spriteBatch = spriteBatch;
            this.Texture = runningMario;
            this.yPosition = 0;
            this.isFacingRight = isFacingRight;


            int width = Texture.Width / 25;
            int height = Texture.Height / 2;
            int column = 25;
            int row = 2;
            sourceRectangle = new Rectangle(width * column, height * row * isFacingRight, width, height);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * 3, height * 3);

        }

        // Methods
        public void Update()
        {
            // Update the x, y location to be implemented
        }

        public void Draw()
        {

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
