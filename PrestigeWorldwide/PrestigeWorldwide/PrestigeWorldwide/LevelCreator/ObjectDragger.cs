using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrestigeWorldwide
{
    public class ObjectDragger
    {
        public LevelCreator level;
        public Texture2D selectedObject;
        public SpriteBatch spriteBatch;
        public Boolean hasObjectSelected = false;
        public Stamp currentStamp;

        public ObjectDragger(LevelCreator level)
        {
            this.level = level;
            this.spriteBatch = level.spriteBatch;
        }
        public void FindObjectAt(Point mousePos)
        {
            if(level.uiLoader.saveLevelHitBox.Contains(mousePos))
            {
                level.GenerateLevel();
            }
            foreach (Stamp stamp in level.textureStamps)
            {
                if (stamp.hitBox.Contains(mousePos)  && !hasObjectSelected)
                {
                    currentStamp = stamp;
                    stamp.isSelected = true;
                    hasObjectSelected = true;
                }


            }
        }
        public void Drag(Point mousepos)
        {
            if (hasObjectSelected)
            {
                currentStamp.Drag();
            }
        }

        public void Remove(Point mousePos)
        {
            
                foreach (Stamp stamp in level.textureStamps)
                {
                    if (stamp.hitBox.Contains(mousePos))
                    {
                        stamp.Remove();
                    }
            }
                if (hasObjectSelected) { currentStamp.Remove(true); }
            hasObjectSelected = false;
        }
        public void StretchHorizontal()
        {
            if (hasObjectSelected)
            {
                currentStamp.StretchHorizontal();
            }
        }
        public void StretchVertical()
        {
            if (hasObjectSelected)
                currentStamp.StretchVertical();
        }

        public void ShrinkHorizontal()
        {
            if (hasObjectSelected)
            {
                currentStamp.ShrinkHorizontal();
            }
        }
        public void ShrinkVertical()
        {
            if (hasObjectSelected)
                currentStamp.ShrinkVertical();
        }

        public void Brush(Boolean drop = false)
        {
           if(hasObjectSelected)
           {
               if (!currentStamp.isBackground)
               {
                   foreach (Stamp stamp in level.textureStamps)
                   {
                       Rectangle overlap = Rectangle.Intersect(stamp.stretchHitBox, currentStamp.stretchHitBox);
                       if (!overlap.IsEmpty)
                       {
                           stamp.Remove(false);
                       }

                   }
               }
            }

           if (hasObjectSelected)
           {
               currentStamp.Drop(drop);
               hasObjectSelected = !drop;
           }

        }
    }
}
