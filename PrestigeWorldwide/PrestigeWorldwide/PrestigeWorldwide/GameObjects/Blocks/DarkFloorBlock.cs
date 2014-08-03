using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide
{
    public class DarkFloorBlock : IBlockObstacle
    {
        Texture2D currentTexture;
        Texture2D Block;
        Level level;
        Vector2 location;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        public Boolean garbage = false;
        int idleRows = 1;
        int idleColumns = 1;
        int idleTotalFrames = 1;
        int currentRows;
        int currentColumns;
        int currentTotalFrames;
        int currentFrame;
        bool isIdle;
        int frameDelay;
        int frameDelaySet = 2;

        public DarkFloorBlock(Texture2D DarkFloorBlock, Vector2 location, Level level)
        {
            this.Block = DarkFloorBlock;
            this.location = location;
            this.level = level;
            //Initializes this block to be idle
            isIdle = true;
            currentTexture = DarkFloorBlock;
            currentRows = idleRows;
            currentColumns = idleColumns;
            currentTotalFrames = idleTotalFrames;
            currentFrame = 0;
            frameDelay = frameDelaySet;
        }

        public Rectangle Collider { get { return collider; } }
        public Boolean garbage_collect { get { return garbage; } set { garbage = value; } }
        public void Bump()
        {
            //Nothing happens if used block was bumped
        }

        private void IdleState()
        {
            frameDelay--;
            if (frameDelay == 0)
            {
                currentFrame++;
                if (currentFrame == idleTotalFrames)
                {
                    currentFrame = 0;
                }
                frameDelay = frameDelaySet;
            }
        }

        private void UpdateCollider()
        {
            collider.Height = currentTexture.Height / currentRows;
            collider.Width = currentTexture.Width / currentColumns;
            collider.X = (int)location.X;
            collider.Y = (int)location.Y;
        }

        public void Update()
        {
            this.IdleState();
            UpdateCollider();
        }

        public void Draw()
        {
            int width = currentTexture.Width / currentColumns;
            int height = currentTexture.Height / currentRows;
            int row = (int)((float)currentFrame / (float)currentColumns);
            int column = currentFrame % currentColumns;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X - level.camera.X, (int)location.Y - level.camera.Y, width, height);
            level.spriteBatch.Begin();
            level.spriteBatch.Draw(currentTexture, destinationRectangle, sourceRectangle, Color.White);
            level.spriteBatch.End();
        }


        public void SecretLevel()
        {
        }

        public Vector2 Location
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}