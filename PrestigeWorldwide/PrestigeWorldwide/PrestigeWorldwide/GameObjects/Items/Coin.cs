using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class Coin : IConsumableItem
    {
        Texture2D currentTexture;
        Texture2D IdleCoin;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        Level level;
        Vector2 location;
        public Boolean garbage = false;
        int currentRows;
        int currentColumns;
        int currentTotalFrames;
        int currentFrame;
        int totalFrames;
        bool isFromBlock;
        int frameDelay;

        public Coin(Texture2D IdleCoin, Vector2 location, Level level, bool isFromBlock)
        {
            this.IdleCoin = IdleCoin;
            this.location = location;
            this.level = level;
            this.isFromBlock = isFromBlock;
            currentTexture = IdleCoin;
            currentRows = ItemConstants.coinRows;
            currentColumns = ItemConstants.coinColumns;
            currentTotalFrames = ItemConstants.coinRows * ItemConstants.coinColumns;
            totalFrames = ItemConstants.coinRows * ItemConstants.coinColumns;
            currentFrame = 0;
            frameDelay = ItemConstants.coinFrameDelay;
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
            level.gameStatus.score += MarioConstants.coinScore;
            level.gameStatus.coinCount++;
            level.game.sounds.CollectCoin();
            return ItemConstants.coinConsumeIdentity;
        }

        private void IdleState()
        {
            frameDelay--;
            if (frameDelay == 0)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
                frameDelay = ItemConstants.coinFrameDelay;
            }
        }

        private void CoinFromQuestionBlock()
        {
            frameDelay--;
            if (frameDelay == 0)
            {
                currentFrame++;
                location.Y -= ItemConstants.coinSpeedFromBlock;
                if (currentFrame == totalFrames)
                {
                    level.gameStatus.coinCount++;
                    level.gameStatus.score += MarioConstants.coinScore;
                    level.game.sounds.CollectCoin();
                    garbage = true;
                }
                frameDelay = ItemConstants.coinFrameDelay;
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
            if (isFromBlock)
            {
                this.CoinFromQuestionBlock();
            }
            else
            {
                this.IdleState();
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
            Rectangle destinationRectangle = new Rectangle((int)location.X-level.camera.X, (int)location.Y-level.camera.Y, width, height);
            level.spriteBatch.Begin();
            level.spriteBatch.Draw(currentTexture, destinationRectangle, sourceRectangle, Color.White);
            level.spriteBatch.End();
        }
    }
}