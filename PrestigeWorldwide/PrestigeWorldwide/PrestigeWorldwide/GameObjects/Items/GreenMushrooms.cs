using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class GreenMushroom : IConsumableItem
    {
        Texture2D currentTexture;
        Texture2D IdleGreenMushroom;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        Level level;
        Vector2 location;
        public Boolean garbage = false;
        int emerging; //Emerging from block
        bool isRight;
        int fallCounter;
        int frameDelay;

        public GreenMushroom(Texture2D IdleGreenMushroom, Vector2 location, Level level)
        {
            this.IdleGreenMushroom = IdleGreenMushroom;
            this.location = location;
            this.level = level;
            emerging = IdleGreenMushroom.Height;
            isRight = true;
            currentTexture = IdleGreenMushroom;
            fallCounter = ItemConstants.greenMushFallCounter;
            frameDelay = ItemConstants.greenMushFrameDelay;
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
                fallCounter = ItemConstants.greenMushFallCounter;
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
            level.gameStatus.lifeCount++;
            level.gameStatus.score += MarioConstants.mushroomScore;
            garbage = true;
            level.game.sounds.OneUp();
            return 2;
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
                    location.X += ItemConstants.greenMushSpeed;
                }
                else
                {
                    location.X -= ItemConstants.greenMushSpeed;
                }
                frameDelay = ItemConstants.greenMushFrameDelay;
            }
            if (fallCounter == 0)
            {
                location.Y += ItemConstants.greenMushSpeed;
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