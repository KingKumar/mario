using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;

namespace PrestigeWorldwide
{

    public class LevelLoader
    {
        public static void mapObject(string obj, int height, int width, ConsItemFactory itemFactory, Enemy_Factory enemyFactory, BlockFactory blockFactory, Background_Factory bgFactory) 
        {
            switch (obj)
            {
                case "shine":
                    bgFactory.Create_Shine(width, height, 0);
                    break;
                case "cloud":
                    bgFactory.Create_Cloud(width, height, 0);
                    break;
                case "hill":
                    bgFactory.Create_Hill(width, height, 0);
                    break;
                case "bigbush":
                    bgFactory.Create_BigBush(width, height, 0);
                    break;
                case "smallbush":
                    bgFactory.Create_LittleBush(width, height, 0);
                    break;
                case "darkbg":
                    bgFactory.Create_DarkRoom(width, height, 0);
                    break;
                case "pole":
                    blockFactory.CreateFlagpole(width, height);
                    break;
                case "flag":
                    bgFactory.Create_Flag(width + 10, height, 0);
                    break;
                case "castle":
                    bgFactory.Create_Castle(width, height, 0);
                    break;
                case "cfb":
                    blockFactory.CreateCastleFloorBlock(width, height);
                    break;
                case "lava":
                    blockFactory.CreateLavaBlock(width, height);
                    break;
                case "castlepipe":
                    blockFactory.CreateCastlePipe(width, height + 10);
                    break;
                case "portal":
                    blockFactory.CreateCastlePortal(width, height + 10);
                    break;
                case "brick":
                    blockFactory.CreateBrickBlock(width, height, "none");
                    break;
                case "pyr":
                    blockFactory.CreatePyramidBlock(width, height);
                    break;
                case "cbrick":
                    blockFactory.CreateBrickBlock(width, height, "coin");
                    break;
                case "gbrick":
                    blockFactory.CreateBrickBlock(width, height, "greenMushroom");
                    break;
                case "dbrick":
                    blockFactory.CreateDarkBrickBlock(width, height);
                    break;
                case "?":
                    blockFactory.CreateQuestionBlock(width, height, "coin");
                    break;
                case "@":
                    blockFactory.CreateQuestionBlock(width, height, "redMushroom");
                    break;
                case "#":
                    blockFactory.CreateQuestionBlock(width, height, "fireFlower");
                    break;
                case "+":
                    blockFactory.CreateQuestionBlock(width, height, "iceFlower");
                    break;
                case "!":
                    blockFactory.CreateQuestionBlock(width, height, "greenMushroom");
                    break;
                case "$":
                    blockFactory.CreateQuestionBlock(width, height, "star");
                    break;
                case "pipe":
                    blockFactory.CreateGreenPipe(width, height);
                    break;
                case "dpipe":
                    blockFactory.CreateGreenPipe(width, height);
                    break;
                case "enter":
                    blockFactory.CreateSecretEntrance(width, height);
                    break;
                case "exit":
                    blockFactory.CreateSecretExit(width, height);
                    break;
                case "used":
                    blockFactory.CreateUsedBlock(width, height);
                    break;
                case "floor":
                    blockFactory.CreateFloorBlock(width, height);
                    break;
                case "dfloor":
                    blockFactory.CreateDarkFloorBlock(width, height);
                    break;
                case "goomba":
                    enemyFactory.Create_Goomba(width, height);
                    break;
                case "koopa":
                    enemyFactory.Create_Koopa(width, height);
                    break;
                case "gshroom":
                    itemFactory.CreateGreenMushroom(width, height);
                    break;
                case "rshroom":
                    itemFactory.CreateRedMushroom(width, height);
                    break;
                case "coin":
                    itemFactory.CreateCoin(width, height, false);
                    break;
                case "star":
                    itemFactory.CreateStar(width, height);
                    break;
                case "fire":
                    itemFactory.CreateFireFlower(width, height);
                    break;
                default:
                    Console.WriteLine("Incorrect object name.");
                    break;
            }  
        }

        public static void LoadFromCSV(string path, ConsItemFactory itemFactory, Enemy_Factory enemyFactory, BlockFactory blockFactory, Background_Factory bgFactory)
        {
            ArrayList tempList = new ArrayList();
            try
            {
                using (StreamReader readFile = new StreamReader(path))
                {
                    string line;
                    int rowsDownward = 0;
                    int pixelFactor = 20;
                    while ((line = readFile.ReadLine()) != null)
                    {
                        int heightPosition;
                        int widthPosition;
                        //determine if there is an object to be instantiated at this pixel height; skip line if only commas
                        Match objectInRowMatch = Regex.Match(line, @"[A-Za-z0-9\-]+");
                        if (objectInRowMatch.Success)
                        {
                            int columnsInward = 0;
                            while (line.Length > 0)
                            {
                                if (line.StartsWith(","))
                                {
                                    line = line.Remove(0,1);
                                    columnsInward++;
                                }
                                else
                                {
                                    string objectToPlace = line.Split(',')[0];
                                    widthPosition = pixelFactor * columnsInward;
                                    heightPosition = pixelFactor * rowsDownward;
                                    mapObject(objectToPlace, heightPosition, widthPosition, itemFactory, enemyFactory, blockFactory, bgFactory);
                                    tempList.Add(objectToPlace + "," + widthPosition + "," + heightPosition);
                                    line = line.Remove(0, objectToPlace.Length);
                                }
                            }
                        }
                        rowsDownward++;
                    }
                 }
              }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            string temppath = "C:/Users/Dan/Desktop/TestGenerator2.txt"; 
            File.WriteAllText(temppath, "");

            for (int i = tempList.Count - 1; i >= 0; i--)
            {
                TextWriter tw = new StreamWriter(temppath, true);
                tw.WriteLine(tempList[i]);
                tw.Close();
            }
        }
        public static void SaveToFile(ArrayList textureStamps)
        {

            //format arrayList of stamps
            for (int i = textureStamps.Count - 1; i >= 0; i--)
            {
                Stamp temp = (Stamp)textureStamps[i];
                if (temp.isTemplate)
                {
                    textureStamps.RemoveAt(i);
                }
                else
                {
                    temp.X = PositionRounder.RoundNearestTwenty((int)temp.X);
                    temp.Y = PositionRounder.RoundNearestTwenty((int)temp.Y);
                    textureStamps[i] = temp;
                }
            }

            IComparer heightValues = new StampPositionSorter.SortHeightValues();
            IComparer widthValues = new StampPositionSorter.SortWidthValues();
            textureStamps.Sort(heightValues);       

            //Algorithm to sort all texture stamp widths in their respective height values
            int startRange = 0;
            Stamp firstStamp = (Stamp)textureStamps[0];
            int previousYStampValue = firstStamp.Y;
            for (int i = 0; i <= textureStamps.Count - 1; i++)
            {
                Stamp temp = (Stamp)textureStamps[i];
                if (temp.Y != previousYStampValue)
                {
                    textureStamps.Sort(startRange, i-1-startRange, widthValues);
                    startRange = i;
                    previousYStampValue = temp.Y;
                }
            }
            textureStamps.Sort(startRange, textureStamps.Count-1-startRange, widthValues);
            //---------------------------------------------------------------------------

            string path = "C:/Users/feene_001/Desktop/TestGenerator2.txt"; 
            if (!File.Exists(path))
            {
                FileStream temp = File.Create(path);
                temp.Close();
            }
            File.WriteAllText(path, "");
            foreach (Stamp stamp in textureStamps)
            {
                TextWriter tw = new StreamWriter(path, true);
                tw.WriteLine(stamp.tag + "," + stamp.X + "," + stamp.Y);
                tw.Close();
            }
        }
    }
}
