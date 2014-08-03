using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide
{
    public interface IProjectile
    {
        Boolean garbageCollect { get; }
        void Update();
        void Draw();
        Rectangle Collider { get; }
        void Bump(int X, int Y);
        void Explode();
    }
}
