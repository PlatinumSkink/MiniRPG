﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mini_RPG
{
    class InteractableTerrain : AnimatedObject
    {
        public bool SecondPoint = false;
        public bool Button;
        public bool[] Collider = new bool[2];

        public InteractableTerrain(bool _Button, Point _sheetSize, bool[] _colliders, string _textureName, Vector2 _position)
            : base(_sheetSize, _textureName, _position, 0)
        {
            Button = _Button;
            Collider = _colliders;
        }

        /*public override Rectangle CollisionRectangle()
        {
            if (SecondPoint == true)
            {
                if (Collider[1] == true)
                {
                    base.CollisionRectangle();
                }
            }
            else
            {
                if (Collider[0] == true)
                {
                    base.CollisionRectangle();
                }
            }
            return new Rectangle(-50, -50, 0, 0);
        }*/
        public override Rectangle GraphicsRectangle()
        {
            return new Rectangle((int)(X), (int)(Y), Width, Height);
        }

        public void Switch(Point next)
        {
            currentSprite = next;
        }

        /*public override void Draw(SpriteBatch spriteBatch)
        {
            if (SecondPoint == true)
            {
                spriteBatch.Draw(secondTexture, CollisionRectangle(), Color.White);
            }
            else
            {
                base.Draw(spriteBatch);
            }
        }*/
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, /*Collision*/GraphicsRectangle(), SourceRectangle(), Color.White, rotation, origin, SpriteEffects.None, 0f);
        }
    }
}
