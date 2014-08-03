using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    public class LevelCreator
    {
        public LevelCreatorController levelCreatorController;
        public Boolean isActive = false;
        public Game1 game;
        public SpriteBatch spriteBatch;

        public LevelCreator(Game1 game)
        {
            this.game = game;
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }

        public void Initialize()
        {
            isActive = true;
            levelCreatorController = new LevelCreatorController(this);
        }

        public void Update()
        {
            levelCreatorController.Update();
        }
        public void Draw()
        {

        }
    }
}
