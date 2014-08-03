using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Interfaces;
using PrestigeWorldwide.Interfaces.MarioProjectile;
using PrestigeWorldwide.Sprites.Mario.Projectile;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide.Sprites.Mario
{
    class FireBall : IProjectile
    {
        IFireBallState fireBall;
        int isMovingRight;
        int explosionDuration;
        int bounce;
        Vector2 location;
        Boolean garbage;
        Level level;

        public Rectangle collider = new Rectangle(0, 0, 0, 0);
        public Boolean garbageCollect { get { return garbage; } }

        public Rectangle Collider { get { return collider; } }

        public FireBall(Level level, int isMovingRight, Vector2 location)
        {
            this.level = level;
            this.isMovingRight = isMovingRight;
            this.location = location;
            this.fireBall = new FireBallMoving(level);
            this.explosionDuration = MarioConstants.explosionDuration;
            this.garbage = false;
            this.bounce = 0;
        }

        public void Update()
        {
            if (fireBall is FireBallExplosion)
            {
                explosionDuration--;
                if (explosionDuration < 0){ this.garbage = true; }
            }
            else
            {
            location.X += 4 * (2 * isMovingRight - 1);
                location.Y += 1 - bounce;
                if (bounce > 0){ bounce--; }
            }
            collider = fireBall.Update();
            collider.X = (int)location.X;
            collider.Y = (int)location.Y;
        }

        public void Draw()
        {
            fireBall.Draw(location, isMovingRight);
        }

        public void Bump(int X, int Y)
        {
            location.X += X;
            location.Y += Y;
            bounce = MarioConstants.bounce;
            if (X > 0) { isMovingRight = 1; }

            if (X < 0) {isMovingRight = 0; }
            }

        public void Explode()
        { this.fireBall = new FireBallExplosion(level); }
    }
}
