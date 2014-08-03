using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide
{
    public interface IGoombaState
    {
        Rectangle Update();
        void Draw(Vector2 location,int isMovingRight, int isFrozen);
    }
}
