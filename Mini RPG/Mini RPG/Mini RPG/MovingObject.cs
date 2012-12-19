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
        public GhostCollider GhostX;
        public GhostCollider GhostY;
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
            Pos += Direction * speed;
            GhostX.X = X + Direction.X * speed;
            GhostX.Y = Y;
            GhostY.X = X;
            GhostY.Y = Y + Direction.Y * speed;
        }
        public void UpdateX(GameTime gameTime, bool plus)
        {
            if (plus == true)
            {
                X += Direction.X * speed;
            }
            else
            {
                //X -= Direction.X * speed;
            }
            GhostX.X = X + Direction.X * speed;
            GhostX.Y = Y;
        }
        public void UpdateY(GameTime gameTime, bool plus)
        {
            if (plus == true)
            {
                Y += Direction.Y * speed;
            }
            else
            {
                //Y -= Direction.Y * speed;
            }
            GhostY.X = X;
            GhostY.Y = Y + Direction.Y * speed;
        }
        public void AddGhosts()
        {
            GhostX = new GhostCollider(new Vector2(Width, Height), Pos);
            GhostY = new GhostCollider(new Vector2(Width, Height), Pos);
        }
        public virtual void DrawGhosts(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, GhostX.Collider(), Color.Aqua);
            spriteBatch.Draw(texture, GhostY.Collider(), Color.Aqua);
        }
    }
}
