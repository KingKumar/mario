using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class Cursor
    {

        LevelCreator level;
        public Vector2 location;
        SpriteBatch spriteBatch;
        public Texture2D texture;
        public Boolean isInMouseState = true;
        MouseState mouseState;
        public int placeLocationX;
        public int placeLocationY;
        Boolean leftClickUp;
        public Boolean isBrushing;

        public Cursor(LevelCreator level)
        {
            this.level = level;
            this.spriteBatch = level.spriteBatch;
            texture = level.game.Content.Load<Texture2D>("LevelCreatorSprites/Cursor");
            location.X = 100;
            location.Y = 100;
        }

        public void Select(Point mousePos)
        {
            if (!level.objectDragger.hasObjectSelected)
                level.objectDragger.FindObjectAt(mousePos);
        }

        public void Update()
        {
           
            if (isInMouseState)
            {
                Point mousePos;
                mouseState = Mouse.GetState();
                mousePos = new Point(mouseState.X, mouseState.Y);
                location.X = mouseState.X - texture.Width/2;
                location.Y = mouseState.Y - texture.Height/2;
                placeLocationX = (level.replacementAccuracyX - (mouseState.X + level.camera.xPos) % level.replacementAccuracyX) + (mouseState.X + level.camera.xPos);
                placeLocationY = (level.replacementAccuracyY - (mouseState.Y + level.camera.yPos) % level.replacementAccuracyY) + (mouseState.Y + level.camera.yPos);
                if (mouseState.LeftButton == ButtonState.Released) { leftClickUp = true; }

                if (mouseState.LeftButton == ButtonState.Pressed && leftClickUp)
                {
                    if (level.objectDragger.hasObjectSelected)
                    {
                        level.objectDragger.Brush(true);
                    }
                    else
                    {
                        this.Select(mousePos);
                    }
                    leftClickUp = false;

                }
               
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    level.objectDragger.Remove(mousePos);
                }

                

                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.LeftControl))
                {
                    level.objectDragger.Brush(false);
                    isBrushing = true;
                }
                else { isBrushing = false; }

                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    level.objectDragger.StretchHorizontal();
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    level.objectDragger.StretchVertical();
                }
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    level.objectDragger.ShrinkVertical();
                }
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    level.objectDragger.ShrinkHorizontal();
                }
                if (level.objectDragger.hasObjectSelected)
                {
                    level.objectDragger.Drag(mousePos);
                }

            }
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(0 ,0, texture.Width, texture.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, texture.Width/2, texture.Height/2);

            spriteBatch.Begin();
            spriteBatch.Draw(texture,destinationRectangle,sourceRectangle, Color.White);
           
                spriteBatch.End();
        }
    }
}
