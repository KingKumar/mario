using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class BrickBlocklet : IBlockObstacle
    {
        Texture2D currentTexture;
        Texture2D IdleBrickBlocklet;
        Vector2 location;
        Level level;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        public Boolean garbage = false;
        int blockletNum;
        int lifeSpan;

        public BrickBlocklet(Texture2D IdleBrickBlocklet, Vector2 location, Level level, int num)
        {
            this.IdleBrickBlocklet = IdleBrickBlocklet;
            this.location = location;
            this.level = level;
            this.blockletNum = num;
            lifeSpan = ObstacleConstants.blockletLifeSpan;
            currentTexture = IdleBrickBlocklet;
        }

        public Rectangle Collider { get { return collider; } }
        public Boolean garbage_collect { get { return garbage; } set { garbage = value; } }

        public void Bump()
        {
            //Nothing happens is brick blocklet is bumped
        }

        private void NumZeroState()
        {
            location.Y -= ObstacleConstants.blockletSlowSpeed;
            location.X -= ObstacleConstants.blockletFastSpeed;
        }

        private void NumOneState()
        {
            location.Y -= ObstacleConstants.blockletFastSpeed;
            location.X -= ObstacleConstants.blockletSlowSpeed;
        }

        private void NumTwoState()
        {
            location.Y -= ObstacleConstants.blockletFastSpeed;
            location.X += ObstacleConstants.blockletSlowSpeed;
        }

        private void NumThreeState()
        {
            location.Y -= ObstacleConstants.blockletSlowSpeed;
            location.X += ObstacleConstants.blockletFastSpeed;
        }

        private void UpdateCount()
        {
            lifeSpan--;
            if (lifeSpan == 0)
            {
                garbage = true;
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
            switch (blockletNum)
            {
                case 0:
                    this.NumZeroState();
                    break;
                case 1:
                    this.NumOneState();
                    break;
                case 2:
                    this.NumTwoState();
                    break;
                case 3:
                    this.NumThreeState();
                    break;
            }
            UpdateCount(); 
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