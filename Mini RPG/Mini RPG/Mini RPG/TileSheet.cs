using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mini_RPG
{
    class TileSheet : Position
    {
        public Texture2D spriteSheet;
        public int tileSize = 32;
        public Vector2 tileSheetSize;
        public TileSheet(string _spriteSheet, Vector2 _position, int _tileSize)
            : base(_position)
        {
            Load(_spriteSheet);
            tileSize = _tileSize;
            tileSheetSize.X = spriteSheet.Width / tileSize;
            tileSheetSize.Y = spriteSheet.Height / tileSize;
        }
        public void Load(string spriteName)
        {
            spriteSheet = content.Load<Texture2D>("Graphics/" + spriteName);
        }
    }
}
