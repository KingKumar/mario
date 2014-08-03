using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    class Koopa : IEnemy
    {
        Vector2 location;
        int isMovingRight;
        int fallCounter = EnemyConstants.fallCounter;
        int koopaX=EnemyConstants.koopaXPos;
        int koopaY=EnemyConstants.koopaYPos;
        int transitionCount;
        int idleCount;
        bool isDead;
        int isFrozen;
        Boolean isLethal = true;
        public Boolean garbage = false;
        Rectangle collider = new Rectangle(0, 0, 0, 0);
        public IKoopaState iKoopa;
        Level level;


        public Koopa(Vector2 location,int isMovingRight,Level level)
        {
            this.level = level;
            this.location = location;
            this.isMovingRight = isMovingRight;
            iKoopa = KoopaFactory.CreateMovingKoopa(level);
        }
        public Boolean garbageCollect { get { return garbage; } set { garbage = value; } }
        public Boolean Lethal { get { return isLethal; } }
        public Rectangle Collider { get { return collider; } }
        public Boolean IsDead { get { return isDead; } }
        public int IsFrozen { get { return isFrozen; } set { isFrozen = value; } }

        public void TakeDamage()
        {

            if (iKoopa is KoopaMove&&transitionCount == 0)
            {
                iKoopa = KoopaFactory.CreateKoopaIntoShell(level);
                koopaX = 0;
                transitionCount = 10;
                isLethal = false;
            }
            if ((iKoopa is KoopaIntoShell||iKoopa is KoopaIdle) &&transitionCount == 0)
            {
                iKoopa = KoopaFactory.CreateSpinningKoopa(level);
                koopaX = 2;
                isLethal = true;
                transitionCount = 10;

            }
            if (iKoopa is KoopaSpin&&transitionCount == 0)
            {
                iKoopa = KoopaFactory.CreateKoopaIdle(level);
                isLethal = false;
                koopaX = 0;
                transitionCount = 10;

            }
            level.game.sounds.Kick();
        }
        public void GetUp()
        {
            iKoopa = KoopaFactory.CreateKoopaOutOfShell(level);
            isLethal = true;
            transitionCount = 10;
        }
        public void Bump(int X,int Y)
        {
            fallCounter = EnemyConstants.fallCounter;
            if (Y != 0) { koopaY = 1; }
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
            if (isFrozen > 0) { isFrozen--; }
            if (location.X > level.camera.X && location.X < level.camera.X + level.camera.width && location.Y > level.camera.Y)
            {
                fallCounter--;
                if (fallCounter == 0) { koopaY = 3; }
                if (transitionCount > 0)
                {
                    transitionCount--;
                }
                if (iKoopa is KoopaIdle) { idleCount++; }
                if (idleCount >= 300)
                {
                    GetUp();
                    idleCount = 0;
                }

                if (iKoopa is KoopaOutOfShell && transitionCount == 0) { 
                    iKoopa = KoopaFactory.CreateMovingKoopa(level);
                    koopaX = EnemyConstants.koopaXPos;
                }
                if (isFrozen == 0)
                {
                    location.X += koopaX * (2 * isMovingRight - 1);
                    isLethal = true;
                }
                else
                    isLethal = false;
                location.Y += koopaY;
                collider = iKoopa.Update();
                collider.X = (int)location.X;
                collider.Y = (int)location.Y;
            }
        }
        public void Draw()
        {
            iKoopa.Draw(location,isMovingRight, IsFrozen);
        }

        public Vector2 Location
        {
            get { return location; }
            set { location = value; }
        }
    }
    
}
