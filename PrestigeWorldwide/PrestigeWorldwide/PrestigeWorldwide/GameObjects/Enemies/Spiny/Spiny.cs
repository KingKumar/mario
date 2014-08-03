using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide
{
    class Spiny : IEnemy
    {
        Vector2 location;
        int isMovingRight;
        int spinyX = 1;
        int spinyY = 1;
        bool isDead;
        int isFrozen;
        public Boolean garbage = false;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        ISpiny iSpiny;
        Boolean isLethal = true;
        Level level;

        // Constructor
        public Spiny(Vector2 location, int isMovingRight, Level level)
        {
            this.level = level;
            this.location = location;
            this.isMovingRight = isMovingRight;
            iSpiny = SpinyFactory.CreateSpinyThrown(level);
        }

        public Boolean garbageCollect { get { return garbage; } set { garbage = value; } }
        public Boolean Lethal { get { return isLethal; } }
        public Rectangle Collider { get { return collider; } }
        public Boolean IsDead { get { return isDead; } }
        public int IsFrozen { get { return isFrozen; } set { isFrozen = value; } }

        // Methods
        public void TakeDamage() { }
        public void Move()
        {
            spinyX = 1;
            iSpiny = SpinyFactory.CreateSpinyMove(level);
        }

        public void GetUp()
        {
            spinyX = 0;
            iSpiny = SpinyFactory.CreateSpinyGetUp(level);
        }
        public void Bump(int X, int Y)
        {
            if (iSpiny is SpinyThrown && Y != 0) { this.GetUp(); }
            location.X += X;
            location.Y += Y;

            collider.X = (int)location.X;
            collider.Y = (int)location.Y;
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
            location.X += spinyX * (2 * isMovingRight - 1);
            location.Y += spinyY;
            collider = iSpiny.Update();
            collider.X = (int)location.X;
            collider.Y = (int)location.Y;
            if (iSpiny is SpinyGetUp && collider.Height == 0) { this.Move(); }
        }
        public void Draw()
        {
            iSpiny.Draw(location, isMovingRight, isFrozen);
        }

        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
        }
}
