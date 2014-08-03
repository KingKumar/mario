using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide
{
   public interface ILakituState
    {
        Rectangle Update(Vector2 location, int isMovingRight);
        void Draw(Vector2 location, int isMovingRight, int isFrozen);
    }
}
