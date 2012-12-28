using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mini_RPG
{
    class Stats
    {
        public int Health { get; set; }
        public int Stamina { get; set; }
        public int Range { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }
        public string Name { get; set; }

        GraphicalObject HealthBar = new GraphicalObject("HealthBar", Vector2.Zero);

        public Stats(int _health, int _stamina, int _range, int _speed, int _strength, string _name)
        {
            Health = _health;
            Stamina = _stamina;
            Range = _range;
            Speed = _speed;
            Strength = _strength;
            Name = _name;
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
    }
}
