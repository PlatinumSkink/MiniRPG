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

        public Shot(Point _sheetSize, string _textureName, Vector2 _position, float _speed, float _rotation)
            : base(_sheetSize, _textureName, _position, _speed)
        {
            rotation = _rotation;
            Direction = new Vector2((float)Math.Acos(rotation), (float)Math.Asin(rotation));
            LoadStats(_textureName);
        }

        public void LoadStats(string Name)
        {
            shotStats = Library.FindShotStats(Name);
        }
    }
}
