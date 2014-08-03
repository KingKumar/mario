using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide.GameObjects.Items
{
    public class FireFlower : IConsumableItem
    {
        Texture2D currentTexture;
        Texture2D IdleFireFlower;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        Level level;
        Vector2 location;
        public Boolean garbage = false;
        int emerging;
        int frameDelay;

        public FireFlower(Texture2D IdleFireFlower, Vector2 location, Level level)
        {
            this.IdleFireFlower = IdleFireFlower;
            this.location = location;
            this.level = level;
            emerging = IdleFireFlower.Height;
            currentTexture = IdleFireFlower;
            frameDelay = ItemConstants.fireFlowerFrameDelay;
        }

        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
        public Rectangle Collider { get { return collider; } }
        public Boolean garbage_collect { get { return garbage; } }

        public void Bump(int x, int y)
        {
            this.location.X += x;
            this.location.Y += y;
        }

        public int Consume()
        {
            garbage = true;
            level.gameStatus.score += MarioConstants.flowerScore;
            level.game.sounds.PowerUp();
            return 4;
        }

        private void UpdateCollider()
        {
            collider.Height = currentTexture.Height;
            collider.Width = currentTexture.Width;
            collider.X = (int)location.X;
            collider.Y = (int)location.Y;
        }

        public void Update()
        {
            if (emerging > 0)
            {
                emerging--;
            }
            else
            {
                frameDelay--;
                if (frameDelay == 0)
                {
                    frameDelay = ItemConstants.fireFlowerFrameDelay;
            }
            }
            UpdateCollider();
        }

        public void Draw()
        {
            int width = currentTexture.Width;
            int height = currentTexture.Height - emerging;
            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X-level.camera.X, (int)location.Y-level.camera.Y + emerging, width, height);
            level.spriteBatch.Begin();
            level.spriteBatch.Draw(currentTexture, destinationRectangle, sourceRectangle, Color.White);
            level.spriteBatch.End();
        }
    }
}