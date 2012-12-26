using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
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
        List<Shot> projectiles = new List<Shot>();

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

        Vector2 playerLastPos = Vector2.Zero;

        bool EnemiesAppeared = false;

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
            player.LastPos = player.Pos;
            foreach (Enemy enemy in enemies)
            {
                enemy.LastPos = enemy.Pos;
            }
            player.Update(gameTime);
            player.AdjustDirection(new Vector2(camera.X, camera.Y));
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
            foreach (Enemy enemy in enemies)
            {
                enemy.Hunt(player.Pos);
                enemy.AdjustDirection(player.Pos, camera.Position);
                //enemy.Update(gameTime);                
            }
            foreach (Shot shot in projectiles)
            {
                shot.Update(gameTime);
            }
            TileCollisionCheck(player, gameTime);
            EnemiesAppeared = false;
            foreach (Enemy enemy in enemies)
            {
                TileCollisionCheck(enemy, gameTime);
                if (EnemiesAppeared == true)
                {
                    return;
                }
            }
            
            camera.X = player.X;
            camera.Y = player.Y;
            KeyboardCheck();
            MouseCheck();

            EnemyCollisionCheck(player);
        }
        public void TileCollisionCheck(AnimatedObject mo, GameTime gameTime)
        {
            bool goX = true;
            bool collided = false;
            bool goY = true;
            //int tileCollidedWith = tileManager.collisionTiles.IndexOf(tileManager.CollisionCheck(mo, CollisionTile));
            //Tile collidedTile = tileManager.CollisionCheck(mo, CollisionTile);

            int playerStandingOnThisTile = (int)(((int)((mo.Y + mo.origin.Y) / 32) * 50) + ((mo.X + mo.origin.X) / 32));
            

            List<Tile> CloseTiles = new List<Tile>();

            CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile]);
            CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile + 1]);
            CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile - 1]);
            CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile + (int)worldSize.X - 1]);
            CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile + (int)worldSize.X]);
            CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile + (int)worldSize.X + 1]);
            CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile - (int)worldSize.X - 1]);
            CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile - (int)worldSize.X]);
            CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile - (int)worldSize.X + 1]);

            //foreach (Tile tile in tileManager.collisionTiles)
            foreach (Tile tile in CloseTiles)
            {
                Tile collidedTile = null;

                if (mo.GhostX.Collider().Intersects(tile.CollisionRectangle()) && tile.sheetPoint == CollisionTile)
                {
                    goX = false;
                    collided = true;
                }
                if (mo.GhostY.Collider().Intersects(tile.CollisionRectangle()) && tile.sheetPoint == CollisionTile)
                {
                    goY = false;
                    collided = true;
                }
                if (mo.CollisionRectangle().Intersects(tile.CollisionRectangle()) && tile.sheetPoint == TriggerTile)
                {
                    Trigger(tileManager.GetNumber(tileManager.collisionTiles.IndexOf(tile)));
                }
            }
            if (goX == true)
            {
                mo.UpdateX(gameTime, true);
            }
            else if (collided == true)
            {
                mo.UpdateX(gameTime, false);
            }
            if (goY == true)
            {
                mo.UpdateY(gameTime, true);
            }
            else if (collided == true)
            {
                mo.UpdateY(gameTime, false);
            }
        }

        public void EnemyCollisionCheck(AnimatedObject mo)
        {
            Enemy enemyHit = GetEnemyCollision(mo);
            if (enemyHit != null) 
            {

            }
        }

        public Enemy GetEnemyCollision(AnimatedObject mo)
        {
            foreach (Enemy enemy in enemies)
            {
                if (mo.CollisionRectangle().Intersects(enemy.CollisionRectangle()))
                {
                    return enemy;
                }
            }
            return null;
        }

        public void PauseUpdate(GameTime gameTime)
        {

        }
        public void Trigger(int triggerNumber)
        {
            foreach(Tile tile in tileManager.collisionTiles) 
            {
                if (tile.sheetPoint == EnemyTile && tileManager.GetNumber(tileManager.collisionTiles.IndexOf(tile)) == triggerNumber) 
                {
                    EnemiesAppeared = true;
                    enemies.Add(new Enemy(new Point(1, 1), "Monster1", tile.Pos, 2f));
                    enemies[enemies.IndexOf(enemies.Last<Enemy>())].AddGhosts();
                    tile.sheetPoint = Point.Zero;
                }
                if (tile.sheetPoint == EffectTile)
                {

                }
            }
        }
        public void KeyboardCheck()
        {
            KeyboardManager km = new KeyboardManager();
            if (km.CheckKeyState(Keys.L)) 
            {
                //6tileManager.LoadWorld();
            }
        }
        public void MouseCheck()
        {
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
            {
                projectiles.Add(new Shot(new Point(1, 1), "Shot3", player.Pos, 5f, player.rotation));
                projectiles.Last<Shot>().AddGhosts();
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
                player = new Player("Soldier", Start.Pos + Start.origin, 5);
                player.AddGhosts();
                //enemies.Add(new Enemy(new Point(1, 1), "Enem", Start.Pos + Start.origin, 0.5f));
                //enemies[0].AddGhosts();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            tileManager.Draw(spriteBatch, 2);
            //player.DrawGhosts(spriteBatch);
            player.Draw(spriteBatch);
            foreach (Enemy enemy in enemies)
            {
                //enemy.DrawGhosts(spriteBatch);
                enemy.Draw(spriteBatch);
            }
            foreach (Shot shot in projectiles)
            {
                shot.Draw(spriteBatch);
            }
        }
        public void UIDraw(SpriteBatch spriteBatch)
        {
            ui.GameDraw(spriteBatch);
        }
    }
}
