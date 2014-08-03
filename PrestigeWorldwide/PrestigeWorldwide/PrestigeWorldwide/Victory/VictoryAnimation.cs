using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    public class VictoryAnimation
    {
        int count = 0;
        public Boolean isPlaying = false;
        public Vector2 flagpoleLocation;
        public Level level;
        public Transition fadeOut;
        public VictoryAnimation(Level level)
        {
            this.level = level;
            fadeOut = level.fadeOut;
        }
        public void Update()
        {
            level.mario.Update();
            if (count == 0) { level.mario.location.X += 25; }
            if (count < 100)
            {
                level.mario.xSpeed = 0;
                count++;
                level.mario.marioState.MarioIdle();
            }
            else if (count > 99 && count < 300)
            {
                if (count == 100)
                {
                    level.mario.isMovingRight = 1;
                    level.mario.marioState.MarioRunRight();
                }
                count++;
                level.mario.xSpeed = 1;
            }
            else if (count > 299 && count < 700)
            {
                if (count == 540)
                {
                    fadeOut.FadeOut();
                    level.startMenu.menuTransitionCount = 95;
                }
                level.mario.marioState.MarioIdle();
                count++;
            }
            else
            {
                level.startMenu.firstLaunch = true;
                level.startMenu.isDisplaying = true;
                isPlaying = false;
            }
        }
        public void Play(Vector2 flagpoleLocation)
        {
            isPlaying = true;
            this.flagpoleLocation = flagpoleLocation;
        }
    }
}
