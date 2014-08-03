using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PrestigeWorldwide
{
    public interface IEnemy
    {
        Vector2 Location { get; set; }
        Boolean garbageCollect { get; set; }
        Boolean Lethal { get; }
        void Update();
        void Draw();
        Rectangle Collider{get;}
        void Bump(int x, int y);
        void TakeDamage();
        bool IsDead { get; }
        int IsFrozen { get; set; }
    }
}
