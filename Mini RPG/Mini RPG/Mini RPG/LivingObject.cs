using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mini_RPG
{
    class LivingObject : AnimatedObject
    {
        Stats stats;

        public int Health { get; set; }
        public int Stamina { get; set; }
        public int Range { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }
        public string Name { get; set; }

        //int Health = 5;

        GraphicalObject HealthBar;

        public LivingObject(string _Name, Point _sheetSize, string _textureName, Vector2 _position, float _speed)
            : base(_sheetSize, _textureName, _position, _speed)
        {
            LoadStats(_Name);
            stats.Health = 5;
            HealthBar = new GraphicalObject("HealthBar", Vector2.Zero);
        }

        public override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
        }
        public void LoadStats(string Name)
        {
            stats = Core.Library.FindLivingObjectStats(Name);
            Health = stats.Health;
            Stamina = stats.Stamina;
            Range = stats.Range;
            Speed = stats.Speed;
            Strength = stats.Strength;
            Name = stats.Name;
        }
        public bool Damage(int strength)
        {
            Health -= strength;
            if (Health <= 0)
            {
                return true;
            }
            return false;
        }
        /*public bool Damage(int strenght)
        {
            Health -= strenght;
            if (Health <= 0)
            {
                return true;
            }
            if (stats.Damage(strenght)) 
            {
                return true;
            }
            return false;
        }*/

        public override void Draw(SpriteBatch sprite)
        {
            base.Draw(sprite);
        }
    }
}
