using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide.AutoLevelCreator
{
    class AutoObjectGenerator
    {
        Level level;
        int lakituCount = 0;

        public AutoObjectGenerator(Level level)
        {
            this.level = level;
        }

        public void ItemGenerator(int xPos, int yPos)
        {
            Random rand = new Random();
            int itemType = rand.Next(0, 4);
            if (itemType == 0)
                level.blockFactory.CreateQuestionBlock(xPos, yPos, "fireFlower");
            else if (itemType == 1)
                level.blockFactory.CreateQuestionBlock(xPos, yPos, "iceFlower");
            else if (itemType == 2)
                level.blockFactory.CreateQuestionBlock(xPos, yPos, "greenMushroom");
            else
                level.blockFactory.CreateQuestionBlock(xPos, yPos, "coin");
        }

        public void StarGenerator(int xPos, int yPos)
        {
            int yOffSet = 50;
            level.consItemFactory.CreateStar(xPos, yPos + yOffSet);
        }

        public void EnemyGenerator(int xPos, int yPos)
        {
            Random rand = new Random();
            int enemyType = rand.Next(0, 5);
            if (enemyType == 0)
                level.enemyFactory.Create_Goomba(xPos, yPos);
            else if (enemyType == 1)
                level.enemyFactory.Create_Koopa(xPos, yPos);
            else if (enemyType == 2 && lakituCount == 0)
            {
                level.enemyFactory.Create_Lakitu(xPos, yPos);
                lakituCount += 1;
            }
        }

        public void GenerateSteps(int prevYPos, int counter)
        {
            Random rand = new Random();
            int stepCount = rand.Next(2, 5);
            int prevXPos = rand.Next(0, AutoLevelGeneratorConstants.xPosRightLimit / stepCount);

            for (int i = 0; i < (stepCount); i++)
            {
                int xPos = rand.Next(prevXPos + AutoLevelGeneratorConstants.xPosOffsetLow, prevXPos + AutoLevelGeneratorConstants.xPosOffSetHigh);
                int yPos = rand.Next(prevYPos - AutoLevelGeneratorConstants.yPosOffSet, prevYPos + AutoLevelGeneratorConstants.yPosOffSet);

                int blockCount = rand.Next(3, 5);
                prevXPos = xPos + 22 * blockCount;

                for (int j = 0; j < blockCount; j++)
                {
                    int blockType = rand.Next(0, 10);
                    if (blockType <= 5)
                        level.blockFactory.CreateUsedBlock(xPos, yPos);
                    else if (blockType == 6 && counter % AutoLevelGeneratorConstants.itemGenerationInterval >= AutoLevelGeneratorConstants.itemSpawnChance)
                        ItemGenerator(xPos, yPos);
                    else
                        level.blockFactory.CreateBrickBlock(xPos, yPos, "none");
                    xPos += 22;
                }

                if (counter % AutoLevelGeneratorConstants.enemyGenerationInterval >= AutoLevelGeneratorConstants.enemySpawnChance && rand.Next(0, 10) >= 5)
                    EnemyGenerator(xPos, yPos);

                if (counter % AutoLevelGeneratorConstants.spinySpawnChance == 0)
                    lakituCount = 0;
                if (counter % AutoLevelGeneratorConstants.itemGenerationInterval > AutoLevelGeneratorConstants.starSpawnChance && rand.Next(0, 20) >= 10)
                    StarGenerator(xPos, yPos);
            }

        }
    }
}
