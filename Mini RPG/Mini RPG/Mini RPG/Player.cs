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
            AdjustDirection();
            //base.Update(gameTime);
        }
        
        public void AdjustDirection()
        {
            if (Direction.X == 1 && Direction.Y == 0)
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
            }
        }
    }
}
