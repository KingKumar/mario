using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide
{
    public class PauseMenu
    {
        private Game1 game;
        private Level level;
        private SpriteFont font;
        public Boolean isDisplaying = false;
        private KeyboardState play;
        private Vector2 playPos = new Vector2(150, 200);
        private Vector2 quitPos = new Vector2(150, 250);
        private Vector2 selectorPos = new Vector2(120, 200);
        private Boolean musicPlayed;

        public PauseMenu(Game1 game, Level level)
        {
            this.game = game;
            this.level = level;
            font = game.Content.Load<SpriteFont>("actions");
        }

        public void UserInputHandler()
        {
            if (isDisplaying && !musicPlayed) { 
                level.game.sounds.Pause();
                musicPlayed = true;
            }
            play = Keyboard.GetState();
            if (play.IsKeyDown(Keys.Enter) && selectorPos.Y == playPos.Y)
            {
                level.game.sounds.Pause();
                isDisplaying = false;
                musicPlayed = false;
            }
            if (play.IsKeyDown(Keys.Enter) && selectorPos.Y == quitPos.Y)
            {
                level.Quit();
                level.game.sounds.MenuSelect();
            }
            if (play.IsKeyDown(Keys.Down) && selectorPos.Y == playPos.Y)
            {
                selectorPos = new Vector2(120, quitPos.Y);
                level.game.sounds.MenuSelect();
            }
            if (play.IsKeyDown(Keys.Up) && selectorPos.Y == quitPos.Y)
            {
                selectorPos = new Vector2(120, playPos.Y);
                level.game.sounds.MenuSelect();
            }
            }
        public void Draw()
        {
            game.GraphicsDevice.Clear(Color.Black);
            level.spriteBatch.Begin();

            level.spriteBatch.DrawString(font, "Resume", playPos, Color.White);
            level.spriteBatch.DrawString(font, "I'm sick of this game", quitPos, Color.White);
            level.spriteBatch.DrawString(font, "->", selectorPos, Color.Yellow);
            level.spriteBatch.End();
            this.UserInputHandler();
        }
    }
}
