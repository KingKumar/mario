using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.AutoLevelCreator;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class AutoLevelGenerator
    {
        Level level;
        AutoObjectGenerator autoObjectGenerator;
        int counter;
        int prevYPos = 20;
        int fallDownSpeed = 1;

        public AutoLevelGenerator(Level level)
        {
            this.level = level;
            counter = 0;
            autoObjectGenerator = new AutoObjectGenerator(level);
        }

        public void Update()
        {
            for (int i = level.blockList.Count - 1; i >= 0; i--)
            {
                IBlockObstacle block = (IBlockObstacle)level.blockList[i];
                if (!(block is DarkBrickBlock))
                {
                    Vector2 location = block.Location;
                    if (prevYPos > location.Y)
                        prevYPos = (int)location.Y;
                    location.Y += fallDownSpeed;
                    block.Location = location;
                    if (block.Location.Y > AutoLevelGeneratorConstants.screenHeight)
                        block.garbage_collect = true;
                }
            }

            foreach (IEnemy enemy in level.enemyList)
            {
                Vector2 location = enemy.Location;
                location.Y += fallDownSpeed;
                enemy.Location = location;
                if (enemy.Location.Y > AutoLevelGeneratorConstants.screenHeight)
                    enemy.garbageCollect = true;
            }

            foreach (IEnemy enemyProjectile in level.enemyProjectileList)
            {
                Vector2 location = enemyProjectile.Location;
                location.Y += 2*fallDownSpeed;
                enemyProjectile.Location = location;

            }
            foreach (IConsumableItem item in level.consItemList)
            {
                Vector2 loc = item.Location;
                loc.Y += fallDownSpeed;
                item.Location = loc;
            }

            counter++;
            level.gameStatus.score += fallDownSpeed;
            if (counter % (AutoLevelGeneratorConstants.stepSpawnInterval / fallDownSpeed) == 0)
            {
                if (counter >= int.MaxValue)
                    counter = 0;
                autoObjectGenerator.GenerateSteps(prevYPos, counter);
            }
            if (counter % AutoLevelGeneratorConstants.fallDownSpeedIncrease == 0)
                fallDownSpeed += 1;

            if (level.mario.starPower > 0)
            {
                level.mario.location.Y -= 2*MarioConstants.gravity;
                fallDownSpeed = level.mario.starPower / AutoLevelGeneratorConstants.fallDownSpeedDecrease + 1;
            }
        }
    }
}
