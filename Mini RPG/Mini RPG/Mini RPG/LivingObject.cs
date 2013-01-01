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

        public int StandardHealth { get; set; }
        public int Health { get; set; }
        public int StandardStamina { get; set; }
        public int Stamina { get; set; }
        public int StandardRange { get; set; }
        public int Range { get; set; }
        public float StandardSpeed { get; set; }
        public float Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }
        public int StandardStrength { get; set; }
        public int Strength { get; set; }
        public string Name { get; set; }

        //int Health = 5;

        Bar HealthBar;

        public LivingObject(string _Name, Point _sheetSize, string _textureName, Vector2 _position, float _speed)
            : base(_sheetSize, _textureName, _position, _speed)
        {
            LoadStats(_Name);
            HealthBar = new Bar(StandardHealth, "HealthBar", Vector2.Zero);
        }

        public override void Update(GameTime gameTime)
        {
            HealthBar.Update(Pos, Health);
            //base.Update(gameTime);
        }
        public void LoadStats(string Name)
        {
            stats = Core.Library.FindLivingObjectStats(Name);
            StandardHealth = stats.Health;
            Health = StandardHealth;
            StandardStamina = stats.Stamina;
            Stamina = StandardStamina;
            StandardRange = stats.Range;
            Range = StandardRange;
            StandardSpeed = stats.Speed;
            Speed = StandardSpeed;
            StandardStrength = stats.Strength;
            Strength = StandardStrength;
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            HealthBar.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
