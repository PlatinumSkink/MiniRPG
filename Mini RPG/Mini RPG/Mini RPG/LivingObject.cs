using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mini_RPG
{
    class LivingObject : AnimatedObject
    {
        public Stats stats { get; set; }

        public LivingObject(string _Name, Point _sheetSize, string _textureName, Vector2 _position, float _speed)
            : base(_sheetSize, _textureName, _position, _speed)
        {
            LoadStats(_Name);
        }
        public void LoadStats(string Name)
        {
            stats = Library.FindLivingObjectStats(Name);
        }
    }
}
