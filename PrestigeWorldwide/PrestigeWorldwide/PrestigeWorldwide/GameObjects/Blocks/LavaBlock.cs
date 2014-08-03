using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide
{
    class LavaBlock : IBlockObstacle
    {
        Texture2D currentTexture;
        Texture2D IdleLavaBlock;
        Level level;
        Vector2 location;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        public Boolean garbage = false;

        public LavaBlock(Texture2D LavaBlock, Vector2 location, Level level)
        {
            this.IdleLavaBlock = LavaBlock;
            this.location = location;
            this.level = level;
            currentTexture = LavaBlock;
        }

        public Rectangle Collider { get { return collider; } }

        public Boolean garbage_collect { get { return garbage; } set { garbage = value; } }

        public void Bump()
        {
            //Nothing happens if lava block is bumped
        }


        public Vector2 Location
        {
            get { return location; }
            set{ location = value; }
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
            //Lava blocks do not move relative to themselves
            UpdateCollider();
        }

        public void Draw()
        {
            int width = currentTexture.Width;
            int height = currentTexture.Height;
            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X - level.camera.X, (int)location.Y - level.camera.Y, width, height);
            level.spriteBatch.Begin();
            level.spriteBatch.Draw(currentTexture, destinationRectangle, sourceRectangle, Color.White);
            level.spriteBatch.End();
        }

        public void SecretLevel()
        {
        }


    }
}
