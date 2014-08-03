using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace PrestigeWorldwide
{
    public class LevelCreator
    {
        public LevelCreatorController levelCreatorController;
        public Boolean isActive = false;
        public Game1 game;
        public SpriteBatch spriteBatch;
        public UILoader uiLoader;
        public ObjectDragger objectDragger;
        public ArrayList placedItemList = new ArrayList();
        public Cursor cursor;
        public LevelCreatorCamera camera;
        public int replacementAccuracyX = 1;
        public int replacementAccuracyY = 1;
        public ArrayList textureStamps = new ArrayList();

        public LevelCreator(Game1 game)
        {
            this.game = game;
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }

        public void Initialize()
        {
            isActive = true;
            levelCreatorController = new LevelCreatorController(this);
            cursor = new Cursor(this);
            objectDragger = new ObjectDragger(this);
            game.sounds.LevelCreator();
            uiLoader = new UILoader(game, this);
            camera = new LevelCreatorCamera(-250, -100);

        }

        public void Quit()
        {
            game.Exit();
        }

        public void GenerateLevel()
        {
            if (MessageBox.Show("Would you like to play your new level?", "Level Creator", MessageBoxButtons.OK) == DialogResult.OK)
            {
                LevelLoader2.SaveFile(textureStamps);
                game.currentLevelName = "CustomLevel";
                game.levelOne = new Level(game, game.currentLevelName);
                game.levelOne.loadContent();
                game.levelCreator.isActive = false;
            }
        }


        public void Update()
        {
            cursor.Update();

            if (objectDragger.hasObjectSelected && cursor.isBrushing)
            {
                replacementAccuracyX = objectDragger.currentStamp.hitBox.Width;
                replacementAccuracyY = objectDragger.currentStamp.hitBox.Height;
            }
            else
            {
                replacementAccuracyX = 1;
                replacementAccuracyY = 1;
            }

            for (int i = textureStamps.Count - 1; i >= 0; i--)
            {
                Stamp temp = (Stamp)textureStamps[i];
                if (temp.isRemoved == true)
                {
                    textureStamps.RemoveAt(i);
                }
            }
            foreach (Stamp stamp in textureStamps)
            {
                stamp.Update();
            }
            levelCreatorController.Update();
        }
        public void Draw()
        {
            foreach (Stamp stamp in textureStamps)
            {
                stamp.Draw();
            }
            uiLoader.Draw();
            foreach (Stamp stamp in textureStamps)
            {
                stamp.TemplateDraw();
            }
            cursor.Draw();
        }
    }
}
