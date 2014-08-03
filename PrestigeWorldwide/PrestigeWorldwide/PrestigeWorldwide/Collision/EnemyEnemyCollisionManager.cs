using System;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Interfaces;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class EnemyEnemyCollisionManager
    {
        IList enemies;
        IEnemy enemyA;
        Level level;
        Boolean continueCheck;

        public EnemyEnemyCollisionManager(IList enemies, Level level)
        {
            this.enemies = enemies;
            this.level = level;
        }

        public void Update(IEnemy enemyA)
        {
            this.enemyA = enemyA;
            foreach (IEnemy enemyB in enemies)
            {
                Rectangle objectA = enemyA.Collider;
                Rectangle objectB = enemyB.Collider;
                Rectangle overlap = Rectangle.Intersect(objectA, objectB);
                continueCheck = true;
                if (enemyB.IsDead == false)
                {
                    if (enemyA is Koopa)
                    {
                        Koopa koopa = (Koopa)enemyA;
                        if (koopa.iKoopa is KoopaSpin && !overlap.IsEmpty && (objectA.X != objectB.X || objectA.Y != objectB.Y))
                        {
                            enemyB.TakeDamage();
                            continueCheck = false;
                        }
                    }
                    if (continueCheck)
                    {
                        if (overlap.Width > overlap.Height)
                        {
                            if (objectA.Location.Y > objectB.Location.Y)
                            {
                                enemyA.Bump(0, overlap.Height / 2);
                            }
                            if (objectA.Location.Y < objectB.Location.Y)
                            {
                                enemyA.Bump(0, -overlap.Height / 2);
                            }

                        }
                        if (overlap.Width < overlap.Height)
                        {
                            if (objectA.Location.X > objectB.Location.X)
                            {
                                enemyA.Bump(overlap.Width / 2, 0);
                            }
                            if (objectA.Location.X < objectB.Location.X)
                            {
                                enemyA.Bump(-overlap.Width / 2, 0);
                            }
                        }
                    }
                }
            }
        }
    }
}
