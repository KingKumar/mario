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

    public class MarioEnemyCollisionManager
    {
        IList enemies;
        Mario mario;
        Level level;

        public MarioEnemyCollisionManager(IList enemies, Mario mario, Level level)
        {
            this.enemies = enemies;
            this.level = level;
            this.mario = mario;
        }

        public void Update()
        {
            foreach (IEnemy enemy in enemies)
            {
                if (enemy.IsDead == false)
                {
                    Rectangle objectB = enemy.Collider;
                    Rectangle objectA = mario.Collider();
                    Rectangle overlap = Rectangle.Intersect(objectA, objectB);

                    if (overlap.Width > overlap.Height)
                    {
                        if (objectA.Location.Y > objectB.Location.Y)
                        {
                            if (mario.ySpeed > 0) { enemy.Bump(0, -overlap.Height); }
                            if (enemy.Lethal) { mario.marioCollisionHandler.TakeDamage(); }
                            if (mario.starPower > 0)
                            {
                                enemy.TakeDamage();
                                level.gameStatus.score += MarioConstants.marioKillScore;
                            }
                        }
                        if (objectA.Location.Y < objectB.Location.Y)
                        {
                            if (mario.ySpeed < 0) { enemy.Bump(0, overlap.Height); }
                            enemy.TakeDamage();
                            mario.marioCollisionHandler.MarioKillEnemy();
                            level.gameStatus.score += MarioConstants.marioKillScore;
                        }

                    }
                    if (overlap.Width < overlap.Height)
                    {
                        if (objectA.Location.X > objectB.Location.X)
                        {
                            if (mario.xSpeed > 0) { enemy.Bump(-overlap.Width, 0); }
                            if (enemy.Lethal) { mario.marioCollisionHandler.TakeDamage(); }
                            if (mario.starPower > 0)
                            {
                                enemy.TakeDamage();
                                level.gameStatus.score += MarioConstants.marioKillScore;
                            }
                        }
                        if (objectA.Location.X < objectB.Location.X)
                        {
                            if (mario.xSpeed < 0) { enemy.Bump(overlap.Width, 0); }
                            if (enemy.Lethal) { mario.marioCollisionHandler.TakeDamage(); }
                            if (mario.starPower > 0)
                            {
                                enemy.TakeDamage();
                                level.gameStatus.score += MarioConstants.marioKillScore;
                            }
                        }
                    }
                }
            }
        }
    }
}