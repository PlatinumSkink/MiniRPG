using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mini_RPG
{
    class MovingObject : GraphicalObject
    {
        float speed;
        Vector2 direction = Vector2.Zero;

        public Vector2 Direction
        {
            get { return direction; }
            set
            {
                direction = value;
                direction.Normalize();
            }
        }
        public float DirectionX
        {
            get { return direction.X; }
            set
            {
                direction.X = value;
                direction.Normalize(); 
            }
        }
        public float DirectionY
        {
            get { return direction.Y; }
            set
            {
                direction.Y = value;
                direction.Normalize();
            }
        }

        public MovingObject(string _textureName, Vector2 _position, float speed)
            : base(_textureName, _position)
        {
            this.speed = speed;
        }
        public virtual void Update(GameTime gameTime)
        {
            Pos += direction * speed;
        }
    }
}
