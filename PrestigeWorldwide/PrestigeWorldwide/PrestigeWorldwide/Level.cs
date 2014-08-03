using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrestigeWorldwide.Interfaces;
using System.Windows.Forms;
using PrestigeWorldwide.Sprites.Blocks;
using PrestigeWorldwide.GameMenus;

namespace PrestigeWorldwide
{
    public class Level
    {
        public ArrayList controllerList = new ArrayList();
        public IList blockList = new ArrayList();
        public IList blockletList = new ArrayList();
        public IList consItemList = new ArrayList();
        public IList enemyList = new ArrayList();
        public IList enemyProjectileList = new ArrayList();
        public IList marioProjectileList = new ArrayList();
        public ConsItemFactory consItemFactory;
        public Enemy_Factory enemyFactory;
        public BlockFactory blockFactory;
        public SpriteBatch spriteBatch;

        public IList backgroundList = new ArrayList();
        public Background_Factory backgroundFactory;
        public SecretEntrance secretEntrance;
        public CollisionManager collisionHandler;
        public GameStatus gameStatus;

        public Mario mario;
        public Trap trap;
        public Camera camera;

        // For the moment until we get ILevel
        public String levelName;
        public AutoLevelGenerator levelGenerator;

        public Vector2 trapLocation;
        public Game1 game;
        public StartMenu startMenu;
        public PauseMenu pauseMenu;
        public Transition fadeOut;
        int musicFadeInTimer;

        public VictoryAnimation victoryAnimation;

        public Level(Game1 gameIn, String levelName)
        {
            game = gameIn;
            startMenu = game.startMenu;
            this.levelName = levelName;
        }

        public Texture2D ContentLoad(string content)
        {
            return this.game.Content.Load<Texture2D>(content);
        }

        public void Quit() 
        {
            game.Exit();
        }
        public void PlayVictoryAnimation(Vector2 flagpoleLocation)
        {
            game.sounds.StageClear();
            victoryAnimation.Play(flagpoleLocation);
        }
        public void loadContent(Boolean loadCustom = false)
        {
            fadeOut = new Transition(this);
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            game.sounds.PlayMain();
            mario = new Mario(this);
            consItemFactory = new ConsItemFactory(this);
            enemyFactory = new Enemy_Factory(enemyList, enemyProjectileList, this, spriteBatch);
            blockFactory = new BlockFactory(this);
            backgroundFactory = new Background_Factory(backgroundList, this, spriteBatch);
            collisionHandler = new CollisionManager(this, enemyList, enemyProjectileList, consItemList, blockList, mario, marioProjectileList);
            controllerList.Add(new KeyboardController(this, enemyFactory, backgroundFactory));
            controllerList.Add(new GamepadController(this));
            camera = new Camera(this, game.graphics.GraphicsDevice.Viewport.Width, game.graphics.GraphicsDevice.Viewport.Height);

            //LevelLoader.LoadFromCSV("Content/Unit Test/" + this.levelName + ".txt", consItemFactory, enemyFactory, blockFactory, backgroundFactory);
            if (this.levelName == "CustomLevel")
            {
                LevelLoader2.LoadFile(LevelLoaderConstants.path, consItemFactory, enemyFactory, blockFactory, backgroundFactory,this);
            }
            else
                LevelLoader2.LoadFile("Content/Unit Test/" + this.levelName + ".txt", consItemFactory, enemyFactory, blockFactory, backgroundFactory,this);
            levelGenerator = new AutoLevelGenerator(this);
            trapLocation.X = 0;
            trapLocation.Y = 0;
            trap = new Trap(this, 250, 300, trapLocation);
            gameStatus = new GameStatus(this);
            pauseMenu = new PauseMenu(game, this);
            victoryAnimation = new VictoryAnimation(this);
            fadeOut.FadeIn();
            
        }
        public void Update(GameTime gameTime)
        {
            fadeOut.Update();
            if (musicFadeInTimer < 100)
            {
                musicFadeInTimer++;
                game.sounds.FadeIn();
            }
            game.sounds.kickTimer--;
            if (!victoryAnimation.isPlaying && !pauseMenu.isDisplaying && !game.gameOverWithLifeMenu.isDisplaying)
            {
                foreach (IController controller in controllerList)
                {
                    controller.Update();
                }
                //Garbage Collector
                for (int i = enemyList.Count - 1; i >= 0; i--)
                {
                    IEnemy temp = (IEnemy)enemyList[i];
                    if (temp.garbageCollect == true)
                        enemyList.RemoveAt(i);
                    else
                        temp.Update();
                }
                for (int i = enemyProjectileList.Count - 1; i >= 0; i--)
                {
                    IEnemy temp = (IEnemy)enemyProjectileList[i];
                    if (temp.garbageCollect == true)
                        enemyProjectileList.RemoveAt(i);
                    else
                        temp.Update();
                }

                for (int i = marioProjectileList.Count - 1; i >= 0; i--)
                {
                    IProjectile temp = (IProjectile)marioProjectileList[i];
                    if (temp.garbageCollect == true)
                        marioProjectileList.RemoveAt(i);
                    else
                        temp.Update();
                }

                for (int i = consItemList.Count - 1; i >= 0; i--)
                {
                    IConsumableItem temp = (IConsumableItem)consItemList[i];
                    if (temp.garbage_collect == true)
                        consItemList.RemoveAt(i);
                    else
                        temp.Update();
                }

                for (int i = blockletList.Count - 1; i >= 0; i--)
                {
                    IBlockObstacle temp = (IBlockObstacle)blockletList[i];
                    if (temp.garbage_collect == true)
                    {
                        blockletList.RemoveAt(i);
                    }
                    else
                        temp.Update();
                }
                if (!mario.isAlive && gameStatus.lifeCount < 0)
                {
                    game.startMenu.isDisplaying = true;
                }
                else if (!mario.isAlive && gameStatus.lifeCount >= 0)
                {
                    game.gameOverWithLifeMenu.isDisplaying = true;
                }
                gameStatus.Update(gameTime);

                for (int i = blockList.Count - 1; i >= 0; i--)
                {
                    IBlockObstacle temp = (IBlockObstacle)blockList[i];
                    if (temp.garbage_collect == true)
                    {
                        blockList.RemoveAt(i);
                    }
                    else
                        temp.Update();

                }

                // Update when playing Doodle jump
                if (levelName == "MarioDoodleJump")
                    levelGenerator.Update();

                collisionHandler.Update();
                for (int i = backgroundList.Count - 1; i >= 0; i--)
                {
                    IBackground temp = (IBackground)backgroundList[i];
                    temp.Update();
                }
            }
            else if (victoryAnimation.isPlaying)
            {
                victoryAnimation.Update();
                fadeOut.Update();
                collisionHandler.Update();
            }

            trap.Update();
            camera.Update();
        }

        public void Draw(GameTime gameTime)
        {
            if (pauseMenu.isDisplaying)
                pauseMenu.Draw();

            foreach (IBackground bg in backgroundList)
            {
                bg.Draw();
            }
            mario.Draw();
            foreach (IConsumableItem consItem in consItemList)
            {
                consItem.Draw();
            }

            foreach (IBlockObstacle block in blockList)
            {
                block.Draw();
            }

            foreach (IBlockObstacle block in blockletList)
            {
                block.Draw();
            }

            foreach (IEnemy enemy in enemyList)
            {
                enemy.Draw();
            }
            foreach (IEnemy enemy in enemyProjectileList)
            {
                enemy.Draw();
            }
            foreach (IProjectile projectile in marioProjectileList)
            { projectile.Draw(); }
            gameStatus.Draw(gameTime);
            fadeOut.Draw();
        }
    }
}
