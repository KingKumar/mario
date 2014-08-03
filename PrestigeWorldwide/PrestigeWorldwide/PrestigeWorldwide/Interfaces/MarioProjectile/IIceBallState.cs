using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide.Interfaces.MarioProjectile
{
    public interface IIceBallState
    {
        Texture2D Texture { get; }
        Rectangle Update();
        void Draw(Vector2 location, int isMovingRight);
    }
}  



