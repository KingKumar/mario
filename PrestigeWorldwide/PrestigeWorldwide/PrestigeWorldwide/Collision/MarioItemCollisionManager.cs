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
    public class MarioItemCollisionManager
    {
        IList consumableItems;
        Mario mario;
        Level level;

        public MarioItemCollisionManager(IList consumableItems, Mario mario, Level level)
        {
            this.consumableItems = consumableItems;
            this.mario = mario;
            this.level = level;
        }

        public void Update()
        {
            foreach (IConsumableItem item in consumableItems)
            {
                Rectangle objectB = item.Collider;
                Rectangle objectA = mario.Collider();
                Rectangle overlap = Rectangle.Intersect(objectA, objectB);
                if (!overlap.IsEmpty)
                {
                    item.Bump(0, -overlap.Height);
                    int returnCode = item.Consume();
                    if (returnCode == 1) { mario.marioCollisionHandler.MarioSetBig(); }
                    if (returnCode == 4) { mario.marioCollisionHandler.MarioSetFire(); }
                    if (returnCode == 5) { mario.marioCollisionHandler.MarioSetStar(); }
                    if (returnCode == 6) { mario.marioCollisionHandler.MarioSetIce(); }
                }
            }
        }
    }
}

