using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Mini_RPG
{
    class TileSheet : Position
    {
        public Texture2D spriteSheet;
        public int tileSize = 32;
        public Vector2 tileSheetSize;
        public TileSheet(string _spriteSheet, Vector2 _position, int _tileSize, ContentManager Content)
            : base(_position)
        {
            Load(Content, _spriteSheet);
            tileSize = _tileSize;
            tileSheetSize.X = spriteSheet.Width / tileSize;
            tileSheetSize.Y = spriteSheet.Height / tileSize;
        }
        public void Load(ContentManager Content, string spriteName)
        {
            spriteSheet = Content.Load<Texture2D>("Graphics/" + spriteName);
        }
    }
}
