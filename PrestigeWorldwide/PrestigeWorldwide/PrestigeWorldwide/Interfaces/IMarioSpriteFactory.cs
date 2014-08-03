using System;

public interface IMarioSpriteFactory {

    // Common mario animations for all power states (except dead state)
    IAnimatedSprite CreateRunningMarioSprite(int isMovingRight);
    IAnimatedSprite CreateJumpingMarioSprite(int isMovingRight);
    IAnimatedSprite CreateCrouchingMarioSprite(int isMovingRight);
    IAnimatedSprite CreateIdleMarioSprite(int isMovingRight);

}

