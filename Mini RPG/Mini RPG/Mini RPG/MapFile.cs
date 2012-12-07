using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mini_RPG
{
    [Serializable]
    class MapFile
    {
        public int WorldSizeX { get; set; }
        public int WorldSizeY { get; set; }

        //First is list pos, second is X SpritePos, third is Y SpritePos
        int[,] positions;


        public MapFile(int tileLenght, int _WorldSizeX, int _WorldSizeY)
        {
            positions = new int[tileLenght, 2];
            WorldSizeX = _WorldSizeX;
            WorldSizeY = _WorldSizeY;
        }

        public void PositionDefiner(int listPos, int spriteXPos, int spriteYPos)
        {
            positions[listPos, 0] = spriteXPos;
            positions[listPos, 1] = spriteYPos;

        }
        public int GetPositions(int listPos, char XorY)
        {
            if (XorY == 'x')
            {
                return positions[listPos, 0];
            }
            else if (XorY == 'y')
            {
                return positions[listPos, 1];
            }
            return 0;
        }
    }
}
