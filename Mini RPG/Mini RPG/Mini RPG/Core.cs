using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace Mini_RPG
{
    static class Core
    {
        public static int WorldWidth { get; set; }
        public static int WorldHeight { get; set; }

        public static int ShotsPerSecond = 2;

        public static Library Library = new Library();
        public static ContentManager Content;
    }
}