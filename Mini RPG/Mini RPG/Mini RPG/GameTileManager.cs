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
        public void Trigger(int effected)
        {
            foreach (Text number in collisionNumber) 
            {
                if (int.Parse(number.Texts) == effected) 
                {

                }
            }
        }
        public bool CheckCollision(Player player, Point collisionPoint)
        {
            foreach (Tile tile in collisionTiles) 
            {
                if (tile.sheetPoint == collisionPoint && player.CollisionRectangle().Intersects(tile.CollisionRectangle()))
                {
                    return true;
                }
            }
            return false;
        }
    }
}