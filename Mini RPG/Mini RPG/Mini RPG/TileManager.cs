using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mini_RPG
{
    class TileManager
    {
        Vector2 worldSize;
        List<Tile> AllTiles = new List<Tile>();
        List<Tile> tiles1 = new List<Tile>();
        List<Tile> tiles2 = new List<Tile>();
        List<Tile> tiles3 = new List<Tile>();
        public List<Tile> collisionTiles = new List<Tile>();
        protected List<Text> collisionNumber = new List<Text>();
        protected List<List<Tile>> tileLists = new List<List<Tile>>();
        List<GraphicalObject> borders = new List<GraphicalObject>();
        TileSheet tileSheet;
        FileHandler fileHandler;
        int tileSize;

        bool CANONLYCREATEONEWORLD = false;

        public TileManager(int tileSize, ContentManager Content)
        {
            fileHandler = new FileHandler();
            tileSheet = new TileSheet("aztek", Vector2.Zero, tileSize, Content);
            tileLists.Add(tiles1);
            tileLists.Add(tiles2);
            tileLists.Add(tiles3);
            tileLists.Add(collisionTiles);
        }
        public void NewWorld(int tileSize, Vector2 worldSize, ContentManager Content)
        {
            //CreateEmptyWorld
            if (CANONLYCREATEONEWORLD == false)
            {
                this.tileSize = tileSize;
                this.worldSize = worldSize;
                Tile.tileSize = tileSize;
                tileSheet.tileSize = tileSize;
                for (int y = 0; y < worldSize.Y; y++)
                {
                    for (int x = 0; x < worldSize.X; x++)
                    {
                        tiles1.Add(new Tile("Floor", new Point(2, 0), new Vector2(x * tileSize, y * tileSize)));
                        tiles2.Add(new Tile("", new Point(2, 3), new Vector2(x * tileSize, y * tileSize)));
                        tiles3.Add(new Tile("", new Point(2, 3), new Vector2(x * tileSize, y * tileSize)));
                        collisionTiles.Add(new Tile("", new Point(2, 3), new Vector2(x * tileSize, y * tileSize)));
                        collisionNumber.Add(new Text("MiniAndy", "0", Color.White, new Vector2(x * tileSize, y * tileSize),Content));
                        borders.Add(new GraphicalObject("TileBorder", new Vector2(x * tileSize, y * tileSize), Content));
                    }
                }
                foreach (Tile tile in tiles1)
                {
                    AllTiles.Add(tile);
                }
                foreach (Tile tile in tiles2)
                {
                    AllTiles.Add(tile);
                }
                foreach (Tile tile in tiles3)
                {
                    AllTiles.Add(tile);
                }
            }
            CANONLYCREATEONEWORLD = true;
        }
        public TileSheet GetTileSheet()
        {
            return tileSheet;
        }
        public void Update(GameTime gameTime)
        {

        }
        public void SaveWorld(string inputtedName)
        {
            fileHandler.WriteFile(tileLists, collisionNumber, inputtedName, worldSize);
        }
        public void LoadWorld(string inputtedName, ContentManager Content)
        {
            tileLists = fileHandler.GetFile(inputtedName);
            try
            {
                tiles1 = tileLists[0];
                tiles2 = tileLists[1];
                tiles3 = tileLists[2];
                collisionTiles = tileLists[3];

                int index = 0;
                try
                {
                    tileLists[4][0].sheetPoint.Y = tileLists[4][0].sheetPoint.Y;
                }
                catch
                {
                    tileLists.Add(new List<Tile>());
                    for (int y = 0; y < worldSize.Y; y++)
                    {
                        for (int x = 0; x < worldSize.X; x++)
                        {
                            tileLists[4].Add(new Tile("", new Point(0, 0), new Vector2(x * tileSize, y * tileSize)));
                        }
                    }
                }
                foreach (var fakeTile in tileLists[4])
                {
                    collisionNumber[index].Texts = fakeTile.sheetPoint.X.ToString();
                    index++;
                }
                tileLists.Remove(tileLists[4]);
                borders = new List<GraphicalObject>();
                index = 0;
                for (int y = 0; y < worldSize.Y; y++)
                {
                    for (int x = 0; x < worldSize.X; x++)
                    {
                        foreach (var tileList in tileLists)
                        {
                            tileList[index].Pos = new Vector2(x * tileSize, y * tileSize);
                        }
                        /*tiles1[index].Pos = new Vector2(x * tileSize, y * tileSize);
                        tiles2[index].Pos = new Vector2(x * tileSize, y * tileSize);
                        tiles3[index].Pos = new Vector2(x * tileSize, y * tileSize);
                        collisionTiles[index].Pos = new Vector2(x * tileSize, y * tileSize);*/
                        borders.Add(new GraphicalObject("TileBorder", new Vector2(x * tileSize, y * tileSize), Content));
                        index++;
                    }
                }
            }
            catch
            {
                //CANONLYCREATEONEWORLD = false;
                //NewWorld(tileSize, worldSize);
            }
        }
        public int GetNumber(int index)
        {
            return Int32.Parse(collisionNumber[index].Texts);
        }
        public void SetNumber(int number, int index)
        {
            collisionNumber[index].Texts = number.ToString();
        }
        public Tile GetTile(int currentLayer, int index)
        {
            return tileLists[currentLayer][index];
        }
        public void SetTile(Tile newTile, int index, int currentLayer)
        {            
            tileLists[currentLayer][index].sheetPoint = newTile.sheetPoint;
        }

        public void Draw(SpriteBatch spriteBatch, int currentLayer)
        {
            foreach (List<Tile> list in tileLists)
            {
                if (currentLayer >= tileLists.IndexOf(list)) 
                {
                    foreach (Tile tile in list)
                    {
                        tile.Draw(spriteBatch, tileSheet);
                    }
                }
            }
            
            /*foreach (GraphicalObject border in borders)
            {
                border.Draw(spriteBatch);
            }*/

            if (currentLayer == 3)
            {
                foreach (Text number in collisionNumber)
                {
                    if (number.Texts.ToString() != "0")
                    {
                        number.Draw(spriteBatch);
                    }
                }
            }
        }
    }
}