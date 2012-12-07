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
    class Editor
    {
        TileManager tileManager;
        KeyboardManager km;
        public UI ui;

        Point mousePosition;

        public bool StartingUp = false;

        public Camera camera;

        public int tileSize { get; set; }
        public Vector2 worldSize { get; set; }

        public int currentLayer = 1;

        bool pressedAlready = false;

        bool inputting = false;
        bool loading = false;

        public Editor(int _tileSize, Vector2 _worldSize, Viewport viewport, UI _ui)
        {
            tileSize = _tileSize;
            worldSize = _worldSize;
            camera = new Camera(viewport, new Rectangle(0, 0, (int)worldSize.X * tileSize, (int)worldSize.Y * tileSize));
            tileManager = new TileManager(tileSize);
            tileManager.NewWorld(tileSize, new Vector2(worldSize.X, worldSize.Y));
            km = new KeyboardManager();
            

            ui = _ui;
            ui.SetTileSheet(tileManager.GetTileSheet());
            ui.EditorUI();
        }
        public TileSheet GetTileSheet()
        {
            return tileManager.GetTileSheet();
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

            if (km.CheckKeyState(Keys.Escape))
            {
                
            }

            bool draw = true;
            ui.EditorUpdate(gameTime, currentLayer);

            if (ms.LeftButton == ButtonState.Pressed && ui.tileArsenal.dragging == false && ui.ChangedTile == false && draw == true)
            {
                for (int i = 0; i < worldSize.X * worldSize.Y; i++)
                {
                    if (tileManager.GetTile(currentLayer, i).CollisionRectangle().Contains(mousePosition) && tileManager.GetTile(currentLayer, i).sheetPoint != ui.tileOfChoice.sheetPoint)
                    {
                        tileManager.SetTile(ui.tileOfChoice, i, currentLayer);
                    }
                    else if (tileManager.GetTile(currentLayer, i).CollisionRectangle().Contains(mousePosition) && currentLayer == 3 && pressedAlready == false) 
                    {
                        
                        if (km.CheckKeyState(Keys.Back))
                        {
                            tileManager.SetNumber(tileManager.GetNumber(i) - 1, i);
                        }
                        else
                        {
                            tileManager.SetNumber(tileManager.GetNumber(i) + 1, i);
                        }
                    }
                }
                pressedAlready = true;
            }
            else if (ms.LeftButton == ButtonState.Released)
            {
                pressedAlready = false;
            }
            if (inputting == true || loading == true)
            {
                ui.Input();
            }

            if (km.CheckKeyState(Keys.N) && inputting == false && loading == false)
            {
                tileManager.NewWorld(tileSize, new Vector2(50, 50));
            }
            if (km.CheckKeyState(Keys.S) && loading == false || ui.saveButton.IsPressed(mousePosition) && loading == false)
            {
                inputting = true;
            }
            if (km.CheckKeyState(Keys.Delete))
            {
                inputting = false;
                loading = false;
                ui.inputedName = "";
            }
            if (km.CheckKeyState(Keys.Enter) && inputting == true)
            {
                tileManager.SaveWorld(ui.inputedName);
                ui.inputedName = "";
                inputting = false;
            }
            else if (km.CheckKeyState(Keys.Enter) && loading == true)
            {
                tileManager.LoadWorld(ui.inputedName);
                ui.inputedName = "";
                loading = false;
            }
            if (km.CheckKeyState(Keys.L) && inputting == false || ui.loadButton.IsPressed(mousePosition) && inputting == false)
            {
                loading = true;
            }
            if (loading == false && inputting == false)
            {
                if (km.CheckKeyState(Keys.D4))
                {
                    currentLayer = 3;
                }
                if (km.CheckKeyState(Keys.D1))
                {
                    currentLayer = 0;
                }
                else if (km.CheckKeyState(Keys.D2))
                {
                    currentLayer = 1;
                }
                else if (km.CheckKeyState(Keys.D3))
                {
                    currentLayer = 2;
                }
                if (km.CheckKeyState(Keys.Up))
                {
                    camera.Y -= 5;
                }
                else if (km.CheckKeyState(Keys.Down))
                {
                    camera.Y += 5;
                }
                if (km.CheckKeyState(Keys.Left))
                {
                    camera.X -= 5;
                }
                else if (km.CheckKeyState(Keys.Right))
                {
                    camera.X += 5;
                }
                if (km.CheckKeyState(Keys.OemPlus))
                {
                    camera.Zoom += 0.005f;
                }
                else if (km.CheckKeyState(Keys.OemMinus))
                {
                    camera.Zoom -= 0.005f;
                }
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            tileManager.Draw(spriteBatch, currentLayer);
        }
        public void UIDraw(SpriteBatch spriteBatch)
        {
            ui.EditorDraw(spriteBatch);
            if (inputting == true || loading == true)
            {
                ui.InputDraw(spriteBatch);
            }
        }
    }
}
