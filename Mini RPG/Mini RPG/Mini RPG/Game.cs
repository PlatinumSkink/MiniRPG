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
        List<Enemy> enemies = new List<Enemy>();

        Point Red = new Point(9, 5);
        Point Blue = new Point(10, 5);
        Point Pink = new Point(11, 5);
        Point Green = new Point(9, 6);
        Point Yellow = new Point(10, 6);
        Point Orange = new Point(11, 6);
        Point Cyan = new Point(9, 7);
        Point Purple = new Point(10, 7);
        Point Brown = new Point(11, 7);

        Point CollisionTile;
        Point StartTile;
        Point TriggerTile;
        Point GoalTile;
        Point MiscleanousTile;
        Point EffectTile;
        Point InteractTile;
        Point EnemyTile;
        Point ItemTile;

        public Game(int _tileSize, Vector2 _worldSize, Viewport viewport, UI _ui)
        {
            CollisionTile = Red;
            StartTile = Blue;
            TriggerTile = Pink;
            GoalTile = Green;
            MiscleanousTile = Yellow;
            EffectTile = Orange;
            InteractTile = Cyan;
            EnemyTile = Purple;
            ItemTile = Brown;

            tileSize = _tileSize;
            worldSize = _worldSize;
            camera = new Camera(viewport, new Rectangle(0, 0, (int)worldSize.X * tileSize, (int)worldSize.Y * tileSize));
            tileManager = new GameTileManager(tileSize);
            tileManager.NewWorld(tileSize, new Vector2(worldSize.X, worldSize.Y));
            km = new KeyboardManager();

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
            Vector2 playerLastPos = player.Pos;
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
            /*if (tileManager.CheckCollisionX(player, new Point(9, 5)))
            {
                player.X = playerLastPos.X;
            }
            if (tileManager.CheckCollisionY(player, new Point(9, 5)))
            {
                player.Y = playerLastPos.Y;
            }*/
            Tile collidedTile = tileManager.CollisionCheck(player, CollisionTile);
            if (collidedTile != null)
            {
                if (player.X > collidedTile.Y - Tile.tileSize) 
                {
                    player.X = collidedTile.X - Tile.tileSize;
                    player.X = playerLastPos.X;
                }
                else if (player.X < collidedTile.Y + Tile.tileSize) 
                {
                    player.X = collidedTile.X + Tile.tileSize;
                    player.X = playerLastPos.X;
                }
                if (player.Y > collidedTile.X - Tile.tileSize)
                {
                    player.Y = collidedTile.Y - Tile.tileSize;
                    player.Y = playerLastPos.Y;
                }
                else if (player.Y < collidedTile.X + Tile.tileSize)
                {
                    player.Y = collidedTile.Y + Tile.tileSize;
                    player.Y = playerLastPos.Y;
                }
            }
            foreach (Enemy enemy in enemies)
            {
                enemy.Hunt(player.Pos);
                enemy.Update(gameTime);                
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
        public void SetPlayer()
        {
            Tile Start = tileManager.TileGetByColor(StartTile);
            if (Start != null)
            {
                player = new Player("Gubb", Start.Pos + Start.origin, 5);
                enemies.Add(new Enemy(new Point(1, 1), "Enem", Start.Pos + Start.origin, 0.02f));
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            tileManager.Draw(spriteBatch, 2);
            player.Draw(spriteBatch);
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
        public void UIDraw(SpriteBatch spriteBatch)
        {
            ui.GameDraw(spriteBatch);
        }
    }
}
