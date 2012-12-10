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
    class Game
    {
        GameTileManager tileManager;
        KeyboardManager km;
        public UI ui;

        Point mousePosition;

        public bool StartingUp = false;

        public Camera camera;

        public int tileSize { get; set; }
        public Vector2 worldSize { get; set; }

        Player player;

        public Game(int _tileSize, Vector2 _worldSize, Viewport viewport, UI _ui)
        {
            tileSize = _tileSize;
            worldSize = _worldSize;
            camera = new Camera(viewport, new Rectangle(0, 0, (int)worldSize.X * tileSize, (int)worldSize.Y * tileSize));
            tileManager = new GameTileManager(tileSize);
            tileManager.NewWorld(tileSize, new Vector2(worldSize.X, worldSize.Y));
            km = new KeyboardManager();

            player = new Player("Gubb", tileManager.GetTile(1, 0).Pos, 5);

            ui = _ui;
            ui.SetTileSheet(tileManager.GetTileSheet());
            ui.GameUI();
        }
        public void MouseToWorld()
        {
            MouseState ms = Mouse.GetState();
            mousePosition = new Point((int)((ms.X + camera.X - camera.Origin.X) / camera.Zoom), (int)((ms.Y + camera.Y - camera.Origin.Y) / camera.Zoom));
        }
        public void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            MouseToWorld();
            ui.GameUpdate(gameTime);
            player.Update(gameTime);
            if (player.X - player.origin.X < 0)
            {
                player.X = player.origin.X;
            }
            if (player.Y - player.origin.Y < 0)
            {
                player.Y = player.origin.Y;
            }
            if (player.X - player.origin.X > worldSize.X * tileSize - player.Width)
            {
                player.X = worldSize.X * tileSize - player.Width + player.origin.X;
            }
            if (player.Y - player.origin.Y > worldSize.Y * tileSize - player.Height)
            {
                player.Y = worldSize.Y * tileSize - player.Height + player.origin.Y;
            }
            camera.X = player.X;
            camera.Y = player.Y;
            KeyboardCheck();
        }
        public void PauseUpdate(GameTime gameTime)
        {

        }
        public void KeyboardCheck()
        {
            KeyboardManager km = new KeyboardManager();
            if (km.CheckKeyState(Keys.L)) 
            {
                //6tileManager.LoadWorld();
            }
        }
        public void Load(string mapName)
        {
            tileManager.LoadWorld(mapName);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            tileManager.Draw(spriteBatch, 2);
            player.Draw(spriteBatch);
        }
        public void UIDraw(SpriteBatch spriteBatch)
        {
            ui.GameDraw(spriteBatch);
        }
    }
}
