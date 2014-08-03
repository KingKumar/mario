using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Commands;

namespace PrestigeWorldwide
{
    public class KeyboardController : IController
    {

        private int p_down = 0;

        // Fields
        private Dictionary<Keys, ICommand> keyMapping = new Dictionary<Keys, ICommand>();
        private Level level;
        private ICommand command;
        private ArrayList pastState;
        private ArrayList currentState;
        private int shouldNotUseKeyboard = 0;

        public ArrayList PastState
        {
            get
            {
                return pastState;
            }
        }

        public ArrayList CurrentState
        {
            get
            {
                return currentState;
            }
        }

        public KeyboardController(Level level, Enemy_Factory eFactory, Background_Factory bgFactory)
        {
            this.level = level;
            pastState = new ArrayList();
            currentState = new ArrayList();
            keyMapping.Add(Keys.Q, new QuitCommand(this.level));
            keyMapping.Add(Keys.W, new MarioJumpCommand(this.level.mario));
            keyMapping.Add(Keys.A, new MarioRunLeftCommand(this.level.mario));
            keyMapping.Add(Keys.S, new MarioCrouchCommand(this.level.mario));
            keyMapping.Add(Keys.D, new MarioRunRightCommand(this.level.mario));
            keyMapping.Add(Keys.Space, new MarioShootCommand(this.level.mario));
            keyMapping.Add(Keys.Y, new MarioSmallStateCommand(this.level.mario, this.level));
            keyMapping.Add(Keys.B, new MarioBigStateCommand(this.level.mario, this.level));
            keyMapping.Add(Keys.F, new MarioFireStateCommand(this.level.mario, this.level));
            keyMapping.Add(Keys.O, new MarioDeadStateCommand(this.level.mario, this.level));
            keyMapping.Add(Keys.I, new MarioIceStateCommand(this.level.mario, this.level));
        }

        public void Update()
        {

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.P) && p_down == 0)
            {
                p_down = 1;
                level.pauseMenu.isDisplaying = true;
            }
            if (keyState.IsKeyUp(Keys.P))
                p_down = 0;

            foreach (Keys key in keyMapping.Keys)
            {
                if (keyState.IsKeyDown(key) && keyMapping.TryGetValue(key, out command) &&
                    !currentState.Contains(command))
                {
                    currentState.Add(command);
                }
            }

            if (currentState.Count == 0) { level.mario.marioState.MarioIdle(); }
            if (keyState.IsKeyUp(Keys.S) && level.mario.isCrouching == true) { level.mario.marioState.MarioIdle(); }
            if (keyState.IsKeyUp(Keys.W) && level.mario.isJumping == true && level.mario.isBounce == false)
            {
                level.mario.isJumping = false;
                level.mario.canJump = false;
            }
            if (keyState.IsKeyUp(Keys.Space) && !level.mario.canShoot)
            {
                level.mario.canShoot = true;
            }
            foreach (ICommand command in currentState)
            {
                if (!pastState.Contains(command)) { command.Execute(); }
                else { command.Execute(); }
            }

            // Make sure that Mario's update function gets CurrentState before it is cleared
            level.mario.Update();

            pastState.Clear();
            foreach (ICommand command in currentState)
            {
                pastState.Add(command);
            }
            currentState.Clear();
        }
    }
}
