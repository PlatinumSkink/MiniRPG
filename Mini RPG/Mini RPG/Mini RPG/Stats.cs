using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Stats(int _health, int _stamina, int _range, int _speed, int _strength, string _name)
        {
            Health = _health;
            Stamina = _stamina;
            Range = _range;
            Speed = _speed;
            Strength = _strength;
            Name = _name;
        }
    }
}
