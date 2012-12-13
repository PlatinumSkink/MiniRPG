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
        public float speed;
        Vector2 direction = Vector2.Zero;
        Vector2 lastPos = Vector2.Zero;
        string nameToRememberYouBy = "";

        public Vector2 Direction
        {
            get { return direction; }
            set
            {
                //Console.WriteLine(direction);
                direction = value;
                //Console.WriteLine(direction);
                if (direction != Vector2.Zero)
                {
                    direction.Normalize();
                }
                //Console.WriteLine(direction);
            }
        }
        public float DirectionX
        {
            get { return direction.X; }
            set
            {
                //Console.WriteLine(direction);
                direction.X = value;
                //Console.WriteLine(direction);
                if (direction != Vector2.Zero)
                {
                    direction.Normalize();
                }
                //Console.WriteLine(direction);
            }
        }
        public float DirectionY
        {
            get { return direction.Y; }
            set
            {
                //Console.WriteLine(direction);
                direction.Y = value;
                //Console.WriteLine(direction);
                if (direction != Vector2.Zero)
                {
                    direction.Normalize();
                }
                //Console.WriteLine(direction);
            }
        }

        public Vector2 LastPos
        {
            get { return lastPos; }
            set { lastPos = value; }
        }

        public MovingObject(string _textureName, Vector2 _position, float speed)
            : base(_textureName, _position)
        {
            this.speed = speed;
            nameToRememberYouBy = _textureName;
        }
        public virtual void Update(GameTime gameTime)
        {
            Pos += direction * speed;
        }
    }
}
