using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.Reflection;

namespace PrestigeWorldwide
{
    public static class LevelLoader2
    {
        public static void LoadFile(string path, ConsItemFactory itemFactory, Enemy_Factory enemyFactory, BlockFactory blockFactory, Background_Factory bgFactory, Level level)
        {
            using (StreamReader readFile = new StreamReader(path))
            {
                string line;
                while ((line = readFile.ReadLine()) != null)
                {
                    string obj = line.Split(',')[0];
                    if (level.camera.customXLock > Int32.Parse(line.Split(',')[1])) { level.camera.customXLock = Int32.Parse(line.Split(',')[1]); }
                    if (level.camera.customYLock > Int32.Parse(line.Split(',')[2])) { level.camera.customYLock = Int32.Parse(line.Split(',')[2]); }

                   switch (obj)
            {
                case "shine":
                    bgFactory.Create_Shine(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), 0);
                    break;
                case "cloud":
                    bgFactory.Create_Cloud(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), 0);
                    break;
                case "hill":
                    bgFactory.Create_Hill(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), 0);
                    break;
                case "bigbush":
                    bgFactory.Create_BigBush(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), 0);
                    break;
                case "smallbush":
                    bgFactory.Create_LittleBush(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), 0);
                    break;
                case "darkbg":
                    bgFactory.Create_DarkRoom(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), 0);
                    break;
                case "pole":
                    blockFactory.CreateFlagpole(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "flag":
                    bgFactory.Create_Flag(Int32.Parse(line.Split(',')[1]) + 10, Int32.Parse(line.Split(',')[2]), 0);
                    break;
                case "castle":
                    bgFactory.Create_Castle(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), 0);
                    break;
                case "brick":
                    blockFactory.CreateBrickBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), "none");
                    break;
                case "lakitu":
                    enemyFactory.Create_Lakitu(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "spiny":
                    enemyFactory.Create_Spiny(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]),0);
                    break;
                case "pyr":
                    blockFactory.CreatePyramidBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "cbrick":
                    blockFactory.CreateBrickBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), "coin");
                    break;
                case "gbrick":
                    blockFactory.CreateBrickBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), "greenMushroom");
                    break;
                case "dbrick":
                    blockFactory.CreateDarkBrickBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "?":
                    blockFactory.CreateQuestionBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), "coin");
                    break;
                case "@":
                    blockFactory.CreateQuestionBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), "redMushroom");
                    break;
                case "#":
                    blockFactory.CreateQuestionBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), "fireFlower");
                    break;
                case "!":
                    blockFactory.CreateQuestionBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), "greenMushroom");
                    break;
                case "$":
                    blockFactory.CreateQuestionBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), "star");
                    break;
                case "pipe":
                    blockFactory.CreateGreenPipe(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "dpipe":
                    blockFactory.CreateGreenPipe(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "castlepipe":
                    blockFactory.CreateCastlePipe(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "portal":
                    blockFactory.CreateCastlePortal(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "enter":
                    blockFactory.CreateSecretEntrance(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "exit":
                    blockFactory.CreateSecretExit(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "used":
                    blockFactory.CreateUsedBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "floor":
                    blockFactory.CreateFloorBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "dfloor":
                    blockFactory.CreateDarkFloorBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "lava":
                    blockFactory.CreateLavaBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "cfb":
                    blockFactory.CreateCastleFloorBlock(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "goomba":
                    enemyFactory.Create_Goomba(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "koopa":
                    enemyFactory.Create_Koopa(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "gshroom":
                    itemFactory.CreateGreenMushroom(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "rshroom":
                    itemFactory.CreateRedMushroom(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "coin":
                    itemFactory.CreateCoin(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]), false);
                    break;
                case "star":
                    itemFactory.CreateStar(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "fire":
                    itemFactory.CreateFireFlower(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "bridge":
                    blockFactory.CreateCastleBridge(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                case "lever":
                    blockFactory.CreateCastleLever(Int32.Parse(line.Split(',')[1]), Int32.Parse(line.Split(',')[2]));
                    break;
                default:
                    Console.WriteLine("Incorrect object name.");
                    break;
            }  
        }
                }
            }
        public static void SaveFile(ArrayList objects)
        {
            string path = LevelLoaderConstants.path;
            if (!File.Exists(path))
            {
                FileStream temp = File.Create(path);
                temp.Close();
            }
            File.WriteAllText(path, "");
            foreach (Stamp stamp in objects)
            {
                if (!stamp.isTemplate)
                {
                    TextWriter tw = new StreamWriter(path, true);
                    tw.WriteLine(stamp.tag + "," + stamp.X + "," + stamp.Y);
                    tw.Close();
                }
            }
        }
        }
    }
