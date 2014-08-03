using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide
{
    public class DarkBrickBlock : IBlockObstacle
    {
        //This class still needs to implement broken brick block logic
        Texture2D currentTexture;
        Texture2D DarkIdleBrickBlock;
        Texture2D DarkBumpedBrickBlock;
        Vector2 location;
        Level level;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        public Boolean garbage = false;
        int idleRows = 1;
        int idleColumns = 4;
        int idleTotalFrames = 4;
        int bumpedRows = 1;
        int bumpedColumns = 7;
        int bumpedTotalFrames = 7;
        int currentRows;
        int currentColumns;
        int currentTotalFrames;
        int currentFrame;
        bool isIdle;
        int frameDelay;
        int frameDelaySet = 6;

        public DarkBrickBlock(Texture2D IdleBrickBlock, Texture2D BumpedBrickBlock, Vector2 location, Level level)
        {
            this.DarkIdleBrickBlock = IdleBrickBlock;
            this.DarkBumpedBrickBlock = BumpedBrickBlock;
            this.location = location;
            this.level = level;
            //Initializes this block to be idle
            isIdle = true;
            currentTexture = IdleBrickBlock;
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
            if (isIdle == true)
            {
                isIdle = false;
                currentFrame = 0;
                frameDelay = frameDelaySet;
            }
        }

        private void BumpedState()
        {
            frameDelay--;
            if (currentFrame < 2)
            {
                if (frameDelay == 3 || frameDelay == 0)
                {
                    location.Y -= 4;
                }
            }
            else if (currentFrame < 4)
            {
                if (frameDelay == 3 || frameDelay == 0)
                {
                    location.Y += 4;
                }
            }
            if (frameDelay == 0)
            {
                currentFrame++;
                if (currentFrame == idleTotalFrames)
                {
                    //Sets the block back to idle after being bumped
                    isIdle = true;
                    currentTexture = DarkIdleBrickBlock;
                    currentRows = idleRows;
                    currentColumns = idleColumns;
                    currentTotalFrames = idleTotalFrames;
                    currentFrame = 0;
                    frameDelay = frameDelaySet;
                }
                frameDelay = frameDelaySet;
            }
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
            if (isIdle)
            {
                this.IdleState();
            }
            else
            {
                this.BumpedState();
            }
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
                return location;
            }
            set
            {
                location = value;
            }
        }
    }
}