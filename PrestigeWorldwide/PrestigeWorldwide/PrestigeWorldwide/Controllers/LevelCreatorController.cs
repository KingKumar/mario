using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Commands;
using PrestigeWorldwide.Commands.Level_Creator_Commands;

namespace PrestigeWorldwide
{
    public class LevelCreatorController
    {
        public LevelCreator level;
        private Dictionary<Keys, ICommand> keyMapping = new Dictionary<Keys, ICommand>();
        private ICommand command;
        Boolean tabUp;
        Boolean lUp;

        public LevelCreatorController(LevelCreator level)
        {
            this.level = level;
            keyMapping.Add(Keys.W, new CameraPanUp(this.level));
            keyMapping.Add(Keys.S, new CameraPanDown(this.level));
            keyMapping.Add(Keys.D, new CameraPanRight(this.level));
            keyMapping.Add(Keys.A, new CameraPanLeft(this.level));
            keyMapping.Add(Keys.Enter, new CursorPlaceCommand(this.level));
            keyMapping.Add(Keys.Q, new CreatorQuitCommand(this.level));
            keyMapping.Add(Keys.Tab, new ToggleMouseCommand(this.level));
            keyMapping.Add(Keys.L, new GenerateLevel(this.level));

        }
        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            if(keyState.IsKeyUp(Keys.Tab)){tabUp = true;}
            if (keyState.IsKeyUp(Keys.L)) { lUp = true; }


            foreach (Keys key in keyMapping.Keys)
            {
                if (keyState.IsKeyDown(key) && keyMapping.TryGetValue(key, out command))
                {
                    if ((key == Keys.Tab))
                    {
                        if (tabUp)
                        {
                            command.Execute();
                            tabUp = false;
                        }
                    }
                    else if ((key == Keys.L))
                    {
                        if (lUp)
                        {
                            command.Execute();
                            lUp = false;
                        }
                    }
                    else if (key != Keys.Tab)
                        command.Execute();
                }
            }
        }
    }
}
