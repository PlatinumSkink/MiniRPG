using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mini_RPG
{
    static class Core
    {
        public static int WorldWidth { get; set; }
        public static int WorldHeight { get; set; }

        public static int ShotsPerSecond = 2;

        public static Library Library = new Library();
    }
}
