using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    public class Transition
    {
        Level level;
        SpriteBatch spriteBatch;
        public Boolean beginTransition;
        int textureCount = 0;
        int delay;
        Texture2D texture17;
        Texture2D texture16;
        Texture2D texture15;
        Texture2D texture14;
        Texture2D texture13;
        Texture2D texture12;
        Texture2D texture11;
        Texture2D texture10;
        Texture2D texture9;
        Texture2D texture8;
        Texture2D texture7;
        Texture2D texture6;
        Texture2D texture5;
        Texture2D texture4;
        Texture2D texture3;
        Texture2D texture2;
        Texture2D texture1;
        Texture2D texture0;
        Texture2D currentTexture;
        Boolean fadeIn;

        public Transition(Level level)
        {
            this.level = level;
            this.spriteBatch = level.spriteBatch;
            texture17 = level.game.Content.Load<Texture2D>("Transition/newTransition17");
            texture16 = level.game.Content.Load<Texture2D>("Transition/newTransition16");
            texture15 = level.game.Content.Load<Texture2D>("Transition/newTransition15");
            texture14 = level.game.Content.Load<Texture2D>("Transition/newTransition14");
            texture13 = level.game.Content.Load<Texture2D>("Transition/newTransition13");
            texture12 = level.game.Content.Load<Texture2D>("Transition/newTransition12");
            texture11 = level.game.Content.Load<Texture2D>("Transition/newTransition11");
            texture10 = level.game.Content.Load<Texture2D>("Transition/newTransition10");
            texture9 = level.game.Content.Load<Texture2D>("Transition/newTransition9");
            texture8 = level.game.Content.Load<Texture2D>("Transition/newTransition8");
            texture7 = level.game.Content.Load<Texture2D>("Transition/newTransition7");
            texture6 = level.game.Content.Load<Texture2D>("Transition/newTransition6");
            texture5 = level.game.Content.Load<Texture2D>("Transition/newTransition5");
            texture4 = level.game.Content.Load<Texture2D>("Transition/newTransition4");
            texture3 = level.game.Content.Load<Texture2D>("Transition/newTransition3");
            texture2 = level.game.Content.Load<Texture2D>("Transition/newTransition2");
            texture1 = level.game.Content.Load<Texture2D>("Transition/newTransition1");
            texture0 = level.game.Content.Load<Texture2D>("Transition/newTransition0");
            currentTexture = texture0;

        }
        public void Reset()
        {
            beginTransition = false;
            textureCount = 17;
        }

        public void CutToBlack()
        {
            beginTransition = false;
            textureCount = 0;
            currentTexture = texture0;
        }
        public void FadeIn()
        {
            fadeIn = true;
            textureCount = 0;
            beginTransition = true;
        }

        public void FadeOut()
        {
            fadeIn = false;
            textureCount = 17;
            beginTransition = true;
        }

        public void Update()
        {
            

           switch (textureCount)
            {
                case 17:
                    currentTexture = texture17;
                    break;

                case 16:
                    currentTexture = texture16;
                    break;

                case 15:
                    currentTexture = texture15;
                    break;

                case 14:
                    currentTexture = texture14;
                    break;

                case 13:
                    currentTexture = texture13;
                    break;

                case 12:
                    currentTexture = texture12;
                    break;

                case 11:
                    currentTexture = texture11;
                    break;

                case 10:
                    currentTexture = texture10;
                    break;

                case 9:
                    currentTexture = texture9;
                    break;

                case 8:
                    currentTexture = texture8;
                    break;

                case 7:
                    currentTexture = texture7;
                    break;

                case 6:
                    currentTexture = texture6;
                    break;

                case 5:
                    currentTexture = texture5;
                    break;

                case 4:
                    currentTexture = texture4;
                    break;

                case 3:
                    currentTexture = texture3;
                    break;

                case 2:
                    currentTexture = texture2;
                    break;

                case 1:
                    currentTexture = texture1;
                    break;
            
                case 0:
                    currentTexture = texture0;
                    break;

           }
                   if (beginTransition)
            {
                delay++;
                if (delay % 3 == 0)
                {
                    if (!fadeIn)
                        textureCount--;
                    else
                        textureCount++;
                }

                if (textureCount <= 0) { textureCount = 0; }
                if (textureCount >= 17) { textureCount = 17; }
            }
        }

        public void Draw()
        {
            int width = currentTexture.Width;
            int height = currentTexture.Height;
            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle(0, 0, level.camera.width, level.camera.height);
            level.spriteBatch.Begin();
            level.spriteBatch.Draw(currentTexture, destinationRectangle, sourceRectangle, Color.White);
            level.spriteBatch.End();
        }
    }
}
