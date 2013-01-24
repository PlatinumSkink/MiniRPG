using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mini_RPG
{
    class Library
    {
        public static List<Stats> EnemyLibrary = new List<Stats>();
        public static List<Stats> PlayerLibrary = new List<Stats>();
        public static List<Stats> ShotLibrary = new List<Stats>();
        public static List<Item> ItemLibrary = new List<Item>();

        public static Stats enemy1 = new Stats(5, 5, 0, 2, 5, "Monster1");
        public static Stats enemy2 = new Stats(5, 5, 0, 2, 5, "Monster2");
        public static Stats enemy3 = new Stats(5, 5, 0, 2, 5, "Monster3");
        public static Stats enemy4 = new Stats(5, 5, 0, 2, 5, "Monster4");
        public static Stats enemy5 = new Stats(5, 5, 0, 2, 5, "Monster5");

        public static Stats normalBullet = new Stats(0, 10, 10, 2, 2, "Shot");
        public static Stats strongBullet = new Stats(0, 15, 15, 3, 4, "Shot2");
        public static Stats superBullet = new Stats(0, 20, 20, 4, 6, "Shot3");

        public void ArrangeLibrary()
        {
            EnemyLibrary.Add(enemy1);
            EnemyLibrary.Add(enemy2);
            EnemyLibrary.Add(enemy3);
            EnemyLibrary.Add(enemy4);
            EnemyLibrary.Add(enemy5);
            EnemyLibrary.Add(new Stats(5, 5, 0, 1, 5, "Enemy"));
            PlayerLibrary.Add(new Stats(1000, 100, 30, 3, 5, "Player"));

            ShotLibrary.Add(normalBullet);
            ShotLibrary.Add(strongBullet);
            ShotLibrary.Add(superBullet);

            ItemLibrary.Add(new Item("PowerUpHealth", "Health", 500));
            ItemLibrary.Add(new Item("PowerUpDrink", "Speed", 1));
            ItemLibrary.Add(new Item("PowerUpBullet", "Strength", 2));
            ItemLibrary.Add(new Item("PowerUpArmor", "Defense", 2));
            ItemLibrary.Add(new Item("PowerUpKey", "Key", 1));
        }

        public Stats FindLivingObjectStats(string Name)
        {
            foreach (Stats stat in EnemyLibrary)
            {
                if (stat.Name == Name)
                {
                    return stat;
                }
            }
            foreach (Stats stat in PlayerLibrary)
            {
                if (stat.Name == Name)
                {
                    return stat;
                }
            }
            return null;
        }
        public Stats FindShotStats(string Name)
        {
            foreach (Stats stat in ShotLibrary)
            {
                if (stat.Name == Name)
                {
                    return stat;
                }
            }
            return null;
        }
        public static Texture2D Load(string textureName)
        {
            return Core.Content.Load<Texture2D>("Graphics/" + textureName);
        }
    }
}
