using System;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Interfaces;
using PrestigeWorldwide.Static_Values;
using PrestigeWorldwide.Sprites.Mario;

namespace PrestigeWorldwide
{
    public class EnemyMarioProjectileCollisionManager
    {
        IList enemies;
        Level level;

        public EnemyMarioProjectileCollisionManager(IList enemies, Level level)
        {
            this.enemies = enemies;
            this.level = level;
        }

        public void Update(IProjectile projectile)
        {
            foreach (IEnemy enemy in enemies)
            {
                Rectangle objectA = enemy.Collider;
                Rectangle objectB = projectile.Collider;
                Rectangle overlap = Rectangle.Intersect(objectA, objectB);
                if (!(enemy is Koopa))
                {
                    if (!overlap.IsEmpty && !enemy.IsDead)
                    {
                        if (projectile is IceBall) { enemy.IsFrozen = 200; }
                        else { enemy.TakeDamage(); }
                        
                        level.gameStatus.score += 100;
                        projectile.Explode();
                    }
                }
                else
                {
                    Koopa temp = (Koopa)enemy;
                    if (temp.iKoopa is KoopaMove)
                    {
                        if (!overlap.IsEmpty && !enemy.IsDead)
                        {
                            if (projectile is IceBall) { enemy.IsFrozen = 200; }
                            else { enemy.TakeDamage(); }

                            level.gameStatus.score += 100;
                            projectile.Explode();
                        }
                    }
                    else  
                        if(!overlap.IsEmpty && !enemy.IsDead)
                        {
                            projectile.Explode();
                        }
                }
            }
        }
    }
}
