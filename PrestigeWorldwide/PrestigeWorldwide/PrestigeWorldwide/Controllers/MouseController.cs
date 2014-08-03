using System;
using System.Collections;
using Microsoft.Xna.Framework.Input;

namespace PrestigeWorldwide
{
    class MouseController : IController
    {
        // Fields
        private MouseState mouseState;
        private Level level;
        private ICommand command;
        private ArrayList pastState;
        private ArrayList currentState; 
        private int shouldNotUseMouse = 1;

        // Constructor
        public MouseController(Level level)
        {
            this.level = level;
            pastState = new ArrayList();
            currentState = new ArrayList();
            Mouse.SetPosition(CenterX, CenterY);
        }

        // Border properties
        public int LeftX { get { return (int)level.mario.location.X - GetTextureHeight(); } }
        public int CenterX { get { return (int)((level.mario.location.X + GetTextureWidth()) / 2.0); } }
        public int RightX { get { return (int)level.mario.location.X + GetTextureWidth() + GetTextureHeight(); } }

        public int TopY { get { return (int)level.mario.location.Y - 2 * GetTextureHeight(); } }
        public int CenterY { get { return (int)((level.mario.location.Y + GetTextureHeight()) / 2.0); } }
        public int BottomY { get { return (int)level.mario.location.Y + 3 * GetTextureHeight(); } }

        // Contain logic for determining texture width
        private int GetTextureWidth()
        {
            if (level.mario.marioState is SmallMarioState) { return 21; }
            else if (level.mario.marioState is BigMarioState) { return 31; }
            else if (level.mario.marioState is FireMarioState) { return 23; }
            else if (level.mario.marioState is IceMarioState) { return 26; }
            else
            {
                // Mario is in dead state
                return 22;
            }
        }

        // Contain logic for determining texture height
        private int GetTextureHeight()
        {
            if (level.mario.marioState is SmallMarioState) { return 31; }
            else if (level.mario.marioState is BigMarioState) { return 46; }
            else if (level.mario.marioState is FireMarioState) { return 37; }
            else if (level.mario.marioState is IceMarioState) { return 33; }
            else
            {
                // Mario is in dead state
                return 18;
            }
        }

        // Past/current state properties
        public ArrayList PastState { get { return pastState; } }
        public ArrayList CurrentState { get { return currentState; } }

        public void Update()
        {
            // If > 0 at the end of update, do not use mouse input
            shouldNotUseMouse = 1;

            // Only allow mouse to control if another controller is not being used
            foreach (IController controller in level.controllerList)
            {
                if (controller is KeyboardController || controller is GamepadController)
                {
                    if (controller.CurrentState.Count > 0 || controller.PastState.Count > 0) { shouldNotUseMouse++; }
                }
            }

            if (shouldNotUseMouse == 0)
            {
                mouseState = Mouse.GetState();
                if (mouseState.X < CenterX)
                {
                    // Mario should be facing left
                    level.mario.isMovingRight = 0;
                }
                else
                {
                    // Mario should be facing right
                    level.mario.isMovingRight = 1;
                }

                // Check for Mario movement
                if (mouseState.X > RightX)
                {
                    // Mario is running right
                    //game.mario.isIdle = false;
                    command = new MarioRunRightCommand(level.mario);
                    currentState.Add(command);
                    //command.Execute();
                }
                else if (level.mario.isMovingRight == 1)
                {
                    // Mario is idle facing right
                    //game.mario.isIdle = true;
                    level.mario.marioState.MarioIdle();
                }
                else if (mouseState.X < LeftX)
                {
                    // Mario is running left
                   // game.mario.isIdle = false;
                    command = new MarioRunLeftCommand(level.mario);
                    currentState.Add(command);
                    //command.Execute();
                }
                else
                {
                    // Mario is idle facing left
                    //game.mario.isIdle = true;
                    level.mario.marioState.MarioIdle();
                }

                // Check for Mario jumping/crouching
                if (mouseState.Y < TopY)
                {
                    // Mario should be jumping
                    command = new MarioJumpCommand(level.mario);
                    //game.mario.isJumping = true;
                    level.mario.isCrouching = false;
                    currentState.Add(command);
                    //command.Execute();
                }
                else if (mouseState.Y > BottomY)
                {
                    // Mario should be crouching
                    command = new MarioCrouchCommand(level.mario);
                    //game.mario.isJumping = false;
                    level.mario.isCrouching = true;
                    currentState.Add(command);
                    //command.Execute();
                }
            }
            else
            {
                // Mouse should not be used
                pastState.Clear();
                currentState.Clear();
            }

            // Make sure that Mario's update function gets CurrentState before it is cleared
            level.mario.Update();

            // Copy currentState to pastState and clear
            pastState.Clear();
            foreach (ICommand command in currentState)
            {
                pastState.Add(command);
            }
            currentState.Clear();
        }
    }
}
