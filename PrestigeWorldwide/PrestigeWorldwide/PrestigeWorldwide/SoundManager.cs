using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide
{
    public class SoundManager
    {
        SoundEffect mainMusic;
        SoundEffectInstance mainMusicInstance;

        SoundEffect breakBlock;
        SoundEffect collectCoin;
        SoundEffect hitFlagpole;
        SoundEffect marioJump;

        SoundEffect kick0;
        SoundEffect kick1;
        SoundEffect kick2;
        SoundEffect kick3;
        SoundEffect kick4;
        SoundEffect kick5;
        SoundEffect kick6;
        SoundEffect kick7;
        int kickSwitch;
        public int kickTimer;

        SoundEffect menuSelect;
        SoundEffect gameOver;
        SoundEffectInstance gameOverInstance;
        SoundEffect marioDeath;
        SoundEffect stageClear;
        SoundEffect warpPipe;
        SoundEffect startMenu;
        SoundEffectInstance startMenuInstance;

        SoundEffect underGround;
        SoundEffectInstance underGroundInstance;

        SoundEffect oneUp;
        SoundEffect powerUp;
        SoundEffect powerDown;

        SoundEffect powerUpSpawn;
        SoundEffect fireBall;
        SoundEffect pause;
        SoundEffect enemyHit;

        SoundEffect levelCreator;
        SoundEffectInstance levelCreatorInstance;


        public SoundManager(Game1 game)
        {
            mainMusic = game.Content.Load<SoundEffect>("Sounds/MainTheme2");
            mainMusicInstance = mainMusic.CreateInstance();
            mainMusicInstance.IsLooped = true;

            breakBlock = game.Content.Load<SoundEffect>("Sounds/BreakBlock");
            collectCoin = game.Content.Load<SoundEffect>("Sounds/CollectCoin2");
            hitFlagpole = game.Content.Load<SoundEffect>("Sounds/HitFlagPole");
            marioJump = game.Content.Load<SoundEffect>("Sounds/MarioJump");

            gameOver = game.Content.Load<SoundEffect>("Sounds/GameOver2");
            gameOverInstance = gameOver.CreateInstance();
            gameOverInstance.IsLooped = false;

            marioDeath = game.Content.Load<SoundEffect>("Sounds/MarioDeath2");
            stageClear = game.Content.Load<SoundEffect>("Sounds/StageClear2");
            warpPipe = game.Content.Load<SoundEffect>("Sounds/WarpPipe");

            startMenu = game.Content.Load<SoundEffect>("Sounds/Menu");
            startMenuInstance = startMenu.CreateInstance();
            startMenuInstance.IsLooped = true;

            underGround = game.Content.Load<SoundEffect>("Sounds/UnderGround");
            underGroundInstance = underGround.CreateInstance();
            underGroundInstance.IsLooped = true;

            levelCreator = game.Content.Load<SoundEffect>("Sounds/LevelCreator");
            levelCreatorInstance = levelCreator.CreateInstance();
            levelCreatorInstance.IsLooped = true;

            oneUp = game.Content.Load<SoundEffect>("Sounds/OneUp");
            powerUp = game.Content.Load<SoundEffect>("Sounds/PowerUp");
            powerDown = game.Content.Load<SoundEffect>("Sounds/PowerDown");

            powerUpSpawn = game.Content.Load<SoundEffect>("Sounds/PowerUpAppears");
            fireBall = game.Content.Load<SoundEffect>("Sounds/Fireball");
            pause = game.Content.Load<SoundEffect>("Sounds/Pause");
            enemyHit = game.Content.Load<SoundEffect>("Sounds/Hit");

            kick0 = game.Content.Load<SoundEffect>("Sounds/kick0");
            kick1 = game.Content.Load<SoundEffect>("Sounds/kick1");
            kick2 = game.Content.Load<SoundEffect>("Sounds/kick2");
            kick3 = game.Content.Load<SoundEffect>("Sounds/kick3");
            kick4 = game.Content.Load<SoundEffect>("Sounds/kick4");
            kick5 = game.Content.Load<SoundEffect>("Sounds/kick5");
            kick6 = game.Content.Load<SoundEffect>("Sounds/kick6");
            kick7 = game.Content.Load<SoundEffect>("Sounds/kick7");

            menuSelect = game.Content.Load<SoundEffect>("Sounds/MenuSelect");

        }

        public void PlayMain()
        {
            startMenuInstance.Stop();
            underGroundInstance.Stop();
            levelCreatorInstance.Stop();
            if (mainMusicInstance.State == SoundState.Playing) 
            {
                mainMusicInstance.Resume();
            }
            else
                mainMusicInstance.Play();

        }

        public void HaltMain(bool shouldPause)
        {
            if (shouldPause)
                mainMusicInstance.Pause();
            else
                mainMusicInstance.Stop();
        }

        public void LevelCreator()
        {
            if (levelCreatorInstance.State == SoundState.Playing)
                levelCreatorInstance.Resume();
            else
                levelCreatorInstance.Play();
        }

        public void BreakBlock()
        {
            breakBlock.Play();
        }

        public void CollectCoin()
        {
            collectCoin.Play();
        }

        public void HitFlagpole()
        {
            hitFlagpole.Play();
        }

        public void MarioJump()
        {
            marioJump.Play();
        }

        public void GameOver()
        {
            HaltMain(shouldPause: false);
            if (gameOverInstance.State == SoundState.Playing)
                gameOverInstance.Resume();
            else
            gameOverInstance.Play();
        }

        public void MarioDeath()
        {
            HaltMain(shouldPause: false);
            marioDeath.Play();
        }

        public void StageClear()
        {
            HaltMain(shouldPause: false);
            stageClear.Play();
        }

        public void WarpPipe()
        {
            HaltMain(shouldPause: true);
            warpPipe.Play();
        }

        public void StartMenu()
        {
            HaltMain(shouldPause: false);
            gameOverInstance.Stop();
            if (startMenuInstance.State == SoundState.Playing)
            {
                startMenuInstance.Resume();
            }
            else
            startMenuInstance.Play();
        }

        public void FadeOut()
        {
            startMenuInstance.Volume = MathHelper.Clamp(startMenuInstance.Volume - .01f, 0.0f, 1.0f);
            mainMusicInstance.Volume = MathHelper.Clamp(mainMusicInstance.Volume - .01f, 0.0f, 1.0f);
        }

        public void FadeIn()
        {
            startMenuInstance.Volume = MathHelper.Clamp(startMenuInstance.Volume + .1f, 0.0f, 1.0f);
            mainMusicInstance.Volume = MathHelper.Clamp(mainMusicInstance.Volume + .1f, 0.0f, 1.0f);
        }

        public void MenuSelect()
        {
            menuSelect.Play();
        }

        public void UnderGround()
        {
            HaltMain(shouldPause: true);
            if (underGroundInstance.State == SoundState.Playing)
            {
                underGroundInstance.Resume();
            }
            else
                underGroundInstance.Play();
        }

        public void OneUp()
        {
            oneUp.Play();
        }

        public void PowerUp()
        {
            powerUp.Play();
        }

        public void PowerDown()
        {
            powerDown.Play();
        }

        public void PowerUpSpawn()
        {
            powerUpSpawn.Play();
        }

        public void FireBall()
        {
            fireBall.Play();
        }

        public void EnemyHit()
        {
            enemyHit.Play();
        }

        public void Pause()
        {
            if (mainMusicInstance.State == SoundState.Playing)
                mainMusicInstance.Pause();
            else
                mainMusicInstance.Resume();
            pause.Play();
        }

        public void Kick()
        {
            if (kickTimer > 0)
                kickSwitch++;
            else
                kickSwitch = 0;
            if (kickSwitch >= 7) { kickSwitch = 7; }
            kickTimer = 200;

            switch (kickSwitch)
            {
                case 0:
                    kick0.Play();
                    break;

                case 1:
                    kick1.Play();
                    break;

                case 2:
                    kick2.Play();
                    break;

                case 3:
                    kick3.Play();
                    break;

                case 4:
                    kick4.Play();
                    break;

                case 5:
                    kick5.Play();
                    break;

                case 6:
                    kick6.Play();
                    break;

                case 7:
                    kick7.Play();
                    break;

            }
        }

    }
}
