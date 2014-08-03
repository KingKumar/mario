using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide
{
    public class Lakitu : IEnemy
    {


        Vector2 location;
        int isMovingRight;
        int throwCount = 5;
        int lakituX = 1;
        int lakituY = 0;
        bool isDead;
        int isFrozen;
        Boolean isLethal = true;
        public Boolean garbage = false;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        ILakituState iLakitu;
        Level level;

        // Constructor
        public Lakitu(Vector2 location, int isMovingRight, Level level)
        {
            this.level = level;
            this.location = location;
            iLakitu = LakituFactory.CreateLakituMove(level);


        }
        public Boolean garbageCollect { get { return garbage; } set { garbage = value; } }
        public Boolean Lethal { get { return isLethal; } }
        public Rectangle Collider { get { return collider; } }
        public Boolean IsDead { get { return isDead; } }
        public int IsFrozen { get { return isFrozen; } set { isFrozen = value; } }

        // Methods
        public void TakeDamage() {

            level.game.sounds.Kick();

        }
        public void Move()
        {
            throwCount = 10;
            iLakitu = LakituFactory.CreateLakituMove(level);
        }
        public void Throw()
        {
            iLakitu = LakituFactory.CreateLakituThrow(level);
        }
        public void Bump(int X, int Y)
        {
            location.X += X;
            location.Y += Y;
            if (X > 0)
            {
                isMovingRight = 1;
            }
            if (X < 0)
            {
                isMovingRight = 0;
            }
        }
        public void Update()
        {
            throwCount--;
            location.X += lakituX * (2 * isMovingRight - 1);
            location.Y += lakituY;
            collider = iLakitu.Update(location,isMovingRight);
            collider.X = (int)location.X;
            collider.Y = (int)location.Y;
            if (throwCount == 0) { this.Throw(); }
            if (iLakitu is LakituThrow && collider.Height == 0) { this.Move(); }
        }
        public void Draw()
        {
            iLakitu.Draw(location, isMovingRight, IsFrozen);
        }

        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}