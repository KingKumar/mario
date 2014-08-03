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
    public class CollisionManager
    {
        Level level;
        Mario mario;
        IList blocks;
        IList enemies;
        IList enemyProjectiles;
        IList consumableItems;
        IList marioProjectiles;
        MarioEnemyCollisionManager marioEnemyCollision;
        MarioEnemyCollisionManager marioEnemyProjectileCollision;
        MarioItemCollisionManager marioItemCollision;
        EnemyMarioProjectileCollisionManager enemyMarioProjectileCollision;
        EnemyEnemyCollisionManager enemyEnemyCollision;
        EnemyEnemyCollisionManager enemyEnemyProjectileCollision;
        EnemyItemCollisionManager enemyItemCollision;
        EnemyMarioProjectileCollisionManager enemyProjectileMarioProjectileCollision;
        ItemItemCollisionManager itemItemCollision;
        BlockMarioCollisionManager blockMarioCollision;
        BlockEnemyCollisionManager blockEnemyCollision;
        BlockEnemyCollisionManager blockEnemyProjectileCollision;
        BlockItemCollisionManager blockItemCollision;
        BlockMarioProjectilesCollisionManager blockMarioProjectileCollision;

        public CollisionManager(Level level, IList enemies, IList enemyProjectiles, IList consumableItems, IList blocks, Mario mario, IList marioProjectiles)
        {
            this.level = level;
            this.enemies = enemies;
            this.blocks = blocks;
            this.consumableItems = consumableItems;
            this.mario = mario;
            this.enemyProjectiles = enemyProjectiles;
            this.marioProjectiles = marioProjectiles;
            marioEnemyCollision = new MarioEnemyCollisionManager(enemies, mario, level);
            marioItemCollision = new MarioItemCollisionManager(consumableItems, mario, level);
            marioEnemyProjectileCollision = new MarioEnemyCollisionManager(enemyProjectiles, mario, level);
            enemyMarioProjectileCollision = new EnemyMarioProjectileCollisionManager(enemies, level);
            enemyEnemyCollision = new EnemyEnemyCollisionManager(enemies, level);
            enemyEnemyProjectileCollision = new EnemyEnemyCollisionManager(enemyProjectiles, level);
            enemyItemCollision = new EnemyItemCollisionManager(consumableItems, level);
            enemyProjectileMarioProjectileCollision = new EnemyMarioProjectileCollisionManager(enemyProjectiles, level);
            itemItemCollision = new ItemItemCollisionManager(consumableItems, level);
            blockMarioCollision = new BlockMarioCollisionManager(mario, level);
            blockEnemyCollision = new BlockEnemyCollisionManager(enemies, level);
            blockEnemyProjectileCollision = new BlockEnemyCollisionManager(enemyProjectiles, level);
            blockItemCollision = new BlockItemCollisionManager(consumableItems, level);
            blockMarioProjectileCollision = new BlockMarioProjectilesCollisionManager(marioProjectiles, level);
        }
        public void Update()
        {
            CheckBlockCollisions();
            CheckEnemyCollisions();
            if (!(mario.marioState is DeadMarioState)) { CheckMarioCollisions(); }
            CheckProjectileCollisions();
            //TODO -- add methods for checking any additional collisions
        }        
        private void CheckBlockCollisions()
        {
            foreach (IBlockObstacle block in blocks)
            {
                blockMarioCollision.Update(block);
                blockEnemyCollision.Update(block);
                blockEnemyProjectileCollision.Update(block);
                blockItemCollision.Update(block);
                blockMarioProjectileCollision.Update(block);
            }
        }
        private void CheckMarioCollisions()
        {
            marioEnemyCollision.Update();
            marioEnemyProjectileCollision.Update();
            marioItemCollision.Update();
        }
        private void CheckEnemyCollisions()
        {
            foreach (IEnemy enemy in enemies)
            {
                if (enemy.IsDead == false)
                {
                    enemyEnemyCollision.Update(enemy);
                    enemyEnemyProjectileCollision.Update(enemy);
                    enemyItemCollision.Update(enemy);
                }
            }
        }
        private void CheckProjectileCollisions()
        {
            foreach (IProjectile projectile in marioProjectiles)
            {
                enemyMarioProjectileCollision.Update(projectile);
                enemyProjectileMarioProjectileCollision.Update(projectile);
            }
        }
        private void CheckItemCollisions()
        {
            foreach (IConsumableItem item in consumableItems)
            {
                itemItemCollision.Update(item);
            }
        }
    }
}