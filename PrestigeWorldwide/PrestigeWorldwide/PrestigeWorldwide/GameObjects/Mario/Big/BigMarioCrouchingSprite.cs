using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide.Sprites.Mario
{
    class BigMarioCrouchingSprite : IAnimatedSprite
    {
        int isMovingRight;
        Level level;
        Texture2D texture;
        Vector2 location;

        public Texture2D Texture { get { return texture; } }

        public BigMarioCrouchingSprite(int isMovingRight, Level level, Vector2 location)
        {
            this.isMovingRight = isMovingRight;
            this.level = level;
            this.texture = level.ContentLoad("Mario/Big/BigCrouchingMario");
            this.location = location;
        }

        public void Update()
        {
            // Ensure that the correct direction is being rendered
            isMovingRight = level.mario.isMovingRight;
            location = level.mario.location;
        }

        public void Draw()
        {
            int width = texture.Width;
            int height = texture.Height / 2;

            Rectangle sourceRectangle = new Rectangle(0, height * isMovingRight, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X-level.camera.X, (int)location.Y-level.camera.Y, width, height);

            level.spriteBatch.Begin();
            level.spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White * ((level.mario.starPower + 2) % 10 ));
            level.spriteBatch.End();
        }
    }
}
