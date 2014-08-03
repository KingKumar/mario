using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class RedMushroom : IConsumableItem
    {
        Texture2D currentTexture;
        Texture2D IdleRedMushroom;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        Level level;
        Vector2 location;
        public Boolean garbage = false;
        int emerging; // Emerging from the question block
        bool isRight;
        int fallCounter;
        int frameDelay;

        public RedMushroom(Texture2D IdleRedMushroom, Vector2 location, Level level)
        {
            this.IdleRedMushroom = IdleRedMushroom;
            this.location = location;
            this.level = level;
            emerging = IdleRedMushroom.Height;
            isRight = true;
            currentTexture = IdleRedMushroom;
            fallCounter = ItemConstants.redMushFallCounter;
            frameDelay = ItemConstants.redMushFrameDelay;
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
            if (y != 0)
            {
                fallCounter = ItemConstants.redMushFallCounter;
            }
            this.location.X += x;
            this.location.Y += y;
            if (x < 0)
            {
                isRight = false;
            }
            if (x > 0)
            {
                isRight = true;
            }
        }

        public int Consume()
        {
            level.gameStatus.score += MarioConstants.mushroomScore;
            garbage = true;
            level.game.sounds.PowerUp();
            return ItemConstants.redMushConsumeIdentity;
        }

        private void MovingState()
        {
            frameDelay--;
            fallCounter--;
            location.Y += 1;
            if (frameDelay == 0)
            {
                    if (isRight)
                    {
                    location.X += ItemConstants.redMushSpeed;
                    }
                    else
                    {
                    location.X -= ItemConstants.redMushSpeed;
                    }
                frameDelay = ItemConstants.redMushFrameDelay;
                }
            if (fallCounter == 0)
                {
                location.Y += ItemConstants.redMushSpeed;
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
            if (emerging > 0)
            {
                emerging--;
            }
            else
            {
                this.MovingState();
            }
            UpdateCollider();
        }

        public void Draw()
        {
            int width = currentTexture.Width;
            int height = currentTexture.Height - emerging;
            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X - level.camera.X, (int)location.Y - level.camera.Y + emerging, width, height);
            level.spriteBatch.Begin();
            level.spriteBatch.Draw(currentTexture, destinationRectangle, sourceRectangle, Color.White);
            level.spriteBatch.End();
        }
    }
}