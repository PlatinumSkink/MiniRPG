using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mini_RPG
{
    class GameTileManager : TileManager
    {
        public GameTileManager(int _tileSize)
            : base(_tileSize)
        {

        }
        public Vector2 TilePosition()
        {
            return Vector2.Zero;
        }
        public Tile TileGetByColor(Point sheetPosition)
        {
            foreach(Tile tile in tileLists[3]/*collisionTiles*/) 
            {
                if (tile.sheetPoint == sheetPosition)
                {
                    return tile;
                }
            }
            return null;
        }
        public void Trigger(int effected)
        {
            foreach (Text number in collisionNumber) 
            {
                if (int.Parse(number.Texts) == effected) 
                {

                }
            }
        }
        public bool CheckCollisionX(Player player, Point collisionPoint)
        {
            foreach (Tile tile in collisionTiles) 
            {
                if (tile.sheetPoint == collisionPoint && player.CollisionRectangle().Intersects(tile.CollisionRectangle()))
                {
                    if (player.X + player.origin.X > tile.X + tile.origin.X - Tile.tileSize / 2 && player.X + player.origin.X < tile.X + tile.origin.X + Tile.tileSize / 2)
                    {
                         return true;
                    }
                }
            }
            return false;
        }
        public bool CheckCollisionY(Player player, Point collisionPoint)
        {
            foreach (Tile tile in collisionTiles)
            {
                if (tile.sheetPoint == collisionPoint && player.CollisionRectangle().Intersects(tile.CollisionRectangle()))
                {
                    if (player.Y + player.origin.Y > tile.Y + tile.origin.Y - Tile.tileSize / 2 && player.Y + player.origin.Y < tile.Y + tile.origin.Y + Tile.tileSize / 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}