using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mini_RPG
{
    class TileArsenal:Position
    {
        public List<Tile> tileArsenal = new List<Tile>();
        public List<GraphicalObject> borders = new List<GraphicalObject>();

        Vector2 whereItWas;
        Vector2 dragPoint;
        public bool dragging = false;

        TileSheet tileSheet;
        int tileSize;

        public TileArsenal(Vector2 _position, TileSheet _tileSheet, int _tileSize, ContentManager Content)
            : base(_position)
        {
            tileSheet = _tileSheet;
            tileSize = _tileSize;
            for (int i = 0; i < tileSheet.tileSheetSize.Y; i++)
            {
                for (int j = 0; j < tileSheet.tileSheetSize.X; j++)
                {
                    tileArsenal.Add(new Tile("", new Point(j, i), new Vector2(j * tileSize, i * tileSize)));
                }
            }
            for (int i = 0; i < tileSheet.tileSheetSize.Y + 2; i++)
            {
                borders.Add(new GraphicalObject("Grass", Vector2.Zero, Content));
                borders.Add(new GraphicalObject("Grass", Vector2.Zero, Content));
            }
            for (int j = 0; j < tileSheet.tileSheetSize.X; j++)
            {
                borders.Add(new GraphicalObject("Grass", Vector2.Zero, Content));
                borders.Add(new GraphicalObject("Grass", Vector2.Zero, Content));
            }
        }
        public void Update()
        {
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed && dragging == false) {
                foreach (var border in borders) {
                    if (border.CollisionRectangle().Contains(new Point(ms.X, ms.Y)))
                    {
                        whereItWas = Pos;
                        dragPoint = new Vector2(ms.X, ms.Y);
                        dragging = true;
                    }
                }
            }
            if (ms.LeftButton == ButtonState.Pressed && dragging == true)
            {
                Pos = whereItWas + new Vector2(ms.X, ms.Y) - dragPoint;
            }
            else if (ms.LeftButton == ButtonState.Released && dragging == true)
            {
                whereItWas = Vector2.Zero;
                dragPoint = Vector2.Zero;
                dragging = false;
            }
            int index = 0;
            for (int i = 0; i < tileSheet.tileSheetSize.Y; i++)
            {
                for (int j = 0; j < tileSheet.tileSheetSize.X; j++)
                {
                    tileArsenal[index].Pos = Pos + new Vector2(j * tileSize + tileSize, i * tileSize + tileSize);
                    index++;
                }
            }
            for (int i = 0; i < tileSheet.tileSheetSize.Y + 2; i++)
            {
                borders[i].Pos = Pos + new Vector2(0, i * tileSize);
                borders[i + (int)tileSheet.tileSheetSize.Y + 2].Pos = Pos + new Vector2(tileSheet.spriteSheet.Width + tileSize, i * tileSize);
            }
            for (int j = 0; j < tileSheet.tileSheetSize.X; j++)
            {
                borders[j + ((int)tileSheet.tileSheetSize.Y + 2) * 2].Pos = Pos + new Vector2(j * tileSize + tileSize, 0);
                borders[j + (int)tileSheet.tileSheetSize.X + ((int)tileSheet.tileSheetSize.Y + 2) * 2].Pos = Pos + new Vector2(j * tileSize + tileSize, tileSheet.spriteSheet.Height + tileSize);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GraphicalObject border in borders)
            {
                border.Draw(spriteBatch);
            }
            foreach (Tile tile in tileArsenal)
            {
                tile.Draw(spriteBatch, tileSheet);
            }
        }
    }
}
