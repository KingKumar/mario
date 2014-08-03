using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide
{
    public class UILoader
    {
        public Texture2D banzaiCannon, bigBush, brickBlock, bush, castle, cloud, coin, darkBrickBlock, darkFloorBlock, drybones, fireFlower, flag, flagpole, floorBlock;
        public Texture2D goomba, greenMushroom, greenPipe, hill, koopa, lakitu, pyramidBlock, questionBlock, redMushroom, shine, smallBush, spiny, star, thwomp, background;
        public Texture2D mario;
        public Rectangle banzaiCannonRect, bigBushRect, brickBlockRect, bushRect, castleRect, cloudRect, coinRect, darkBrickBlockRect, darkFloorBlockRect, drybonesRect, fireFlowerRect, flagRect, flagpoleRect, floorBlockRect;
        public Rectangle goombaRect, greenMushroomRect, greenPipeRect, hillRect, koopaRect, lakituRect, pyramidBlockRect, questionBlockRect, redMushroomRect, shineRect, smallBushRect, spinyRect, starRect, thwompRect;
        public Game1 game;
        public LevelCreator level;
        public SpriteBatch spriteBatch;
        public SpriteFont font;
        public Rectangle saveLevelHitBox;
        private Boolean isBackground = true;

        public UILoader(Game1 game, LevelCreator level)
        {
            this.game = game;
            this.level = level;
            spriteBatch = level.spriteBatch;
            saveLevelHitBox = new Rectangle(10, 10, 40, 40);
            font = game.Content.Load<SpriteFont>("actions");
            this.background = game.Content.Load<Texture2D>("LevelCreatorSprites/Background");

            this.banzaiCannon = game.Content.Load<Texture2D>("LevelCreatorSprites/Banzai Cannon");
            this.banzaiCannonRect = new Rectangle((int)LevelLoaderConstants.banzaiCannonPosX, (int)LevelLoaderConstants.banzaiCannonPosY, banzaiCannon.Width, banzaiCannon.Height);
            level.textureStamps.Add(new Stamp("cannon", banzaiCannon, banzaiCannonRect, level));

            this.darkBrickBlock = game.Content.Load<Texture2D>("LevelCreatorSprites/DarkBrickBlockIdle");
            this.darkBrickBlockRect = new Rectangle((int)LevelLoaderConstants.darkBrickBlockPosX, (int)LevelLoaderConstants.darkBrickBlockPosY, darkBrickBlock.Width, darkBrickBlock.Height);
            level.textureStamps.Add(new Stamp("dbrick", darkBrickBlock, darkBrickBlockRect, level));

            this.darkFloorBlock = game.Content.Load<Texture2D>("LevelCreatorSprites/DarkFloorBlock");
            this.darkFloorBlockRect = new Rectangle((int)LevelLoaderConstants.darkFloorBlockPosX, (int)LevelLoaderConstants.darkFloorBlockPosY, darkFloorBlock.Width, darkFloorBlock.Height);
            level.textureStamps.Add(new Stamp("dfloor", darkFloorBlock, darkFloorBlockRect, level));

            this.brickBlock = game.Content.Load<Texture2D>("LevelCreatorSprites/BrickBlockIdle");
            this.brickBlockRect = new Rectangle((int)LevelLoaderConstants.brickBlockPosX, (int)LevelLoaderConstants.brickBlockPosY, brickBlock.Width, brickBlock.Height);
            level.textureStamps.Add(new Stamp("brick", brickBlock, brickBlockRect, level));

            this.floorBlock = game.Content.Load<Texture2D>("LevelCreatorSprites/FloorBlock");
            this.floorBlockRect = new Rectangle((int)LevelLoaderConstants.floorBlockPosX, (int)LevelLoaderConstants.floorBlockPosY, floorBlock.Width, floorBlock.Height);
            level.textureStamps.Add(new Stamp("floor", floorBlock, floorBlockRect, level));

            this.goomba = game.Content.Load<Texture2D>("LevelCreatorSprites/goomba_walk");
            this.goombaRect = new Rectangle((int)LevelLoaderConstants.goombaPosX, (int)LevelLoaderConstants.goombaPosY, goomba.Width, goomba.Height);
            level.textureStamps.Add(new Stamp("goomba", goomba, goombaRect, level));

            this.koopa = game.Content.Load<Texture2D>("LevelCreatorSprites/Koopa");
            this.koopaRect = new Rectangle((int)LevelLoaderConstants.koopaPosX, (int)LevelLoaderConstants.koopaPosY, koopa.Width, koopa.Height);
            level.textureStamps.Add(new Stamp("koopa", koopa, koopaRect, level));

            this.lakitu = game.Content.Load<Texture2D>("LevelCreatorSprites/lakitu_movement");
            this.lakituRect = new Rectangle((int)LevelLoaderConstants.lakituPosX, (int)LevelLoaderConstants.lakutuPosY, lakitu.Width, lakitu.Height);
            level.textureStamps.Add(new Stamp("lakitu", lakitu, lakituRect, level));

            this.pyramidBlock = game.Content.Load<Texture2D>("LevelCreatorSprites/pyramidBlock");
            this.pyramidBlockRect = new Rectangle((int)LevelLoaderConstants.pyramidBlockPosX, (int)LevelLoaderConstants.pyramidBlockPosY, pyramidBlock.Width, pyramidBlock.Height);
            level.textureStamps.Add(new Stamp("pyr", pyramidBlock, pyramidBlockRect, level));

            this.spiny = game.Content.Load<Texture2D>("LevelCreatorSprites/spiny_walking");
            this.spinyRect = new Rectangle((int)LevelLoaderConstants.spinyPosX, (int)LevelLoaderConstants.spinyPosY, spiny.Width, spiny.Height);
            level.textureStamps.Add(new Stamp("spiny", spiny, spinyRect, level));

            this.cloud = game.Content.Load<Texture2D>("LevelCreatorSprites/cloud");
            this.cloudRect = new Rectangle((int)LevelLoaderConstants.cloudPosX, (int)LevelLoaderConstants.cloudPosY, BackgroundConstants.cloudDestinationWidth, BackgroundConstants.cloudDestinationHeight);
            level.textureStamps.Add(new Stamp("cloud", cloud, cloudRect, level, isBackground));

            this.fireFlower = game.Content.Load<Texture2D>("LevelCreatorSprites/FireFlowerIdle");
            this.fireFlowerRect = new Rectangle((int)LevelLoaderConstants.fireFlowerPosX, (int)LevelLoaderConstants.fireFlowerPosY, fireFlower.Width, fireFlower.Height);
            level.textureStamps.Add(new Stamp("#", fireFlower, fireFlowerRect, level));

            this.coin = game.Content.Load<Texture2D>("LevelCreatorSprites/coinIdle");
            this.coinRect = new Rectangle((int)LevelLoaderConstants.coinIdlePosX, (int)LevelLoaderConstants.coinIdlePosY, coin.Width, coin.Height);
            level.textureStamps.Add(new Stamp("?", coin, coinRect, level));

            this.greenMushroom = game.Content.Load<Texture2D>("LevelCreatorSprites/GreenMushroomIdle");
            this.greenMushroomRect = new Rectangle((int)LevelLoaderConstants.greenMushroomPosX, (int)LevelLoaderConstants.greenMushroomPosY, greenMushroom.Width, greenMushroom.Height);
            level.textureStamps.Add(new Stamp("gbrick", greenMushroom, greenMushroomRect, level));

            this.redMushroom = game.Content.Load<Texture2D>("LevelCreatorSprites/RedMushroomIdle");
            this.redMushroomRect = new Rectangle((int)LevelLoaderConstants.redMushroomPosX, (int)LevelLoaderConstants.redMushroomPosY, redMushroom.Width, redMushroom.Height);
            level.textureStamps.Add(new Stamp("@", redMushroom, redMushroomRect, level));

            this.star = game.Content.Load<Texture2D>("LevelCreatorSprites/StarIdle");
            this.starRect = new Rectangle((int)LevelLoaderConstants.starPosX, (int)LevelLoaderConstants.starPosY, star.Width, star.Height);
            level.textureStamps.Add(new Stamp("$", star, starRect, level));

            this.hill = game.Content.Load<Texture2D>("LevelCreatorSprites/hill");
            this.hillRect = new Rectangle((int)LevelLoaderConstants.hillPosX, (int)LevelLoaderConstants.hillPosY, BackgroundConstants.hillDestinationWidth/3, BackgroundConstants.hillDestinationHeight/3);
            level.textureStamps.Add(new Stamp("hill", hill, hillRect, level, isBackground));

            this.shine = game.Content.Load<Texture2D>("LevelCreatorSprites/shine");
            this.shineRect = new Rectangle((int)LevelLoaderConstants.sunPosX, (int)LevelLoaderConstants.sunPosY, BackgroundConstants.shineDestinationWidth, BackgroundConstants.shineDestinationHeight);
            level.textureStamps.Add(new Stamp("shine", shine, shineRect, level, isBackground));

            this.castle = game.Content.Load<Texture2D>("LevelCreatorSprites/castle");
            this.castleRect = new Rectangle((int)LevelLoaderConstants.castlePosX, (int)LevelLoaderConstants.castlePosY, BackgroundConstants.castleDestinationWidth/2, BackgroundConstants.castleDestinationHeight/2);
            level.textureStamps.Add(new Stamp("castle", castle, castleRect, level, isBackground));

            this.flagpole = game.Content.Load<Texture2D>("LevelCreatorSprites/flagpole");
            this.flagpoleRect = new Rectangle((int)LevelLoaderConstants.flagPolePosX, (int)LevelLoaderConstants.flagPolePosY, flagpole.Width, flagpole.Height/2);
            level.textureStamps.Add(new Stamp("pole", flagpole, flagpoleRect, level, isBackground));

            this.greenPipe = game.Content.Load<Texture2D>("LevelCreatorSprites/greenPipe");
            this.greenPipeRect = new Rectangle((int)LevelLoaderConstants.greenPipePosX, (int)LevelLoaderConstants.greenPipePosY, greenPipe.Width, greenPipe.Height);
            level.textureStamps.Add(new Stamp("pipe", greenPipe, greenPipeRect, level));
         
            this.mario = game.Content.Load<Texture2D>("LevelCreatorSprites/Mario");
            
            
        }
        public void Draw()
        {
            spriteBatch.Begin();
            spriteBatch.Draw(mario, new Rectangle(MarioConstants.xPos - level.camera.xPos, MarioConstants.yPos - level.camera.yPos, mario.Width, mario.Height), Color.White);
            spriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), Color.White);
            spriteBatch.DrawString(font, "Save Level!", new Vector2(10, 10), Color.White);
            spriteBatch.End();
        }
    }
}
