using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Interfaces;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class EnemyItemCollisionManager
    {
        IList consumableItems;
        Level level;

        public EnemyItemCollisionManager(IList consumableItems, Level level)
        {
            this.consumableItems = consumableItems;
            this.level = level;
        }

        public void Update(IEnemy enemy)
        {
            foreach (IConsumableItem item in consumableItems)
            {
                Rectangle objectA = enemy.Collider;
                Rectangle objectB = item.Collider;
                Rectangle overlap = Rectangle.Intersect(objectA, objectB);
                if (overlap.Width > overlap.Height)
                {
                    if (objectA.Location.Y > objectB.Location.Y)
                    {
                        item.Bump(0, -overlap.Height/2);
                        enemy.Bump(0,overlap.Height/2);
                    }
                    if (objectA.Location.Y < objectB.Location.Y)
                    {
                        item.Bump(0, overlap.Height/2);
                        enemy.Bump(0, -overlap.Height/2);
                    }
                }
                if (overlap.Width < overlap.Height)
                {
                    if (objectA.Location.X > objectB.Location.X)
                    {
                        item.Bump(-overlap.Width/2, 0);
                        enemy.Bump(overlap.Width/2, 0);
                    }
                    if (objectA.Location.X < objectB.Location.X)
                    {
                        item.Bump(overlap.Width/2, 0);
                        enemy.Bump(-overlap.Width/2, 0);
                    }
                }
            }
        }
    }
}
