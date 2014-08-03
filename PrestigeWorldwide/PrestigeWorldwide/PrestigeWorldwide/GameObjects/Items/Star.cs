using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class Star : IConsumableItem
    {
        Texture2D currentTexture;
        Texture2D IdleStar;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        Level level;
        Vector2 location;
        public Boolean garbage = false;
        bool isIdle;
        bool isRight;
        bool isUp;
        int upCounter = ItemConstants.starUpCounter;
        int frameDelay;

        public Star(Texture2D IdleStar, Vector2 location, Level level)
        {
            this.IdleStar = IdleStar;
            this.location = location;
            this.level = level;
            isIdle = true;
            isRight = true;
            isUp = false;
            currentTexture = IdleStar;
            frameDelay = ItemConstants.starFrameDelay;
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
            if (y < 0)
            {
                upCounter = ItemConstants.starUpCounter;
                isUp = true;
            }
            if (y > 0)
            {
                isUp = false;
            }
            this.location.X += x;
            this.location.Y += y;
            if (x < -1)
            {
                isRight = false;
            }
            if (x > 1)
            {
                isRight = true;
            }
        }

        public int Consume()
        {
            level.gameStatus.score += MarioConstants.starScore;
            garbage = true;
            return ItemConstants.starConsumeIdentity;
        }

        private void IdleState()
        {
            frameDelay--;
            if (frameDelay == 0)
            {
                if (isRight)
                {
                    location.X += ItemConstants.starSpeed;
                }
                else
                {
                    location.X -= ItemConstants.starSpeed;
                }
                if (isUp)
                {
                    upCounter--;
                    location.Y -= ItemConstants.starSpeed;
                }
                else
                {
                    location.Y += ItemConstants.starSpeed;
                }
                frameDelay = ItemConstants.starFrameDelay;
            }
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
            if (isIdle)
            {
                this.IdleState();
            }
            if (upCounter == 0)
            {
                isUp = false;
            }
            UpdateCollider();
        }

        public void Draw()
        {
            int width = currentTexture.Width;
            int height = currentTexture.Height;
            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X-level.camera.X, (int)location.Y-level.camera.Y, width, height);
            level.spriteBatch.Begin();
            level.spriteBatch.Draw(currentTexture, destinationRectangle, sourceRectangle, Color.White);
            level.spriteBatch.End();
        }
    }
}