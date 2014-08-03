using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PrestigeWorldwide.Sprites.Mario
{
    class SmallMarioRunningSpriteTest : IAnimatedSprite
    {
        // Properties
        Texture2D Texture { get; set; }

        // Fields
        int currentFrame;
        int totalFrames;
        int frameDelay;
        int isMovingRight;
        Game1 game;
        Texture2D texture;

        // Constructor
        public SmallMarioRunningSpriteTest(int isMovingRight, Game1 game, Texture2D texture, int nextFrame)
        {
            this.isMovingRight = isMovingRight;
            this.game = game;
            this.texture = texture;
            currentFrame = nextFrame;
            totalFrames = 25;
        }

        // Methods
        public void Update()
        {
            // Handle animation
            frameDelay++;
            if (frameDelay == 2)
            {
                
                //currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
                frameDelay = 0;
            }

            isMovingRight = game.mario.isMovingRight;
        }

        public void Draw()
        {
            int width = texture.Width / 25;
            int height = texture.Height / 2;
            int row = game.mario.isMovingRight;
            int column = currentFrame;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(100, 357, width, height);

            game.spriteBatch.Begin();
            game.spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            game.spriteBatch.End();
        }

    }
}
