using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide
{
    public class GamepadController : IController
    {
        // Fields
        private Dictionary<Buttons, ICommand> buttonMapping = new Dictionary<Buttons, ICommand>();
        private Level level;
        private ICommand command;
        private ArrayList pastState;
        private ArrayList currentState;
        private int shouldNotUseGamepad = 0;

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

        // Constructor
        public GamepadController(Level level)
        {
            this.level = level;
            pastState = new ArrayList();
            currentState = new ArrayList();
            buttonMapping.Add(Buttons.Start, new QuitCommand(this.level));
            buttonMapping.Add(Buttons.DPadDown, new MarioCrouchCommand(this.level.mario));
            buttonMapping.Add(Buttons.DPadRight, new MarioRunRightCommand(this.level.mario));
            buttonMapping.Add(Buttons.DPadLeft, new MarioRunLeftCommand(this.level.mario));
        }

        // Implementation of IController.Update()
        public void Update()
        {

            GamePadState buttonState = GamePad.GetState(PlayerIndex.One);
            foreach (Buttons button in buttonMapping.Keys)
            {
                if (buttonState.IsButtonDown(button) && buttonMapping.TryGetValue(button, out command))
                {
                    currentState.Add(command);
                    //command.Execute();
                }
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