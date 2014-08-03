using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide{
    public class Goomba : IEnemy{

        int isMovingRight;
        int goombaX=EnemyConstants.goombaXPos;
        int goombaY=EnemyConstants.goombaYPos;
        int fallCounter = EnemyConstants.fallCounter;
        public bool isDead;
        int isFrozen;
        Vector2 location;
        public Boolean garbage = false;
        public Rectangle collider = new Rectangle(0, 0, 0, 0);
        IGoombaState iGoomba;
        Level level;
        Boolean isLethal = true;

        public Goomba(Vector2 location,int isMovingRight,Level level){
            this.location = location;
            this.level = level;
            this.isMovingRight = 1;
            iGoomba = GoombaFactory.CreateWalkingGoomba(level);
        }
        public Boolean garbageCollect { get { return garbage; } set { garbage = value; } }
        public Boolean Lethal { get { return isLethal; } }
        public Rectangle Collider { get { return collider; } }
        public Boolean IsDead { get { return isDead; } }
        public int IsFrozen { get { return isFrozen; } set { isFrozen = value; } }

        public void Bump(int X, int Y)
        {
            fallCounter = 5;
            location.X += X;
            location.Y += Y;
            collider.X = (int)location.X;
            collider.Y = (int)location.Y;
            if (Y != 0) { goombaY = 1; }
            if (X > 0)
            {
                isMovingRight = 1;
            }
            if (X < 0)
            {
                isMovingRight = 0;
            }
        }

        public void TakeDamage()
        {
            iGoomba = GoombaFactory.CreateDeadGoomba(level);
            isDead = true;
            isLethal = false;
            goombaX = 0;
            goombaY = 0;
            level.game.sounds.Kick();
        }

        public void Update(){
            if (isFrozen > 0) { isFrozen--; }
            if (location.X + collider.Width> level.camera.X && location.X < level.camera.X + level.camera.width && location.Y > level.camera.Y && location.Y < level.camera.Y + level.camera.height)
            {
                fallCounter--;
                if (fallCounter == 0) { goombaY = 3; }
                if (isFrozen == 0)
                {
                    location.X += goombaX * (2 * isMovingRight - 1);
                    isLethal = true;
                }
                else
                    isLethal = false;
                location.Y += goombaY;
                collider = iGoomba.Update();
                collider.X = (int)location.X;
                collider.Y = (int)location.Y;
                if (collider.Height == 0) { garbage = true; }
            }
        }
        public void Draw(){
            iGoomba.Draw(location,isMovingRight, isFrozen);
        }

        public Vector2 Location
        {
            get
            { return location; }
            set
            { location = value; }
        }
    }
}