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

        GraphicalObject HealthBar;

        public LivingObject(string _Name, Point _sheetSize, string _textureName, Vector2 _position, float _speed)
            : base(_sheetSize, _textureName, _position, _speed)
        {
            LoadStats(_Name);
            HealthBar = new GraphicalObject("HealthBar", Vector2.Zero);
        }

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }
        public void LoadStats(string Name)
        {
            stats = Core.Library.FindLivingObjectStats(Name);
        }
        public bool Damage(int strenght)
        {
            if (stats.Damage(strenght)) 
            {
                return true;
            }
            return false;
        }
    }
}
