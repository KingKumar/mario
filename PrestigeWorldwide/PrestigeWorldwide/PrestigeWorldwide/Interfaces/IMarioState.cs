using System;
using Microsoft.Xna.Framework;
using PrestigeWorldwide;

public interface IMarioState {

    IAnimatedSprite MarioSprite{ get; set; }

    void MarioRunRight();

    void MarioRunLeft();

    void MarioCrouch();

    void MarioJump();

    void MarioIdle();

    void MarioShoot();

    Rectangle Collider();

    void Update();
    
    void Draw();

}

