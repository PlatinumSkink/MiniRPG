using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}