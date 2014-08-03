using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide
{
    public interface IConsumableItem
    {
        Vector2 Location { get; set; }
        Boolean garbage_collect { get; }
        void Update();
        void Draw();
        Rectangle Collider{get;}
        void Bump(int x, int y);
        int Consume();
    }
}
