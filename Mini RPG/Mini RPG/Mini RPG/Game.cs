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
            /*if (tileManager.CheckCollisionX(player, new Point(9, 5)))
            {
            //    player.X = playerLastPos.X;
            }
            if (tileManager.CheckCollisionY(player, new Point(9, 5)))
            {
              //  player.Y = playerLastPos.Y;
            }*/
            foreach (Enemy enemy in enemies)
            {
                enemy.Hunt(player.Pos);
                enemy.AdjustDirection(player.Pos, camera.Position);
                //enemy.Update(gameTime);                
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
                    /*if (mo.X > tile.X)
                    {
                        //mo.X -= mo.X - (tile.X + Tile.tileSize);
                        mo.X = tile.X + Tile.tileSize;
                    }
                    else
                    {
                        //mo.X -= tile.X - (mo.X + mo.Width);
                        mo.X = tile.X - mo.Width;
                    }*/
                    collided = true;
                }
                if (mo.GhostY.Collider().Intersects(tile.CollisionRectangle()) && tile.sheetPoint == CollisionTile)
                {
                    goY = false;
                    /*if (mo.Y > tile.Y)
                    {
                        //mo.Y -= mo.Y - (tile.Y + Tile.tileSize);
                        mo.Y = tile.Y + Tile.tileSize;
                    }
                    else
                    {
                        //mo.Y -= tile.Y - (mo.Y + mo.Height);
                        mo.Y = tile.Y - mo.Height;
                    }*/
                    collided = true;
                }
                if (mo.CollisionRectangle().Intersects(tile.CollisionRectangle()) && tile.sheetPoint == TriggerTile)
                {
                    Trigger(tileManager.GetNumber(tileManager.collisionTiles.IndexOf(tile)));
                }
                //player.UpdateY(gameTime);

                /*if ((mo.GhostX.Collider().Intersects(tile.CollisionRectangle()) || mo.GhostX.Collider().Intersects(tile.CollisionRectangle())) && tile.sheetPoint == CollisionTile)
                {
                    collidedTile = tile;
                }*/
                /*if (mo.CollisionRectangle().Intersects(tile.CollisionRectangle()) && tile.sheetPoint == CollisionTile)
                {
                    collidedTile = tile;
                }

                if (collidedTile != null)
                {
                    int playerStandingOnThisTile = (int)(((int)((mo.Y + mo.origin.Y) / 32) * 50) + ((mo.X + mo.origin.X) / 32));
                    Console.WriteLine(playerStandingOnThisTile);
                    float rightSide = collidedTile.X + Tile.tileSize;
                    float leftSide = collidedTile.X;
                    float topSide = collidedTile.Y;
                    float bottomSide = collidedTile.Y + Tile.tileSize;*/

                    /*if (collidedTile.CollisionRectangle().Intersects(mo.GhostX.Collider())) 
                    {
                        //mo.X = mo.GhostX.X - player.Direction.X * player.speed;
                        mo.X -= player.Direction.X * player.speed;
                    }
                    if (collidedTile.CollisionRectangle().Intersects(mo.GhostY.Collider()))
                    {
                        //mo.Y = mo.GhostY.Y - player.Direction.Y * player.speed;
                        mo.Y -= player.Direction.Y * player.speed;
                    }*/

                    //Tiles[i].location -= Party.going;
                        /*if (collidedTile.X > player.X && player.Direction.X > 0)
                        {
                            player.X -= player.Direction.X * player.speed;
                        }
                        else if (collidedTile.X < player.X && player.Direction.X < 0)
                        {
                            player.X -= player.Direction.X * player.speed;
                        }
                        if (collidedTile.Y > player.Y && player.Direction.Y > 0)
                        {
                            player.Y -= player.Direction.Y * player.speed;
                        }
                        else if (collidedTile.Y < player.Y && player.Direction.Y < 0)
                        {
                            player.Y -= player.Direction.Y * player.speed;
                        }*/
                    

                    /*Tiles[i].location -= Party.going;
                    if (Party.box().Intersects(Tiles[i].box()) && Tiles[i].collision == 1)
                    {
                        if (Tiles[i].location.X > Party.location.X && Party.going.X > 0)
                        {
                            for (int j = 0; j < TileCount; j++)
                            {
                                //Tiles[j].location.Y -= Party.going.Y;
                                Tiles[j].location.X += Party.going.X;
                            }
                            if (AreaMap == true)
                            {
                                for (int j = 0; j < buildingCounter; j++)
                                {
                                    building[j].location.X += Party.going.X;
                                }
                                for (int j = 0; j < NPCCounter; j++)
                                {
                                    NPCs[j].location.X += Party.going.X;
                                }
                            }
                            Party.place.X -= Party.going.X;
                        }
                        else if (Tiles[i].location.X < Party.location.X && Party.going.X < 0)
                        {
                            for (int j = 0; j < TileCount; j++)
                            {
                                //Tiles[j].location.Y -= Party.going.Y;
                                Tiles[j].location.X += Party.going.X;
                            }
                            if (AreaMap == true)
                            {
                                for (int j = 0; j < buildingCounter; j++)
                                {
                                    building[j].location.X += Party.going.X;
                                }
                                for (int j = 0; j < NPCCounter; j++)
                                {
                                    NPCs[j].location.X += Party.going.X;
                                }
                            }
                            Party.place.X -= Party.going.X;
                        }
                        if (Tiles[i].location.Y > Party.location.Y && Party.going.Y > 0)
                        {
                            for (int j = 0; j < TileCount; j++)
                            {
                                //Tiles[j].location.X -= Party.going.X;
                                Tiles[j].location.Y += Party.going.Y;
                            }
                            if (AreaMap == true)
                            {
                                for (int j = 0; j < buildingCounter; j++)
                                {
                                    building[j].location.Y += Party.going.Y;
                                }
                                for (int j = 0; j < NPCCounter; j++)
                                {
                                    NPCs[j].location.Y += Party.going.Y;
                                }
                            }
                            Party.place.Y -= Party.going.Y;
                        }
                        else if (Tiles[i].location.Y < Party.location.Y && Party.going.Y < 0)
                        {
                            for (int j = 0; j < TileCount; j++)
                            {
                                //Tiles[j].location.X -= Party.going.X;
                                Tiles[j].location.Y += Party.going.Y;
                            }
                            if (AreaMap == true)
                            {
                                for (int j = 0; j < buildingCounter; j++)
                                {
                                    building[j].location.Y += Party.going.Y;
                                }
                                for (int j = 0; j < NPCCounter; j++)
                                {
                                    NPCs[j].location.Y += Party.going.Y;
                                }
                            }
                            Party.place.Y -= Party.going.Y;
                        }
                    }*/

                    /*if (collidedTile == tileManager.collisionTiles[playerStandingOnThisTile + 1])
                    {
                        //mo.X -= mo.Direction.X * mo.speed;
                        mo.X = mo.LastPos.X;
                    }
                    if (collidedTile == tileManager.collisionTiles[playerStandingOnThisTile - 1])
                    {
                        //mo.X -= mo.Direction.X * mo.speed;
                        mo.X = mo.LastPos.X;
                    }
                    if (collidedTile == tileManager.collisionTiles[playerStandingOnThisTile + 50])
                    {
                        //mo.Y -= mo.Direction.Y * mo.speed;
                        mo.Y = mo.LastPos.Y;
                    }
                    if (collidedTile == tileManager.collisionTiles[playerStandingOnThisTile - 50])
                    {
                        //mo.Y -= mo.Direction.Y * mo.speed;
                        mo.Y = mo.LastPos.Y;
                    }
                     */

                    /*if (tileManager.collisionTiles[playerStandingOnThisTile + 1].X < mo.X + mo.Width && tileManager.collisionTiles[playerStandingOnThisTile + 1].sheetPoint == CollisionTile) 
                    {
                        mo.X -= mo.Direction.X * mo.speed;
                    }
                    if (tileManager.collisionTiles[playerStandingOnThisTile - 1].X > mo.X && tileManager.collisionTiles[playerStandingOnThisTile - 1].sheetPoint == CollisionTile) 
                    {
                        mo.X -= mo.Direction.X * mo.speed;
                    }
                    if (tileManager.collisionTiles[playerStandingOnThisTile + 50].Y < mo.Y + mo.Height && tileManager.collisionTiles[playerStandingOnThisTile + 50].sheetPoint == CollisionTile) 
                    {
                        mo.Y -= mo.Direction.Y * mo.speed;
                    }
                    if (tileManager.collisionTiles[playerStandingOnThisTile - 50].Y > mo.Y && tileManager.collisionTiles[playerStandingOnThisTile - 50].sheetPoint == CollisionTile) 
                    {
                        mo.Y -= mo.Direction.Y * mo.speed;
                    }*/

                    /*if (mo.X > leftSide - mo.Width && mo.X < rightSide) 
                    {
                        if (mo.Y < topSide)
                        {
                            mo.Y -= mo.Direction.Y * mo.speed;
                            mo.Y = collidedTile.Y - mo.Height;
                        }
                        else if (mo.Y > topSide)
                        {
                            //mo.X -= mo.Direction.X * mo.speed;
                            mo.Y = collidedTile.Y + Tile.tileSize + mo.Height;
                        }
                    }

                    if (mo.Y > topSide - mo.Height && mo.Y < bottomSide)
                    {
                        if (mo.X < leftSide)
                        {
                            //mo.Y -= mo.Direction.Y * mo.speed;
                            mo.X = collidedTile.X - mo.Width;
                        }
                        else if (mo.X > leftSide)
                        {
                            mo.X -= mo.Direction.X * mo.speed;
                            mo.X = collidedTile.X + Tile.tileSize + mo.Width;
                        }
                    }*/

                    /*if (mo.DirectionX != 0)
                    {
                        if (mo.X > collidedTile.X && mo.Y < collidedTile.Y + Tile.tileSize && mo.Y + mo.Height > collidedTile.Y)
                        {
                            //mo.X = collidedTile.X + Tile.tileSize + mo.Width;
                            //mo.X = mo.LastPos.X;
                            mo.X -= mo.Direction.X * mo.speed;
                        }
                        else if (mo.X < collidedTile.X && mo.Y < collidedTile.Y + Tile.tileSize && mo.Y + mo.Height > collidedTile.Y)
                        {
                            //mo.X = collidedTile.X - mo.Width;
                            //mo.X = mo.LastPos.X;
                            mo.X -= mo.Direction.X * mo.speed;
                        }
                    }
                    if (mo.DirectionY != 0)
                    {
                        if (mo.Y > collidedTile.Y && mo.X < collidedTile.X + Tile.tileSize && mo.X + mo.Width > collidedTile.X)
                        {
                            //mo.Y = collidedTile.Y + Tile.tileSize + mo.Height;
                            //mo.X = mo.LastPos.X;
                            mo.Y -= mo.Direction.Y * mo.speed;
                        }
                        else if (mo.Y < collidedTile.Y && mo.X < collidedTile.X + Tile.tileSize && mo.X + mo.Width > collidedTile.X)
                        {
                            //mo.Y = collidedTile.Y - mo.Height;
                            //mo.X = mo.LastPos.X;
                            mo.Y -= mo.Direction.Y * mo.speed;
                        }
                    }*/
                    /*if (player.X > collidedTile.X - Tile.tileSize)
                    {
                        //mo.Y = collidedTile.Y - Tile.tileSize;
                        //mo.Y = mo.LastPos.Y;
                        mo.X -= mo.Direction.X * mo.speed;
                    }
                    else if (player.X < collidedTile.X + Tile.tileSize)
                    {
                        //mo.Y = collidedTile.Y + Tile.tileSize;
                        //mo.Y = mo.LastPos.Y;
                        mo.X -= mo.Direction.X * mo.speed;
                    }
                    if (player.Y > collidedTile.Y - Tile.tileSize)
                    {
                        //mo.Y = collidedTile.Y - Tile.tileSize;
                        //mo.Y = mo.LastPos.Y;
                        mo.Y -= mo.Direction.Y * mo.speed;
                    }
                    else if (player.Y < collidedTile.Y + Tile.tileSize)
                    {
                        //mo.Y = collidedTile.Y + Tile.tileSize;
                        //mo.Y = mo.LastPos.Y;
                        mo.Y -= mo.Direction.Y * mo.speed;
                    }*/
                //}
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
        }
        public void UIDraw(SpriteBatch spriteBatch)
        {
            ui.GameDraw(spriteBatch);
        }
    }
}
