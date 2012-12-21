using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mini_RPG
{
    class Shot:AnimatedObject
    {
        Stats shotStats;

        public Shot(Point _sheetSize, string _textureName, Vector2 _position, float _speed)
            : base(_sheetSize, _textureName, _position, _speed)
        {
            LoadStats(_textureName);
        }
    }
}
