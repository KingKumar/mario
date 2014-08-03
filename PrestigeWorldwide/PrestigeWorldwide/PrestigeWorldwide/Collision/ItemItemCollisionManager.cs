using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Interfaces;
using PrestigeWorldwide.Static_Values;
namespace PrestigeWorldwide
{
    public class ItemItemCollisionManager
    {
        IList consumableItems;
        Level level;

        public ItemItemCollisionManager(IList consumableItems, Level level)
        {
            this.consumableItems = consumableItems;
            this.level = level;
        }

        public void Update(IConsumableItem itemA)
        {
            foreach (IConsumableItem itemB in consumableItems)
            {
                Rectangle objectA = itemA.Collider;
                Rectangle objectB = itemB.Collider;
                Rectangle overlap = Rectangle.Intersect(objectA, objectB);
                if (overlap.Width > overlap.Height)
                {
                    if (objectA.Location.Y > objectB.Location.Y)
                    {
                        itemA.Bump(0, -overlap.Height/2);
                    }
                    if (objectA.Location.Y < objectB.Location.Y)
                    {
                        itemA.Bump(0, overlap.Height/2);
                    }
                }
                if (overlap.Width < overlap.Height)
                {
                    if (objectA.Location.X > objectB.Location.X)
                    {
                        itemA.Bump(-overlap.Width/2, 0);
                    }
                    if (objectA.Location.X < objectB.Location.X)
                    {
                        itemA.Bump(overlap.Width/2, 0);
                    }
                }
            }
        }
    }
}
