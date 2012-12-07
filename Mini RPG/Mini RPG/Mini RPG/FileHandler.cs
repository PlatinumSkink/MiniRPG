using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.Xna.Framework;

namespace Mini_RPG
{
    class FileHandler
    {
        MapFile mapFile;
        public FileHandler()
        {
            
        }
        public void WriteFile(List<List<Tile>> tileMaps, List<Text> number, string mapName, Vector2 WorldSize)
        {
            List<MapFile> mapFiles = new List<MapFile>();
            
            for (int i = 0; i < tileMaps.Count; i++)
            {
                mapFiles.Add(new MapFile(tileMaps[i].Count, (int)WorldSize.X, (int)WorldSize.Y));
            }
            mapFiles.Add(new MapFile(number.Count, (int)WorldSize.X, (int)WorldSize.Y));

            for (int fileNumber = 0; fileNumber < tileMaps.Count; fileNumber++)
            {
                for (int i = 0; i < tileMaps[fileNumber].Count; i++)
                {
                    if (fileNumber < tileMaps.Count )
                    {
                        mapFiles[fileNumber].PositionDefiner(i, tileMaps[fileNumber][i].sheetPoint.X, tileMaps[fileNumber][i].sheetPoint.Y);
                    }
                }
            }
            for (int i = 0; i < tileMaps[0].Count; i++)
            {
                    mapFiles[4].PositionDefiner(i, Int32.Parse(number[i].Texts), 0);
            }

            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = File.Open(mapName, FileMode.Create);
            bf.Serialize(stream, mapFiles);
            stream.Close();
        }

        public List<List<Tile>> GetFile(string mapName)
        {
            try
            {
                FileStream stream = new FileStream(mapName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                List<MapFile> mapFiles = (List<MapFile>)bf.Deserialize(stream);
                stream.Close();

                List<List<Tile>> tileMaps = new List<List<Tile>>();

                for (int i = 0; i < mapFiles.Count; i++)
                {
                    tileMaps.Add(new List<Tile>());
                }

                for (int fileNumber = 0; fileNumber < tileMaps.Count; fileNumber++)
                {
                    for (int i = 0; i < mapFiles[fileNumber].WorldSizeX * mapFiles[fileNumber].WorldSizeY; i++)
                    {
                        tileMaps[fileNumber].Add(new Tile("", new Point(mapFiles[fileNumber].GetPositions(i, 'x'), mapFiles[fileNumber].GetPositions(i, 'y')), new Vector2(0, 0)));
                    }
                }

                return tileMaps;
            }
            catch
            {
                return new List<List<Tile>>();
            }
        }
    }
}
