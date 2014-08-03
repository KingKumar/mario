using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    public class Flagpole : IBlockObstacle
    {

        Texture2D IdleFlagpole;
        Texture2D currentTexture;
        Vector2 location;
        Level level;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        public Boolean garbage = false;
        int idleRows = 1;
        int idleColumns = 1;
        int idleTotalFrames = 1;
        int currentRows;
        int currentColumns;
        int currentTotalFrames;
        int currentFrame;
        bool hasBeenBumped;

        public Flagpole(Texture2D texture, Vector2 location, Level level)
        {
            this.level = level;
            this.IdleFlagpole = texture;
            this.location = location;
            currentTexture = IdleFlagpole;
            currentRows = idleRows;
            currentColumns = idleColumns;
            currentTotalFrames = idleTotalFrames;
            currentFrame = 0;
        }

        public Rectangle Collider { get { return collider; } }
        public Boolean garbage_collect { get { return garbage; } set { garbage = value; } }
        public void Bump()
        {
            if (hasBeenBumped == false)
            {
                hasBeenBumped = true;
                level.PlayVictoryAnimation(location);
            }
        }

        private void IdleState()
        {
            currentFrame++;
            if (currentFrame == idleTotalFrames)
            {
                currentFrame = 0;
            }
        }

        private void UpdateCollider()
        {
            if (hasBeenBumped == false)
            {
                collider.Height = currentTexture.Height / currentRows;
                collider.Width = currentTexture.Width / currentColumns;
                collider.X = (int)location.X;
                collider.Y = (int)location.Y;
            }
            else
            {
                collider.Width = 0;
                collider.Height = 0;
                collider.X = 0;
                collider.Y = 0;
            }

        }

        public void Update()
        {
            IdleState();
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
