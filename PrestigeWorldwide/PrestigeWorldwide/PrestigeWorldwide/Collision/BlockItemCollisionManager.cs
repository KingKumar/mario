using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Interfaces;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class BlockItemCollisionManager
    {
        IList consumableItems;
        Level level;

        public BlockItemCollisionManager(IList consumableItems, Level level)
        {
            this.consumableItems = consumableItems;
            this.level = level;
        }

        public void Update(IBlockObstacle block)
        {
            foreach (IConsumableItem item in consumableItems)
            {
                Rectangle objectA = block.Collider;
                Rectangle objectB = item.Collider;
                Rectangle overlap = Rectangle.Intersect(objectA, objectB);
                if (overlap.Width > overlap.Height)
                {
                    if (objectA.Location.Y > objectB.Location.Y)
                    {
                        item.Bump(0, -overlap.Height);
                    }
                    if (objectA.Location.Y < objectB.Location.Y)
                    {
                        item.Bump(0, overlap.Height);
                    }
                }
                if (overlap.Width < overlap.Height)
                {
                    if (objectA.Location.X > objectB.Location.X)
                    {
                        item.Bump(-overlap.Width, 0);
                    }
                    if (objectA.Location.X < objectB.Location.X)
                    {
                        item.Bump(overlap.Width, 0);
                    }
                }
            }
        }
    }
}