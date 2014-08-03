using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IAnimatedSprite
{
    // Common texture fields
    Texture2D Texture { get; }

    // Common sprite methods
    void Update();
    void Draw();
}

