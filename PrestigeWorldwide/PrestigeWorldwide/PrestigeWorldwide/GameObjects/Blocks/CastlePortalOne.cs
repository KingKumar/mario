using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PrestigeWorldwide.Static_Values;

namespace PrestigeWorldwide.Sprites.Blocks
{
    public class CastlePortalOne:IBlockObstacle
    {
        Vector2 location;
        Texture2D greenPipe;
        Level level;
        Rectangle collider = new Rectangle(0,0,0,0);
        Boolean garbage;
        bool triggered;
        int decrement;

        public CastlePortalOne(Texture2D greenPipe, Vector2 location, Level level)
        {
            this.location = location;
            this.greenPipe = greenPipe;
            this.level = level;
            this.garbage = false;
            triggered = false;
            decrement = 0;
        }

        public Rectangle Collider { get { return collider; } }

        public void Update()
        {
            if (triggered)
            {
                level.mario.location.X = location.X + 5;
                level.mario.marioState.MarioIdle();
                level.mario.stateLock = true;
                decrement++;
            }

            if (decrement == 100)
            {
                level.mario.stateLock = false;
                level.mario.location.X = 3070;
                level.mario.location.Y = 100;
                level.camera.screenRegion = 4;
                triggered = false;
                decrement = 0;
                level.game.sounds.UnderGround();
            }
                UpdateCollider();
        }

        private void UpdateCollider()
        {
            collider.Height = greenPipe.Height;
            collider.Width = greenPipe.Width;
            collider.X = (int)location.X;
            collider.Y = (int)location.Y + decrement;
        }

        public Boolean garbage_collect { get { return garbage; } set { garbage = value; } }

        public void SecretLevel()
        {
            System.Console.WriteLine("Entering Segment 2 of Castle Level");
            if (triggered == false)
            {
                level.game.sounds.WarpPipe();
            }
            triggered = true;

        }

        public void Bump()
        {
        }
        
        public void Draw()
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, greenPipe.Width, greenPipe.Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X - level.camera.X, (int)location.Y - level.camera.Y, greenPipe.Width, greenPipe.Height);
            level.spriteBatch.Begin();
            level.spriteBatch.Draw(greenPipe, destinationRectangle, sourceRectangle, Color.White);
            level.spriteBatch.End();
        }


        public Vector2 Location
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
