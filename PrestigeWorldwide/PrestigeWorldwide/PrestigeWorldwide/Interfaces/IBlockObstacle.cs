using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrestigeWorldwide
{
    public interface IBlockObstacle
    {
        Vector2 Location { get; set; }
        Boolean garbage_collect { get; set; }
        void Update();
        void Draw();
        Rectangle Collider { get; }
        void Bump();
        void SecretLevel();
    }
}
