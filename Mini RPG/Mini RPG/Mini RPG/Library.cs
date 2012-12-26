using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mini_RPG
{
    class Library
    {
        public static List<Stats> EnemyLibrary = new List<Stats>();
        public static List<Stats> PlayerLibrary = new List<Stats>();
        public static List<Stats> ShotLibrary = new List<Stats>();

        public static Stats enemy1 = new Stats(5, 5, 0, 2, 5, "Monster1");
        public static Stats enemy2 = new Stats(5, 5, 0, 2, 5, "Monster2");
        public static Stats enemy3 = new Stats(5, 5, 0, 2, 5, "Monster3");
        public static Stats enemy4 = new Stats(5, 5, 0, 2, 5, "Monster4");
        public static Stats enemy5 = new Stats(5, 5, 0, 2, 5, "Monster5");

        public static Stats normalBullet = new Stats(0, 10, 10, 5, 2, "Shot3");

        public void ArrangeLibrary()
        {
            EnemyLibrary.Add(enemy1);
            EnemyLibrary.Add(enemy2);
            EnemyLibrary.Add(enemy3);
            EnemyLibrary.Add(enemy4);
            EnemyLibrary.Add(enemy5);

            ShotLibrary.Add(normalBullet);
        }

        public static Stats FindLivingObjectStats(string Name)
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
        public static Stats FindShotStats(string Name)
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
    }
}
