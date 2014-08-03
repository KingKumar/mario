//using System;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class GoombaDeathSprite : IGoombaState
    {
        // Fields
        int currentFrame = 0;
        int totalFrames;
        int frameDelay;
        int rows=EnemyConstants.deadGoombaTextureRows;
        int columns=EnemyConstants.deadGoombaTextureColumns;
        Level level;
        Texture2D texture;
        SpriteFont font;
        Rectangle collider = new Rectangle(0, 0, 0, 0);

        // Constructor
        public GoombaDeathSprite(Level level)
        {
            this.level = level;
            this.texture = level.ContentLoad("Enemies/Goomba/goomba_death");
            this.font = level.game.Content.Load<SpriteFont>("actions");
            totalFrames = rows*columns;
            collider.Width = texture.Width / columns;
            collider.Height = texture.Height / rows;
        }

        // Methods
        public Rectangle Update()
        {
            // Handle animation
            frameDelay++;
            if (frameDelay == EnemyConstants.deadGoombaFrameDelayMax)
            {
                currentFrame++;
                
                if (currentFrame == totalFrames)
                {
                    collider.Height = 0;
                    currentFrame = 0;
                }
                frameDelay = 0;
            }
            
            return collider;
        }

        public void Draw(Vector2 location,int isMovingRight, int isFrozen)
        {
            int width = texture.Width / columns;
            int height = texture.Height / rows;
            int row = currentFrame;
            int column = 0;

            int speed = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 100;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X-level.camera.X, (int)location.Y-level.camera.Y, width, height);

            level.spriteBatch.Begin();
            Vector2 temp = location;
            temp.X -= level.camera.X + 10;
            temp.Y -= level.camera.Y + 10;
            level.spriteBatch.DrawString(font, "100", temp, Color.White);
            level.spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, (isFrozen > 0) ? Color.Aquamarine : Color.White);
            level.spriteBatch.End();
        }

    }
}