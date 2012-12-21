using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Mini_RPG
{
    class Player : AnimatedObject
    {
        KeyboardManager ks = new KeyboardManager();

        Keys Up = Keys.Up;
        Keys Down = Keys.Down;
        Keys Left = Keys.Left;
        Keys Right = Keys.Right;
        bool moving = false;

        public Player(string _textureName, Vector2 _position, float _speed):base(new Point(1, 1), _textureName, _position, _speed)
        {

        }
        public override void Update(GameTime gameTime)
        {
            /*DirectionX = ms.X - X;
            DirectionY = ms.Y - Y;*/
            if (ks.CheckKeyState(Up))
            {
                DirectionY = -1;
            }
            else if (ks.CheckKeyState(Down))
            {
                DirectionY = 1;
            }
            else
            {
                DirectionY = 0;
            }
            if (ks.CheckKeyState(Left))
            {
                DirectionX = -1;
            }
            else if (ks.CheckKeyState(Right))
            {
                DirectionX = 1;
            }
            else
            {
                DirectionX = 0;
            }
            //AdjustDirection();
            //base.Update(gameTime);
        }
        
        public void AdjustDirection(Vector2 CameraOffset)
        {
            MouseState ms = Mouse.GetState();
            Point mousePosition = new Point(ms.X, ms.Y);
            Vector2 distance = new Vector2(mousePosition.X - CameraOffset.X, mousePosition.Y - CameraOffset.Y);
            distance.X = X + ms.X - CameraOffset.X - Core.WorldWidth / 2;
            distance.Y = Y + ms.Y - CameraOffset.Y - Core.WorldHeight / 2;

            float hypotenusa = (float)Math.Sqrt(distance.X * distance.X + distance.Y * distance.Y);

            //rotation = (float)Math.Atan2(mousePosition.Y - Y - origin.Y, mousePosition.X - X - origin.X);
            rotation = (float)Math.Atan2(mousePosition.Y + CameraOffset.Y - Y - origin.Y, mousePosition.X + CameraOffset.X - X - origin.X);
            rotation = (float)Math.Atan2(distance.Y, distance.X);

            //rotation = (float)Math.Acos(Math.Cos(distance.X / hypotenusa));

            /*if (distance.X > 0)
            {
                rotation = (float)Math.Atan(Math.Tan(distance.Y / distance.X));    
                //rotation = (float)3.14 * (float)Math.Cos(distance.X / hypotenusa);
                //rotation = (float)Math.Tanh(distance.Y / distance.X);
            }
            else
            {
                rotation = (float)Math.Asin(Math.Sinh(distance.Y / hypotenusa)) + MathHelper.ToRadians(180);
                //rotation = (float)Math.Tanh(distance.Y / distance.X) + MathHelper.ToRadians(180);
            }*/

            //rotation = (float)Math.Sin(distance.Y / hypotenusa);
            /*if (distance.Y > Core.WorldHeight / 2 + 100)
            {
                rotation = (float)Math.Sin(distance.Y / hypotenusa);
            }
            else if (distance.Y < Core.WorldHeight / 2 - 100) 
            {
                rotation = (float)Math.Sin(distance.Y / hypotenusa);
            }
            else if (distance.X > 0)
            {
                rotation = (float)Math.Tanh(distance.Y / distance.X);
            }
            else
            {
                rotation = (float)Math.Tanh(distance.Y / distance.X) + MathHelper.ToRadians(180);
            }*/
            //rotation = (float)Math.Cos(distance.X / hypotenusa);
            /*Console.WriteLine(rotation);
            Console.WriteLine("Mouse: " + mousePosition);
            Console.WriteLine("Camera: " + CameraOffset);
            Console.WriteLine("Result: " + distance);*/

            /*if (Direction.X == 1 && Direction.Y == 0)
            {
                rotation = MathHelper.ToRadians(0);
            }
            else if (Direction.X == 1 && Direction.Y == 1)
            {
                rotation = MathHelper.ToRadians(45);
            }
            else if (Direction.X == 0 && Direction.Y == 1)
            {
                rotation = MathHelper.ToRadians(90);
            }
            else if (Direction.X == -1 && Direction.Y == 1)
            {
                rotation = MathHelper.ToRadians(135);
            }
            else if (Direction.X == -1 && Direction.Y == 0)
            {
                rotation = MathHelper.ToRadians(180);
            }
            else if (Direction.X == -1 && Direction.Y == -1)
            {
                rotation = MathHelper.ToRadians(225);
            }
            else if (Direction.X == 0 && Direction.Y == -1)
            {
                rotation = MathHelper.ToRadians(270);
            }
            else if (Direction.X == 1 && Direction.Y == -1)
            {
                rotation = MathHelper.ToRadians(315);
            }*/
        }
    }
}
