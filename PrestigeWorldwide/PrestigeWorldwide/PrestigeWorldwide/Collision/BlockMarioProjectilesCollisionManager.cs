using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Interfaces;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class BlockMarioProjectilesCollisionManager
    {
        IList marioProjectiles;
        Level level;

        public BlockMarioProjectilesCollisionManager(IList marioProjectiles, Level level)
        {
            this.marioProjectiles = marioProjectiles;
            this.level = level;
        }

        public void Update(IBlockObstacle block)
        {
            foreach (IProjectile projectile in marioProjectiles)
            {
                Rectangle objectA = block.Collider;
                Rectangle objectB = projectile.Collider;
                Rectangle overlap = Rectangle.Intersect(objectA, objectB);
                if (overlap.Width > overlap.Height)
                {
                    if (objectA.Location.Y > objectB.Location.Y)
                    {
                        projectile.Bump(0, -overlap.Height);
                    }
                    if (objectA.Location.Y < objectB.Location.Y)
                    {
                        projectile.Bump(0, overlap.Height);
                    }
                }
                if (overlap.Width < overlap.Height)
                {
                    if (objectA.Location.X > objectB.Location.X)
                    {
                        projectile.Bump(-overlap.Width, 0);
                        projectile.Explode();
                    }
                    if (objectA.Location.X < objectB.Location.X)
                    {
                        projectile.Bump(overlap.Width, 0);
                        projectile.Explode();
                    }
                }
            }
        }
    }
}
