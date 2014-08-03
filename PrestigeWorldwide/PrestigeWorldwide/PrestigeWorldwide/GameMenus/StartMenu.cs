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
    public class StartMenu
    {
        private Level level;
        private Texture2D title;
        private Game1 game;
        private SpriteFont font;
        public Boolean isDisplaying = true;
        private KeyboardState play;
        private Vector2 playPos = new Vector2(150, 240);
        private Vector2 createLevelPos = new Vector2(150, 290);
        private Vector2 doodleJumperPos = new Vector2(150, 340);
        private Vector2 quitPos = new Vector2(150, 390);
        private Vector2 castlePos = new Vector2(470, 260);
        private Vector2 customPos = new Vector2(470, 300);
        private Vector2 selectorPos = new Vector2(120, 240);
        public Boolean firstLaunch = true;
        public int menuTransitionCount = 95;
        bool allKeysUp = false;
        int fadeOutTimer = -1;
        Boolean faderCountdown;
        string nextScreen;

        public StartMenu(Game1 game,Level level)
        {
            this.game = game;
            this.level = level;
            font = game.Content.Load<SpriteFont>("Texture3");
            title = game.Content.Load<Texture2D>("Backgrounds/Title2");
        }

        public void UserInputHandler()
        {

            level.fadeOut.Update();

            if (menuTransitionCount > 0)
            {
                menuTransitionCount--;
                level.fadeOut.FadeIn();
            }
            else
            {
                play = Keyboard.GetState();

                if (play.IsKeyUp(Keys.Enter) && play.IsKeyUp(Keys.Up) && play.IsKeyUp(Keys.Down) && play.IsKeyUp(Keys.Right) && play.IsKeyUp(Keys.Left))
                    allKeysUp = true;


                if (allKeysUp)
                {
                    if (play.IsKeyDown(Keys.Enter) && (selectorPos.Y == playPos.Y || selectorPos.Y == doodleJumperPos.Y) && !faderCountdown)
                    {
                        if (firstLaunch == false)
                        {
                            firstLaunch = true;
                            level.fadeOut.CutToBlack();
                            menuTransitionCount = 100;
                        }
                        else
                        {
                            if (fadeOutTimer != 0)
                            {
                                faderCountdown = true;
                                level.fadeOut.FadeOut();
                                if (selectorPos.Y == playPos.Y)
                                    nextScreen = "NewGame";
                                else
                                    nextScreen = "MarioDoodleJump";
                            }
                        }
                        if (fadeOutTimer < 0) { fadeOutTimer = 200; }
                    }
                    else if (play.IsKeyDown(Keys.Enter) && selectorPos.Y == createLevelPos.Y)
                    {
                        faderCountdown = true;
                        level.fadeOut.FadeOut();
                        nextScreen = "LevelCreator";
                        allKeysUp = false;
                        if (fadeOutTimer < 0) { fadeOutTimer = 200; }

                    }

                    else if (play.IsKeyDown(Keys.Enter) && selectorPos.Y == castlePos.Y)
                    {
                        faderCountdown = true;
                        level.fadeOut.FadeOut();
                        nextScreen = "CastleLevel";
                        allKeysUp = false;
                        if (fadeOutTimer < 0) { fadeOutTimer = 200; }

                    }

                    else if (play.IsKeyDown(Keys.Enter) && selectorPos.Y == customPos.Y)
                    {
                        faderCountdown = true;
                        level.fadeOut.FadeOut();
                        nextScreen = "CustomLevel";
                        allKeysUp = false;
                        if (fadeOutTimer < 0) { fadeOutTimer = 200; }

                    }

                    else if (play.IsKeyDown(Keys.Enter) && selectorPos.Y == quitPos.Y)
                    {
                        level.Quit();
                        level.game.sounds.MenuSelect();
                        allKeysUp = false;
                    }

                    else if (play.IsKeyDown(Keys.Down) && selectorPos.Y == playPos.Y)
                    {
                        selectorPos = new Vector2(120, createLevelPos.Y);
                        level.game.sounds.MenuSelect();
                        allKeysUp = false;
                    }
                    else if (play.IsKeyDown(Keys.Down) && selectorPos.Y == createLevelPos.Y)
                    {
                        selectorPos = new Vector2(120, doodleJumperPos.Y);
                        level.game.sounds.MenuSelect();
                        allKeysUp = false;
                    }
                    else if (play.IsKeyDown(Keys.Up) && selectorPos.Y == createLevelPos.Y)
                    {
                        selectorPos = new Vector2(120, playPos.Y);
                        level.game.sounds.MenuSelect();
                        allKeysUp = false;
                    }
                    else if (play.IsKeyDown(Keys.Up) && selectorPos.Y == doodleJumperPos.Y)
                    {
                        selectorPos = new Vector2(120, createLevelPos.Y);
                        level.game.sounds.MenuSelect();
                        allKeysUp = false;
                    }
                    else if (play.IsKeyDown(Keys.Down) && selectorPos.Y == doodleJumperPos.Y)
                    {
                        selectorPos = new Vector2(120, quitPos.Y);
                        level.game.sounds.MenuSelect();
                        allKeysUp = false;
                    }
                    else if (play.IsKeyDown(Keys.Up) && selectorPos.Y == quitPos.Y)
                    {
                        selectorPos = new Vector2(120, doodleJumperPos.Y);
                        level.game.sounds.MenuSelect();
                        allKeysUp = false;
                    }
                    else if (play.IsKeyDown(Keys.Down) && selectorPos.Y == castlePos.Y)
                    {
                        selectorPos = new Vector2(440, customPos.Y);
                        level.game.sounds.MenuSelect();
                        allKeysUp = false;
                    }
                    else if (play.IsKeyDown(Keys.Up) && selectorPos.Y == customPos.Y)
                    {
                        selectorPos = new Vector2(440, castlePos.Y);
                        level.game.sounds.MenuSelect();
                        allKeysUp = false;
                    }
                    else if (play.IsKeyDown(Keys.Right))
                    {
                        selectorPos = new Vector2(440, castlePos.Y);
                        level.game.sounds.MenuSelect();
                        allKeysUp = false;
                    }

                    else if (play.IsKeyDown(Keys.Left))
                    {
                        selectorPos = new Vector2(120, playPos.Y);
                        level.game.sounds.MenuSelect();
                        allKeysUp = false;
                    }

                }
                if (faderCountdown == true)
                {
                    fadeOutTimer--;
                    game.sounds.FadeOut();
                }
                if (fadeOutTimer == 0)
                {
                    if (nextScreen == "NewGame" || nextScreen == "MarioDoodleJump" || nextScreen == "CastleLevel")
                    {
                        faderCountdown = false;
                        fadeOutTimer = -1;
                        level.spriteBatch.Begin();
                        level.spriteBatch.DrawString(font, "Loading Level...Please wait", new Vector2(200, 350), Color.White);
                        level.spriteBatch.End();

                        if (nextScreen == "NewGame")
                            game.currentLevelName = "LevelOneCSV";
                        else if (nextScreen == "CastleLevel")
                        {
                            System.Console.WriteLine(nextScreen);
                            game.currentLevelName = "CastleLevel";
                        }

                        else
                            game.currentLevelName = nextScreen;
                        game.levelOne = new Level(game, game.currentLevelName);
                        game.levelOne.loadContent();
                        isDisplaying = false;
                        firstLaunch = false;

                    }
                    else if (nextScreen == "LevelCreator")
                    {
                        game.levelCreator.Initialize();
                        game.startMenu.isDisplaying = false;
                    }
                    else if (nextScreen == "CustomLevel")
                    {
                        game.currentLevelName = "CustomLevel";
                        game.levelOne = new Level(game, game.currentLevelName);
                        game.levelOne.loadContent(true);
                        isDisplaying = false;
                        firstLaunch = false;
                    }
                }
            }
        }
        public void Draw()
        {
            game.GraphicsDevice.Clear(Color.Black);
            level.spriteBatch.Begin();
            if (firstLaunch)
            {
                Rectangle destinationRectangle = new Rectangle(0,0,level.camera.width,level.camera.height);
                level.spriteBatch.Draw(title,destinationRectangle,Color.White);


                level.game.sounds.StartMenu();
                level.spriteBatch.DrawString(font, "Begin New Game", playPos, Color.Black);
                level.spriteBatch.DrawString(font, "Level Creator", createLevelPos, Color.Black);
                level.spriteBatch.DrawString(font, "Doodle Jumper", doodleJumperPos, Color.Black);
                level.spriteBatch.DrawString(font, "Castle Level", castlePos, Color.Red);
                level.spriteBatch.DrawString(font, "Quit", quitPos, Color.Black);
                level.spriteBatch.DrawString(font, "Custom Level", customPos, Color.Black);



            }
            else
            {
                level.fadeOut.Reset();
                level.spriteBatch.DrawString(font, "Game Over!", new Vector2(300, 75), Color.White);
                level.game.sounds.GameOver();
                level.spriteBatch.DrawString(font, "Main Menu", playPos, Color.White);
                level.spriteBatch.DrawString(font, "Quit", quitPos, Color.White);


            }
            level.spriteBatch.DrawString(font, "->", selectorPos, Color.Yellow);
            level.spriteBatch.End();
            level.fadeOut.Draw();

            this.UserInputHandler();
        }
    }
}
