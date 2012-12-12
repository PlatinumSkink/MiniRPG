using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mini_RPG
{
    class Enemy : AnimatedObject
    {
        public Enemy(Point _sheetSize, string _textureName, Vector2 _position, float _speed)
            : base(_sheetSize, _textureName, _position, _speed)
        {

        }
        public void Hunt(Vector2 target)
        {
            Direction = (target - Pos);
            
        }
    }
}
