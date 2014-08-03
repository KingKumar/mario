using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide.GameObjects.Items
{
    class IceFlower:IConsumableItem
    {
        Texture2D currentTexture;
        Texture2D IdleIceFlower;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        Level level;
        Vector2 location;
        public Boolean garbage = false;
        int emerging;
        int frameDelay;

        public IceFlower(Texture2D IdleIceFlower, Vector2 location, Level level)
        {
            this.IdleIceFlower = IdleIceFlower;
            this.location = location;
            this.level = level;
            emerging = IdleIceFlower.Height;
            currentTexture = IdleIceFlower;
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
            level.game.sounds.PowerUp();
            level.gameStatus.score += MarioConstants.flowerScore;
            return 6;
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
