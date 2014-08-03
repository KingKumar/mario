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
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{

    public class Enemy_Factory
    {
        Level level;

        IList enemyList;
        IList enemyProjectileList;
        Vector2 location;
        SpriteBatch spritebatch;

        public Enemy_Factory(IList enemyList, IList enemyProjectileList, Level level, SpriteBatch spritebatch)
        {
            this.level = level;
            this.enemyList = enemyList;
            this.enemyProjectileList = enemyProjectileList;
            this.spritebatch = spritebatch;
        }
        public void Create_Goomba(int X_pos, int Y_pos)
        {
            location.X = X_pos;
            location.Y = Y_pos;
            level.enemyList.Add(new Goomba(location,EnemyConstants.isMovingRight,level));    
        }
        public void Create_Koopa(int X_pos, int Y_pos)
        {
            location.X = X_pos;
            location.Y = Y_pos;
            level.enemyList.Add(new Koopa(location, EnemyConstants.isMovingRight, level));
            }
        public void Create_Lakitu(int xPos, int yPos)
        {
            location.X = xPos;
            location.Y = yPos;
            level.enemyList.Add(new Lakitu(location, EnemyConstants.isMovingRight, level));
        }

        public void Create_Spiny(int xPos,int yPos,int isMovingRight)
        {
            location.X = xPos;
            location.Y = yPos;
            level.enemyProjectileList.Add(new Spiny(location,isMovingRight,level));
        }

    }
}