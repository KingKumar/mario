using System;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PrestigeWorldwide.Sprites.Enemies.Goomba
{
    class GoombaMovingSprite : IEnemy
    {
        // Fields
        int currentFrame = 0;
        int totalFrames;
        int frameDelay;
        int isMovingRight;
        Game1 game;
        Texture2D texture;

        Vector2 location;

        public Texture2D Texture { get { return texture; } }

        // Constructor
        public GoombaMovingSprite(int isMovingRight, Game1 game, Vector2 location)
        {
            this.isMovingRight = isMovingRight;
            this.game = game;
            this.texture = game.Content.Load<Texture2D>("Enemies/Goomba/goomba_walk_left");
            totalFrames = 8;
            this.location = location;
        }

        // Methods
        public void Update()
        {
            // Handle animation
            frameDelay++;
            if (frameDelay == 2)
            {

                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
                frameDelay = 0;
            }
        }

        public void Draw()
        {
            int width = texture.Width / 25;
            int height = texture.Height / 2;
            int row = this.isMovingRight;
            int column = currentFrame;

            int speed = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 100;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            game.spriteBatch.Begin();
            game.spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            game.spriteBatch.End();
        }
    }
}
