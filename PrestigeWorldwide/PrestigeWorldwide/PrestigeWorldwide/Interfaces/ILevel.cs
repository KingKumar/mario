using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide.Interfaces
{
    interface ILevel
    {
        void Quit();
        void PlayVictoryAnimation(Vector2 flagpoleLocation);
        void loadContent();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}
