using System;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PrestigeWorldwide.Sprites.Blocks;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class BlockFactory
    {
        Texture2D IdleQuestionBlock;
        Texture2D BumpedQuestionBlock;
        Texture2D IdleBrickBlock;
        Texture2D IdleDarkBrickBlock;
        Texture2D BumpedDarkBrickBlock;
        Texture2D IdleCastleBrickBlock;
        Texture2D IdleBlocklet;
        Texture2D IdleCastleBlocklet;
        Texture2D IdleUsedBlock;
        Texture2D FloorBlock;
        Texture2D CastleFloorBlock;
        Texture2D PyramidBlock;
        Texture2D DarkFloorBlock;
        Texture2D GreenPipeTexture;
        Texture2D IdleLavaBlock;
        Texture2D FlagpoleTexture;
        Texture2D SecretExit;
        Texture2D CastlePortalOne;
        Texture2D CastlePipeTexture;
        Texture2D CastleBridge;
        Texture2D CastleLever;
        Level level;
        Vector2 location;

	    public BlockFactory(Level level)
	    {
            this.level = level;
            this.IdleQuestionBlock = level.ContentLoad("Blocks/QuestionBlockIdle");
            this.BumpedQuestionBlock = level.ContentLoad("Blocks/QuestionBlockBumped");
            this.IdleBrickBlock = level.ContentLoad("Blocks/BrickBlockIdle");
            this.IdleCastleBrickBlock = level.ContentLoad("Blocks/CastleBrickBlockIdle");
            this.IdleUsedBlock = level.ContentLoad("Blocks/UsedBlockIdle");
            this.GreenPipeTexture = level.ContentLoad("Blocks/GreenPipe");
            this.CastlePipeTexture = level.ContentLoad("Blocks/CastlePipe");
            this.IdleDarkBrickBlock = level.ContentLoad("Blocks/DarkBrickBlockIdle");
            this.BumpedDarkBrickBlock = level.ContentLoad("Blocks/DarkBrickBlockBumped");
            this.FloorBlock = level.ContentLoad("Blocks/FloorBlock");
            this.CastleFloorBlock = level.ContentLoad("Blocks/CastleFloorBlock");
            this.DarkFloorBlock = level.ContentLoad("Blocks/DarkFloorBlock");
            this.IdleBlocklet = level.ContentLoad("Blocks/Blocklet");
            this.IdleCastleBlocklet = level.ContentLoad("Blocks/CastleBlocklet");
            this.PyramidBlock = level.ContentLoad("Blocks/PyramidBlock");
            this.IdleLavaBlock = level.ContentLoad("Blocks/Lava");
            this.FlagpoleTexture = level.ContentLoad("Backgrounds/flagpole");
            this.SecretExit = level.ContentLoad("Blocks/DarkRoomExit");
            this.CastlePortalOne = level.ContentLoad("Blocks/CastlePortalOne");
            this.CastleBridge = level.ContentLoad("Blocks/CastleBridge");
            this.CastleLever = level.ContentLoad("Blocks/CastleLever");
	    }

        public void CreateQuestionBlock(int xpos, int ypos, string blockContent)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new QuestionBlock(IdleQuestionBlock, BumpedQuestionBlock, location, level, blockContent));
        }

        public void CreateBrickBlock(int xpos, int ypos, string blockContent)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new BrickBlock(IdleBrickBlock, location, level, blockContent));
        }

        public void CreateBlocklets(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            for (int i = 0; i < ObstacleConstants.numOfBlocklets; i++)
            {
                level.blockletList.Add(new BrickBlocklet(IdleBlocklet, location, level, i));
            }    
        }

        public void CreateCastleBlocklets(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            for (int i = 0; i < ObstacleConstants.castlenumOfBlocklets; i++)
            {
                level.blockletList.Add(new CastleBrickBlocklet(IdleCastleBlocklet, location, level, i));
            }
        }

        public void CreateCastleBrickBlock(int xpos, int ypos, string blockContent)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new CastleBrickBlock(IdleCastleBrickBlock, location, level, blockContent));
        }

        public void CreateDarkBrickBlock(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new DarkBrickBlock(IdleDarkBrickBlock, BumpedDarkBrickBlock, location, level));
        }

        public void CreateUsedBlock(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new UsedBlock(IdleUsedBlock, location, level));
        }

        public void CreateFloorBlock(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new FloorBlock(FloorBlock, location, level));
        }

        public void CreateCastleFloorBlock(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new CastleFloorBlock(CastleFloorBlock, location, level));
        }

        public void CreateCastleBridge(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new CastleBridge(CastleBridge, location, level));
        }

        public void CreateCastleLever(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new CastleLever(CastleLever, location, level));
        }

        public void CreatePyramidBlock(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new PyramidBlock(PyramidBlock, location, level));
        }

        public void CreateDarkFloorBlock(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new DarkFloorBlock(DarkFloorBlock, location, level));
        }

        public void CreateLavaBlock(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new LavaBlock(IdleLavaBlock, location, level));
        }

        public void CreateGreenPipe(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new GreenPipe(GreenPipeTexture, location, level));
        }

        public void CreateCastlePipe(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new CastlePipe(CastlePipeTexture, location, level));
        }

        public void CreateCastlePortal(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new CastlePortalOne(CastlePortalOne, location, level));
        }

        public void CreateSecretEntrance(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new SecretEntrance(GreenPipeTexture, location, level));
        }

        public void CreateSecretExit(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new SecretExit(GreenPipeTexture, location, level));
        }

        public void CreateFlagpole(int xpos, int ypos)
        {
            this.location.X = xpos;
            this.location.Y = ypos;
            level.blockList.Add(new Flagpole(FlagpoleTexture, location, level));
        }
    }
}