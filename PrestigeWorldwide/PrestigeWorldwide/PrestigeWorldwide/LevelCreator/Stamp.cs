using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class Stamp
    {
        public Texture2D texture;
        public int X;
        public int Y;
        LevelCreator level;
        SpriteBatch spriteBatch;
        public Boolean isTemplate;
        public Rectangle hitBox;
        public Rectangle stretchHitBox;
        public Boolean isRemoved = false;
        public Boolean isSelected;
        public string tag;
        int horizontalStretch;
        int verticalStretch;
        int verticalStretchDelay;
        int horizontalStretchDelay;
        public Boolean isBackground;

        public Stamp(string tag,Texture2D texture,Rectangle hitBox,LevelCreator level, Boolean isBackground = false)
        {
            this.texture = texture;
            this.X = hitBox.X;
            this.Y = hitBox.Y;
            this.level = level;
            this.spriteBatch = level.spriteBatch;
            this.hitBox = hitBox;
            isTemplate = true;
            this.tag = tag;
            stretchHitBox = hitBox;
            this.isBackground = isBackground;
        }

        public void StretchHorizontal()
        {
            if (horizontalStretchDelay++ % 2 == 0)
            {
                horizontalStretch++;
            }
        }

        public void StretchVertical()
        {
            if (verticalStretchDelay++ % 2 == 0)
            {
                verticalStretch++;
            }
        }

        public void ShrinkHorizontal()
        {
            if (horizontalStretchDelay++ % 2 == 0)
            {
                horizontalStretch--;
            }
        }
        public void ShrinkVertical()
        {
            if (verticalStretchDelay++ % 2 == 0)
            {
                verticalStretch--;
            }
        }

        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            Rectangle destinationRectangle;
            spriteBatch.Begin();
            if (isTemplate)
            {
                destinationRectangle = new Rectangle(X, Y , hitBox.Width, hitBox.Height);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            }
            else
            {
                for (int i = 0; i <= horizontalStretch; i++)
                {
                    for (int j = 0; j <= verticalStretch; j++)
                    {
                        destinationRectangle = new Rectangle(X - level.camera.xPos + i * hitBox.Width, Y - level.camera.yPos + j * hitBox.Height, hitBox.Width, hitBox.Height);
                        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

                    }
                    for (int j = 0; j >= verticalStretch; j--)
                    {
                        destinationRectangle = new Rectangle(X - level.camera.xPos + i * hitBox.Width, Y - level.camera.yPos + j * hitBox.Height, hitBox.Width, hitBox.Height);
                        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

                    }
                }

                for (int i = 0; i >= horizontalStretch; i--)
                {
                    for (int j = 0; j <= verticalStretch; j++)
                    {
                        destinationRectangle = new Rectangle(X - level.camera.xPos + i * hitBox.Width, Y - level.camera.yPos + j * hitBox.Height, hitBox.Width, hitBox.Height);
                        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

                    }
                    for (int j = 0; j >= verticalStretch; j--)
                    {
                        destinationRectangle = new Rectangle(X - level.camera.xPos + i * hitBox.Width, Y - level.camera.yPos + j * hitBox.Height, hitBox.Width, hitBox.Height);
                        spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

                    }
                }

            }


            spriteBatch.End();
        }

        public void TemplateDraw()
        {
            if (isTemplate)
            {
                Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
                Rectangle destinationRectangle;
                if (!isTemplate)
                    destinationRectangle = new Rectangle(X - level.camera.xPos, Y - level.camera.yPos, hitBox.Width, hitBox.Height);
                else
                    destinationRectangle = new Rectangle(X, Y, hitBox.Width, hitBox.Height);


                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }

        }



        public void Drag()
        {
            if (isTemplate)
            {
                isTemplate = false;
                level.textureStamps.Add(new Stamp(tag,texture,hitBox,level));
            }
            X = level.cursor.placeLocationX;
            Y = level.cursor.placeLocationY;
            hitBox.X = X - level.camera.xPos;
            hitBox.Y = Y-level.camera.yPos;
            isSelected = true;
        }

        public void Create(int i = 0, int j = 0)
        {
            Rectangle newHitBox = hitBox;
            newHitBox.X = hitBox.X + level.camera.xPos + i*hitBox.Width;
            newHitBox.Y = hitBox.Y + level.camera.yPos + j*hitBox.Height;
            Stamp newStamp = new Stamp(tag,texture,newHitBox,level,isBackground);
            newStamp.isTemplate = false;
            level.textureStamps.Add(newStamp);
        }

        public void Remove(Boolean removeSelected = true)
        {
            if (!isTemplate && !(isSelected && !removeSelected))
            {
                if (!isBackground)
                {
                    isRemoved = true;
                }
                else if (removeSelected) { isRemoved = true; }
            }
        }

        public void Update()
        {
            if (!isTemplate)
            {
                hitBox.X = X - level.camera.xPos;
                hitBox.Y = Y - level.camera.yPos;
                stretchHitBox = hitBox;
                stretchHitBox.Width = hitBox.Width + horizontalStretch * hitBox.Width;
                stretchHitBox.Height = hitBox.Width + verticalStretch * hitBox.Height;
            }
        }

        public void Drop(Boolean resetStretch = true)
        {
            
            for (int i = 0; i <= horizontalStretch; i++)
            {
                for (int j = 0; j <= verticalStretch; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        this.Create(i, j);
                    }
                }
                for (int j = 0; j >= verticalStretch; j--)
                {
                    if (i != 0 || j != 0)
                    {
                        this.Create(i, j);
                    }
                }
            }
            for (int i = 0; i >= horizontalStretch; i--)
            {
                for (int j = 0; j <= verticalStretch; j++)
                {
                    if (i != 0 || j != 0)
                    {
                        this.Create(i, j);
                    }
                }
                for (int j = 0; j >= verticalStretch; j--)
                {
                    if (i != 0 || j != 0)
                    {
                        this.Create(i, j);
                    }
                }
            }
            if (resetStretch)
            {
                horizontalStretch = 0;
                verticalStretch = 0;
                isSelected = false;
            }
            else
            {
                this.Create(0, 0);
            }
        }
    }
}
