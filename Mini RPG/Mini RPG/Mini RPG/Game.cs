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

        Timer ShotTimer = new Timer(1000 / Core.ShotsPerSecond, false);
        bool CanShot = true;

        public Game(int _tileSize, Vector2 _worldSize, Viewport viewport, UI _ui, ContentManager Content)
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
            tileManager = new GameTileManager(tileSize, Content);
            tileManager.NewWorld(tileSize, new Vector2(worldSize.X, worldSize.Y), Content);
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
        public void Update(GameTime gameTime, ContentManager Content)
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
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(gameTime);
                TileCollisionCheck(projectiles[i], gameTime, Content);
            }
            for (int i = 0; i < projectiles.Count; i++)
            {
                EnemyCollisionCheck(projectiles[i]);
            }
            TileCollisionCheck(player, gameTime, Content);
            EnemiesAppeared = false;
            foreach (Enemy enemy in enemies)
            {
                TileCollisionCheck(enemy, gameTime, Content);
                if (EnemiesAppeared == true)
                {
                    return;
                }
            }
            
            camera.X = player.X;
            camera.Y = player.Y;

            if (ShotTimer.Update(gameTime))
            {
                CanShot = true;
            }

            KeyboardCheck();
            MouseCheck(Content);

            EnemyCollisionCheck(player);
        }
        public void TileCollisionCheck(AnimatedObject mo, GameTime gameTime, ContentManager Content)
        {
            bool goX = true;
            bool collided = false;
            bool goY = true;
            //int tileCollidedWith = tileManager.collisionTiles.IndexOf(tileManager.CollisionCheck(mo, CollisionTile));
            //Tile collidedTile = tileManager.CollisionCheck(mo, CollisionTile);

            int playerStandingOnThisTile = (int)(((int)((mo.Y + mo.origin.Y) / 32) * 50) + ((mo.X + mo.origin.X) / 32));
            

            List<Tile> CloseTiles = new List<Tile>();
            if ((mo.X < 1 || mo.Y < 1 || mo.X > worldSize.X * Tile.tileSize || mo.Y > worldSize.Y * Tile.tileSize) && mo is Shot)
            {
                projectiles.Remove((Shot)mo);
                return;
            }
            
            CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile]);
            if (mo.X < Tile.tileSize * worldSize.X - 1)
            {
                CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile + 1]);
            }
            if (mo.X > Tile.tileSize)
            {
                CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile - 1]);
            }
            if (playerStandingOnThisTile < worldSize.X * worldSize.Y - worldSize.X)
            {
                if (mo.X > Tile.tileSize)
                {
                    CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile + (int)worldSize.X - 1]);
                }
                CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile + (int)worldSize.X]);
                if (mo.X < Tile.tileSize * worldSize.X - 1)
                {
                    CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile + (int)worldSize.X + 1]);
                }
            }
            if (playerStandingOnThisTile > worldSize.X)
            {
                if (mo.X > Tile.tileSize)
                {
                    CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile - (int)worldSize.X - 1]);
                }
                CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile - (int)worldSize.X]);
                if (mo.X < Tile.tileSize * worldSize.X - 1)
                {
                    CloseTiles.Add(tileManager.collisionTiles[playerStandingOnThisTile - (int)worldSize.X + 1]);
                }
            }

            //foreach (Tile tile in tileManager.collisionTiles)

            if (mo is Shot)
            {
                foreach (Tile tile in CloseTiles)
                {
                    if (mo.CollisionRectangle().Intersects(tile.CollisionRectangleForShots()) && tile.sheetPoint == CollisionTile)
                    {
                        projectiles.Remove((Shot)mo);
                        return;
                    }
                }
            }

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
                if (goX == true || goY == true)
                {
                    
                }
                if (mo.CollisionRectangle().Intersects(tile.CollisionRectangle()) && tile.sheetPoint == TriggerTile && mo is Player)
                {
                    Trigger(tileManager.GetNumber(tileManager.collisionTiles.IndexOf(tile)), Content);
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
                if (mo is Shot)
                {
                    Shot shot = (Shot)mo;
                    if (enemyHit.Damage(shot.stats.Strength)) 
                    {
                        enemies.Remove(enemyHit);
                    }
                    projectiles.Remove((Shot)mo);
                }
            }
        }

        public Enemy GetEnemyCollision(AnimatedObject mo)
        {
            foreach (Enemy enemy in enemies)
            {
                if (mo.CollisionRectangle().Intersects(enemy.CollisionRectangleForShots()))
                {
                    return enemy;
                }
            }
            return null;
        }

        public void PauseUpdate(GameTime gameTime)
        {

        }
        public void Trigger(int triggerNumber, ContentManager Content)
        {
            foreach(Tile tile in tileManager.collisionTiles) 
            {
                if (tile.sheetPoint == EnemyTile && tileManager.GetNumber(tileManager.collisionTiles.IndexOf(tile)) == triggerNumber) 
                {
                    EnemiesAppeared = true;
                    enemies.Add(new Enemy("Enemy", new Point(1, 1), "Monster1", tile.Pos, 2f, Content));
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
        public void MouseCheck(ContentManager Content)
        {
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed && CanShot == true)
            {
                CanShot = false;
                ShotTimer.active = true;
                projectiles.Add(new Shot(new Point(1, 1), "Shot3", player.Pos - player.origin / 2, 5f, player.rotation, Content));
                projectiles.Last<Shot>().AddGhosts();
            }
        }
        public void Load(string mapName, ContentManager Content)
        {
            tileManager.LoadWorld(mapName, Content);
        }
        public void SetPlayer(ContentManager Content)
        {
            Tile Start = tileManager.TileGetByColor(StartTile);
            if (Start != null)
            {
                player = new Player("Player", "Soldier", Start.Pos + Start.origin, 5, Content);
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
