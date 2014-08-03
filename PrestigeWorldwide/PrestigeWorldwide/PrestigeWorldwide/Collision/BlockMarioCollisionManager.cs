using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using PrestigeWorldwide.Interfaces;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class BlockMarioCollisionManager
    {
        Level level;
        Mario mario;

        public BlockMarioCollisionManager(Mario mario,Level level)
        {
            this.level = level;
            this.mario = mario;
        }

        public void Update(IBlockObstacle block)
        {
            Rectangle objectA = block.Collider;
            Rectangle objectB = mario.Collider();
            Rectangle overlap = Rectangle.Intersect(objectA, objectB);
                if (overlap.Width > overlap.Height)
                {
                    if (block is LavaBlock) { mario.marioState = new DeadMarioState(mario, level); }
                    if (objectA.Location.Y > objectB.Location.Y)
                    {
                        if (block is Flagpole) { block.Bump(); }
                        mario.Bump(0,-overlap.Height);
                        if (mario.isCrouching)
                        {
                            block.SecretLevel();
                        }
                    }
                    if (objectA.Location.Y < objectB.Location.Y)
                    {
                        mario.Bump(0,overlap.Height);
                        block.Bump();
                        mario.ySpeed = mario.gravity;
                        mario.canJump = false;
                    }
                }
                if (overlap.Width < overlap.Height)
                {
                    if (block is LavaBlock) { mario.marioState = new DeadMarioState(mario, level); }
                    if (objectA.Location.X > objectB.Location.X)
                    {
                        if (block is Flagpole) { 
                            block.Bump();
                            level.gameStatus.score += (MarioConstants.mushroomScore - objectA.Y);
                        }
                        mario.Bump(-overlap.Width,0);

                    }
                    if (objectA.Location.X < objectB.Location.X)
                    {
                        if (block is Flagpole) { 
                            block.Bump();
                            level.gameStatus.score += (MarioConstants.mushroomScore - objectA.Y);
                        }                        
                        mario.Bump(overlap.Width,0);
                    }
                }
        }

    }
}