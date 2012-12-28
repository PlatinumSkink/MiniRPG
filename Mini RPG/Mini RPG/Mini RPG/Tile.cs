using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mini_RPG
{
    [Serializable]
    class Tile:Position
    {
        public string Name { get; set; }
        public Point sheetPoint;
        public static int tileSize;
        public Vector2 origin { get; set; }

        public Tile(string textureName, Point _sheetPoint, Vector2 position):base(position)
        {
            Name = textureName;
            sheetPoint = _sheetPoint;
            origin = new Vector2(tileSize / 2, tileSize / 2);
        }

        public Rectangle SourceRectangle()
        {
            return new Rectangle(sheetPoint.X * tileSize, sheetPoint.Y * tileSize, tileSize, tileSize);
        }

        public virtual Rectangle CollisionRectangle()
        {
            return new Rectangle((int)X, (int)Y, tileSize, tileSize);
        }

        public virtual Rectangle CollisionRectangleForShots()
        {
            return new Rectangle((int)X - (int)origin.X, (int)Y - (int)origin.Y, tileSize, tileSize);
        }

        public void Draw(SpriteBatch spriteBatch, TileSheet tileSheet)
        {
            spriteBatch.Draw(tileSheet.spriteSheet, Pos, SourceRectangle(), Color.White, 0f, origin, 1f, SpriteEffects.None, 0f);
        }

        public void DrawSmall(SpriteBatch spriteBatch, TileSheet tileSheet)
        {
            spriteBatch.Draw(tileSheet.spriteSheet, Pos, SourceRectangle(), Color.White, 0f, origin, 0.6f, SpriteEffects.None, 0f);
        }
    }
}
