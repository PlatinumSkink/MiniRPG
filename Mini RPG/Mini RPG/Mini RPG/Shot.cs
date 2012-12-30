using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Mini_RPG
{
    class Shot:AnimatedObject
    {
        public Stats stats;

        public Shot(Point _sheetSize, string _textureName, Vector2 _position, float _speed, float _rotation, ContentManager Content)
            : base(_sheetSize, _textureName, _position, _speed, Content)
        {
            rotation = _rotation;
            Direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            LoadStats(_textureName);
        }

        public void LoadStats(string Name)
        {
            stats = Core.Library.FindShotStats(Name);
        }
    }
}
