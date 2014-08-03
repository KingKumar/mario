using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Mario_States;

namespace PrestigeWorldwide.MarioStateClass
{
    class MarioClass
    {
        public IMarioState marioState;
        public String powerLevel;
        int score;
        bool isRightOrJumping;
        bool isAlive;
        public MarioClass(Game1 game, SpriteBatch spriteBatch)
        {
            marioState = new SmallMarioState(game, spriteBatch); 
            powerLevel = "Small";
            
            isRightOrJumping = true;
            isAlive = true;
        }

        public void Update()
        {
            marioState.Update();
        }
        public void Draw()
        {
            marioState.Draw();
        }

    }
}
