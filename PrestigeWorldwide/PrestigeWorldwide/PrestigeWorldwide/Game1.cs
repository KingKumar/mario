using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Windows.Forms;

namespace PrestigeWorldwide
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteFont font;
        public Level levelOne;
        public LevelCreator levelCreator;
        public StartMenu startMenu;
        public SoundManager sounds;
        public GameOverWithLifeMenu gameOverWithLifeMenu;

        public String currentLevelName;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            levelCreator = new LevelCreator(this);
            currentLevelName = "LevelOneCSV";
            levelOne = new Level(this, currentLevelName);
            startMenu = new StartMenu(this, levelOne);
            gameOverWithLifeMenu = new GameOverWithLifeMenu(this, levelOne);
            sounds = new SoundManager(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            font = Content.Load<SpriteFont>("actions");
            levelOne.loadContent();

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (levelCreator.isActive)
                levelCreator.Update();

            if(!startMenu.isDisplaying && !levelCreator.isActive)
                levelOne.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (levelCreator.isActive)
                levelCreator.Draw();

            else if (gameOverWithLifeMenu.isDisplaying)
                gameOverWithLifeMenu.Draw(gameTime);

            else if (startMenu.isDisplaying)
                startMenu.Draw();

            else
                levelOne.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
