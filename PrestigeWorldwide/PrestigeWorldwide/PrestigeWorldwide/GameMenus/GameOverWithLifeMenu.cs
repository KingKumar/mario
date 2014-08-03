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
    public class GameOverWithLifeMenu
    {
        private Level level;
        private Game1 game;
        private SpriteFont font;
        private KeyboardState play;
        private Vector2 playPos = new Vector2(150, 200);
        private Vector2 quitPos = new Vector2(150, 250);
        private Vector2 selectorPos = new Vector2(120, 200);
        public Boolean isDisplaying = false;
        Texture2D greenMushroom;
        Vector2 location;

        public GameOverWithLifeMenu(Game1 game, Level level)
        {
            this.game = game;
            this.level = level;
            this.location = new Vector2(100,150);
            font = game.Content.Load<SpriteFont>("actions");
            this.greenMushroom = level.game.Content.Load<Texture2D>("ConsumableItems/GreenMushroomIdle");
        }
        public void Update(GameTime gameTime)
        {
            play = Keyboard.GetState();
            if (play.IsKeyDown(Keys.Enter) && selectorPos.Y == playPos.Y)
            {
                this.ResetLevel();
            }

            if (play.IsKeyDown(Keys.Enter) && selectorPos.Y == quitPos.Y)
                level.Quit();
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
        public void ResetLevel()
        {
            int passCoin = level.gameStatus.coinCount;
            int passLives = level.gameStatus.lifeCount;
            this.level = game.levelOne = new Level(game, game.currentLevelName);
            game.levelOne.loadContent();
            level.gameStatus.coinCount = passCoin;
            level.gameStatus.lifeCount = passLives;
            isDisplaying = false;
        }
        public void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.Black);
            level.spriteBatch.Begin();
            level.spriteBatch.DrawString(font, "You died!", new Vector2(50, 75), Color.White);
            level.spriteBatch.Draw(greenMushroom, new Rectangle((int)location.X, (int)location.Y, greenMushroom.Width, greenMushroom.Height), Color.White);
            Vector2 temp = new Vector2(location.X + 50, location.Y);
            level.spriteBatch.DrawString(font, "x" + level.gameStatus.lifeCount.ToString(), temp, Color.White);
            level.spriteBatch.DrawString(font, "Try Again", playPos, Color.White);
            level.spriteBatch.DrawString(font, "This Game is Too Hard for Me", quitPos, Color.White);
            level.spriteBatch.DrawString(font, "->", selectorPos, Color.Yellow);
            level.spriteBatch.End();
            this.Update(gameTime);
        }
    }
}
