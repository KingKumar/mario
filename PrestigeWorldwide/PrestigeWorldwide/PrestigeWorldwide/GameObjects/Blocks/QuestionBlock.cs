using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class QuestionBlock : IBlockObstacle
    {
        Texture2D currentTexture;
        Texture2D IdleQuestionBlock;
        Texture2D BumpedQuestionBlock;
        Level level;
        Vector2 location;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        public Boolean garbage = false;
        string blockContent;
        int currentRows;
        int currentColumns;
        int currentTotalFrames;
        int currentFrame;
        bool isIdle;
        bool isBumped;
        int frameDelay;

        public QuestionBlock(Texture2D IdleQuestionBlock, Texture2D BumpedQuestionBlock, Vector2 location, Level level, string blockContent)
        {
            this.IdleQuestionBlock = IdleQuestionBlock;
            this.BumpedQuestionBlock = BumpedQuestionBlock;
            this.location = location;
            this.level = level;
            this.blockContent = blockContent;
            isIdle = true;
            isBumped = false;
            currentTexture = IdleQuestionBlock;
            currentRows = ObstacleConstants.questionIdleRows;
            currentColumns = ObstacleConstants.questionIdleColumns;
            currentTotalFrames = ObstacleConstants.questionIdleRows * ObstacleConstants.questionIdleColumns;
            currentFrame = 0;
            frameDelay = ObstacleConstants.questionFrameDelay;
        }

        public Rectangle Collider { get { return collider; } }
        public Boolean garbage_collect { get { return garbage; } set { garbage = value; } }

        public void Bump()
        {
            if (isIdle == true)
            {
                isIdle = false;
                currentFrame = 0;
                frameDelay = ObstacleConstants.questionFrameDelay;
                GenerateItem();
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
                frameDelay = ObstacleConstants.questionFrameDelay;
            }
        }

        private void BumpedState()
        {
            frameDelay--;
            if (currentFrame < currentTotalFrames / 2)
            {
                location.Y -= ObstacleConstants.questionBumpedSpeed;
                }
            else
            {
                location.Y += ObstacleConstants.questionBumpedSpeed;
            }
            if (frameDelay == 0)
            {
                currentFrame++;
                if (currentFrame == currentTotalFrames)
                {
                    isBumped = true;
                    currentTexture = BumpedQuestionBlock;
                    currentRows = ObstacleConstants.questionBumpedRows;
                    currentColumns = ObstacleConstants.questionBumpedColumns;
                    currentTotalFrames = ObstacleConstants.questionBumpedRows * ObstacleConstants.questionBumpedColumns;
                    currentFrame = 0;
                }
                frameDelay = ObstacleConstants.questionFrameDelay;
            }
        }

        private void GenerateItem()
        {
                    switch (blockContent)
                    {
                        case "redMushroom":
                            level.consItemFactory.CreateRedMushroom((int)location.X, (int)location.Y);
                            level.game.sounds.PowerUpSpawn();
                            break;

                        case "fireFlower":
                            level.consItemFactory.CreateFireFlower((int)location.X, (int)location.Y);
                            level.game.sounds.PowerUpSpawn();
                            break;

                        case "iceFlower":
                            level.consItemFactory.CreateIceFlower((int)location.X, (int)location.Y);
                            level.game.sounds.PowerUpSpawn();
                            break;

                        case "coin":
                            level.consItemFactory.CreateCoin((int)location.X, (int)location.Y, true);
                            break;

                        case "greenMushroom":
                            level.consItemFactory.CreateGreenMushroom((int)location.X, (int)location.Y);
                            break;

                        case "star":
                            level.consItemFactory.CreateStar((int)location.X, (int)location.Y);
                            level.game.sounds.PowerUpSpawn();
                            break;
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
            else if (!isBumped)
            {
                this.BumpedState();
            }
            //Question block does not move after it is bumped
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