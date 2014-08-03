using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide.Sprites.Mario
{
    class SmallCrouchingMarioSprite : IAnimatedSprite
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

        public SmallCrouchingMarioSprite(Texture2D crouchingMario, SpriteBatch spriteBatch, int isFacingRight)
        {
            this.spriteBatch = spriteBatch;
            this.Texture = crouchingMario;
            this.yPosition = 0;
            this.isFacingRight = isFacingRight;


            int width = Texture.Width;
            int height = Texture.Height / 2;
            int column = 1;
            int row = 2;
            sourceRectangle = new Rectangle(width * column, height * row * isFacingRight , width, height);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * 3, height * 3);
        }

        public void Update()
        {
            // There is no update for crouching mario state;
        }

        public void Draw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
