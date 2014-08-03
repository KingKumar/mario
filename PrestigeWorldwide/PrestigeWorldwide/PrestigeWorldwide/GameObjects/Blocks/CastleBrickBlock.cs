using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    class CastleBrickBlock : IBlockObstacle
    {
        Texture2D currentTexture;
        Texture2D IdleCastleBrickBlock;
        Vector2 location;
        Level level;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        public Boolean garbage = false;
        int currentRows;
        int currentColumns;
        int currentTotalFrames;
        int currentFrame;
        bool isIdle;
        string blockContent;
        int numCoins;
        int frameDelay;
        Random random = new Random();

        public CastleBrickBlock(Texture2D IdleCastleBrickBlock, Vector2 location, Level level, string blockContent)
        {
            this.IdleCastleBrickBlock = IdleCastleBrickBlock;
            this.location = location;
            this.level = level;
            this.blockContent = blockContent;
            isIdle = true;
            currentTexture = IdleCastleBrickBlock;
            currentRows = ObstacleConstants.castlebrickIdleRows;
            currentColumns = ObstacleConstants.castlebrickIdleColumns;
            currentTotalFrames = ObstacleConstants.castlebrickIdleRows * ObstacleConstants.castlebrickIdleColumns;
            currentFrame = 0;
            frameDelay = ObstacleConstants.castlebrickFrameDelay;
            if (blockContent == "coin")
            {
                numCoins = random.Next(ObstacleConstants.castlebrickMinCoins, ObstacleConstants.castlebrickMaxCoins);
            }
        }

        public Rectangle Collider { get { return collider; } }

        public Boolean garbage_collect { get { return garbage; } set { garbage = value; } }

        public void Bump()
        {
            if (isIdle == true)
            {
                if (blockContent == "none" && (level.mario.marioState is BigMarioState || level.mario.marioState is FireMarioState || level.mario.marioState is IceMarioState) )
                {
                    level.blockFactory.CreateCastleBlocklets((int)location.X + ObstacleConstants.castlebrickBlockMidpoint, (int)location.Y + ObstacleConstants.castlebrickBlockMidpoint);
                    garbage = true;
                }
                else
                {
                    isIdle = false;
                    currentFrame = 0;
                    frameDelay = ObstacleConstants.castlebrickFrameDelay;
                    GenerateItem();
                }
            }
        }

        private void GenerateItem()
        {
            switch (blockContent)
            {
                case "redMushroom":
                    level.consItemFactory.CreateRedMushroom((int)location.X, (int)location.Y);
                    blockContent = "none";
                    break;

                case "fireFlower":
                    level.consItemFactory.CreateFireFlower((int)location.X, (int)location.Y);
                    blockContent = "none";
                    break;

                case "coin":
                    level.consItemFactory.CreateCoin((int)location.X, (int)location.Y, true);
                    numCoins--;
                    if (numCoins == 0)
                    {
                        blockContent = "none";
                    }
                    break;

                case "greenMushroom":
                    level.consItemFactory.CreateGreenMushroom((int)location.X, (int)location.Y);
                    blockContent = "none";
                    break;

                case "star":
                    level.consItemFactory.CreateStar((int)location.X, (int)location.Y);
                    blockContent = "none";
                    break;
            }
        }

        private void BumpedState()
        {
            frameDelay--;
            if (currentFrame < currentTotalFrames / 2)
            {
                location.Y -= ObstacleConstants.castlebrickBumpedSpeed;
            }
            else
            {
                location.Y += ObstacleConstants.castlebrickBumpedSpeed;
            }
            if (frameDelay == 0)
            {
                currentFrame++;
                if (currentFrame == currentTotalFrames)
                {
                    isIdle = true;
                    currentFrame = 0;
                }
                frameDelay = ObstacleConstants.castlebrickFrameDelay;
            }
        }

        private void IdleState()
        {
            frameDelay--;
            if (frameDelay == 0)
            {
                currentFrame++;
                if (currentFrame == currentTotalFrames)
                {
                    currentFrame = 0;
                }
                frameDelay = ObstacleConstants.castlebrickFrameDelay;
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
            Rectangle destinationRectangle = new Rectangle((int)location.X- level.camera.X, (int)location.Y- level.camera.Y, width, height);
            level.spriteBatch.Begin();
            level.spriteBatch.Draw(currentTexture, destinationRectangle, sourceRectangle, Color.White);
            level.spriteBatch.End();
        }

        public void SecretLevel()
        {
        }

        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}
