using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class GameStatus
    {
        SpriteFont font;
        Texture2D coin;
        public int coinCount;
        public int score;
        public int lifeCount;
        Level level;
        Vector2 location;
        public ArrayList floatingScore = new ArrayList();
        public GameStatus(Level level)
        {
            this.level = level;
            this.font = level.game.Content.Load<SpriteFont>("actions");
            this.coin = level.game.Content.Load<Texture2D>("ConsumableItems/CoinIdle");
            this.location = new Vector2(10, 10);
            this.coinCount = 0;
            this.score = 0;
            this.lifeCount = MarioConstants.lifeCount;
        }

        public void Update(GameTime gameTime)
        {
            if (coinCount == MarioConstants.coinLifeGain)
            {
                lifeCount++;
                coinCount -= MarioConstants.coinLifeGain;
            }
        }

        public void Draw(GameTime gameTime)
        {
            level.spriteBatch.Begin();
            level.spriteBatch.DrawString(font, "MARIO" + new String(' ', 25) + "WORLD" + new String(' ', 25) + "TIME", location, Color.White);
            Vector2 temp = location;
            temp.Y += 20;
            level.spriteBatch.Draw(coin, new Rectangle((int)temp.X + 200, (int)temp.Y, coin.Width/4, coin.Height), new Rectangle(0,0,coin.Width/4,coin.Height), Color.White);
            Vector2 temp1 = temp;
            temp1.X += 210;
            level.spriteBatch.DrawString(font, " X " + coinCount.ToString(), temp1, Color.White);
            level.spriteBatch.DrawString(font, "  " + ((float)score).ToString() + new String(' ',28) + "1-1", temp, Color.White);
            level.spriteBatch.DrawString(font, new String(' ', 61) + gameTime.TotalGameTime.Seconds, temp, Color.White);
            level.spriteBatch.End();
        }

    }
}
