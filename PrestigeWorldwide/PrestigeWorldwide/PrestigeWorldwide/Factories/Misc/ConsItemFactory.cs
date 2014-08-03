using System;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PrestigeWorldwide.GameObjects.Items;

namespace PrestigeWorldwide
{
    public class ConsItemFactory
    {
        Texture2D IdleRedMushroom;
        Texture2D IdleGreenMushroom;
        Texture2D IdleStar;
        Texture2D IdleCoin;
        Texture2D IdleFireFlower;
        Texture2D IdleIceFlower;
        Level level;
        Vector2 location;

        public ConsItemFactory(Level level)
        {
            this.level = level;
            this.IdleRedMushroom = level.ContentLoad("ConsumableItems/RedMushroomIdle");
            this.IdleGreenMushroom = level.ContentLoad("ConsumableItems/GreenMushroomIdle");
            this.IdleStar = level.ContentLoad("ConsumableItems/StarIdle");
            this.IdleCoin = level.ContentLoad("ConsumableItems/CoinIdle");
            this.IdleFireFlower = level.ContentLoad("ConsumableItems/FireFlowerIdle");
            this.IdleIceFlower = level.ContentLoad("ConsumableItems/IceFlowerIdle");
        }

        public void CreateRedMushroom(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos - IdleRedMushroom.Height;
            level.consItemList.Add(new RedMushroom(IdleRedMushroom, location, level));
        }

        public void CreateGreenMushroom(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos - IdleGreenMushroom.Height;
            level.consItemList.Add(new GreenMushroom(IdleGreenMushroom, location, level));
        }

        public void CreateCoin(int xpos, int ypos, bool isFromBlock)
        {
            this.location.X = xpos;
            this.location.Y = ypos - IdleCoin.Height;
            level.consItemList.Add(new Coin(IdleCoin, location, level, isFromBlock));
        }

        public void CreateFireFlower(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos - IdleFireFlower.Height;
            level.consItemList.Add(new FireFlower(IdleFireFlower, location, level));
        }

        public void CreateIceFlower(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos - IdleIceFlower.Height;
            level.consItemList.Add(new IceFlower(IdleIceFlower, location, level));
        }
        public void CreateStar(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos - IdleStar.Height;
            level.consItemList.Add(new Star(IdleStar, location, level));
        }
    }
}