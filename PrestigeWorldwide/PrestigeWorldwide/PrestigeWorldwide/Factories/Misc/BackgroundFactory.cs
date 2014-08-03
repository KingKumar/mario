using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    public class Background_Factory
    {
        //Cloud Texture
        Texture2D cloud;

        //Small Bush Texture
        Texture2D smBush;

        //Large Bush Texture
        Texture2D lgBush;

        //Hill Texture
        Texture2D hill;

        //Shine Texture
        Texture2D shine;

        //Castle Texture
        Texture2D castle;

        //Flagpole Texture
        Texture2D flagpole;

        //Flag Texture
        Texture2D flag;

        //Level Backgrounds
        Texture2D levelOne;
        Texture2D darkRoom;

        Level level;

        IList BgList;
        Vector2 location;
        SpriteBatch spritebatch;

        public Background_Factory(IList backgroundList, Level gameIn, SpriteBatch spritebatch)
        {
            level = gameIn;
            this.BgList = backgroundList;
            this.spritebatch = spritebatch;

            cloud = level.game.Content.Load<Texture2D>("Backgrounds/cloud");
            levelOne = level.game.Content.Load<Texture2D>("Backgrounds/lvl_one");
            smBush = level.game.Content.Load<Texture2D>("Backgrounds/smallBush");
            lgBush = level.game.Content.Load<Texture2D>("Backgrounds/bigBush");
            hill = level.game.Content.Load<Texture2D>("Backgrounds/hill");
            shine = level.game.Content.Load<Texture2D>("Backgrounds/shine");
            darkRoom = level.game.Content.Load<Texture2D>("Backgrounds/DarkRoom");
            flag = level.game.Content.Load<Texture2D>("Backgrounds/flag");
            castle = level.game.Content.Load<Texture2D>("Backgrounds/castle");
        }

        public void Create_Cloud(int X_pos, int Y_pos, int state)
        {
            location.X = X_pos;
            location.Y = Y_pos;
            level.backgroundList.Add(new Cloud(cloud, this.spritebatch, 1, location,level));
        }

        public void Create_LittleBush(int X_pos, int Y_pos, int state)
        {
            location.X = X_pos;
            location.Y = Y_pos;
            level.backgroundList.Add(new SmallBush(smBush, this.spritebatch, 1, location,level));
        }

        public void Create_BigBush(int X_pos, int Y_pos, int state)
        {
            location.X = X_pos;
            location.Y = Y_pos;
            level.backgroundList.Add(new LargeBush(lgBush, this.spritebatch, 1, location,level));
        }

        public void Create_Hill(int X_pos, int Y_pos, int state)
        {
            location.X = X_pos;
            location.Y = Y_pos;
            level.backgroundList.Add(new Hill(hill, this.spritebatch, 1, location,level));
        }

        public void Create_Shine(int X_pos, int Y_pos, int state)
        {
            location.X = X_pos;
            location.Y = Y_pos;
            level.backgroundList.Add(new Shine(shine, this.spritebatch, 1, location,level));
        }

        public void Create_DarkRoom(int X_pos, int Y_pos, int state)
        {
            location.X = X_pos;
            location.Y = Y_pos;
            level.backgroundList.Add(new DarkRoom(darkRoom, this.spritebatch, 1, location, level));
        }

        public void Create_Flag(int X_pos, int Y_pos, int state)
        {
            location.X = X_pos;
            location.Y = Y_pos;
            level.backgroundList.Add(new Flag(flag, this.spritebatch, location, level));
        }

        public void Create_Castle(int X_pos, int Y_pos, int state)
        {
            location.X = X_pos;
            location.Y = Y_pos;
            level.backgroundList.Add(new Castle(castle, this.spritebatch, location, level));
        }
    }

}
