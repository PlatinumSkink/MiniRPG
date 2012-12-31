using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mini_RPG
{
    class UI
    {
        public Tile tileOfChoice { get; private set; }
        //List<Tile> tileArsenal = new List<Tile>();
        int tileSize = 0;
        public Point mousePosition { get ; set; }
        TileSheet tileSheet;
        public Button saveButton;
        public Button loadButton;
        public TileArsenal tileArsenal;

        List<Text> texts = new List<Text>();

        Text InputText;
        public string inputedName;

        int markerTimer = 0;
        int markerLimit = 1000;
        bool showMarker = false;

        bool pressedKey = false;

        public bool ChangedTile = false;

        public UI(int _tileSize)
        {
            tileSize = _tileSize;
        }
        public void Update(GameTime gameTime)
        {
            
        }
        public void GameUI()
        {

        }
        public void EditorUI()
        {
            tileOfChoice = new Tile("Floor", new Point(2, 0), new Vector2(0, 0));
            tileArsenal = new TileArsenal(new Vector2(0, 0), tileSheet, tileSize);

            texts.Add(new Text("SegoeUIMono", "Layer ", Color.White, new Vector2(10, 370)));
            InputText = new Text("SegoeUIMono", "|", Color.White, new Vector2(200, 10));
            saveButton = new Button("Save", new Vector2(200, 40), "SAVE");
            loadButton = new Button("Save", new Vector2(200 + saveButton.Width, 40), "LOAD");
        }
        public void SetTileSheet(TileSheet _tileSheet)
        {
            tileSheet = _tileSheet;
        }

        public void GameUpdate(GameTime gameTime)
        {

        }

        public void EditorUpdate(GameTime gameTime, int currentLayer)
        {
            MouseState ms = Mouse.GetState();
            mousePosition = new Point(ms.X, ms.Y);

            tileArsenal.Update();

            texts[0].Texts = "Layer: " + (currentLayer + 1).ToString();
            if (currentLayer == 3)
            {
                texts[0].Texts = "Layer: Collision Layer";
            }

            markerTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (markerTimer > markerLimit) 
            {
                UpdateText();
                markerTimer = 0;
            }
            

            tileOfChoice.Pos = new Vector2(ms.X, ms.Y);
            LeftMouseButton();
        }
        public void LeftMouseButton()
        {
            MouseState ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
            {
                foreach (var tile in tileArsenal.tileArsenal)
                {
                    if (tile.GraphicalRectangle().Contains(mousePosition))
                    {
                        tileOfChoice = new Tile(tile.Name, tile.sheetPoint, tileOfChoice.Pos);
                        ChangedTile = true;
                        break;
                    }
                }
            }
            else
            {
                ChangedTile = false;
            }
        }
        public void Input()
        {
            KeyboardManager km = new KeyboardManager();
            if (pressedKey == false && Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "Space")
                {
                    inputedName += "_";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "D1")
                {
                    inputedName += "1";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "D2")
                {
                    inputedName += "2";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "D3")
                {
                    inputedName += "3";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "D4")
                {
                    inputedName += "4";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "D5")
                {
                    inputedName += "5";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "D6")
                {
                    inputedName += "6";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "D7")
                {
                    inputedName += "7";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "D8")
                {
                    inputedName += "8";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "D9")
                {
                    inputedName += "9";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "OemPeriod")
                {
                    inputedName += ".";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "OemComma")
                {
                    inputedName += ",";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "OemMinus")
                {
                    inputedName += "-";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "OemPlus")
                {
                    inputedName += "+";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "Right")
                {
                    //inputedName += "";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "Left")
                {
                    //inputedName += "";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "Up")
                {
                    //inputedName += "";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "Enter")
                {
                    //inputedName += "";
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "Back")
                {
                    /*if (inputedName.Length > 0) {
                        inputedName.Remove(0, inputedName.Last<char>());
                    }*/
                    string rememberInput = inputedName;
                    inputedName = "";
                    for (int i = 0; i < rememberInput.Length - 1; i++)
                    {
                        inputedName += rememberInput[i];
                    }
                }
                else if (Keyboard.GetState().GetPressedKeys()[0].ToString() == "Down")
                {
                    //inputedName += "";
                }
                else
                {
                    inputedName += Keyboard.GetState().GetPressedKeys()[0].ToString();
                }
                UpdateText();
                pressedKey = true;
            }
            if (pressedKey == true && Keyboard.GetState().GetPressedKeys().Length <= 0)
            {
                pressedKey = false;
            }
        }
        public void UpdateText()
        {
            if (showMarker == true)
            {
                showMarker = false;
                InputText.Texts = inputedName + "";
            }
            else
            {
                showMarker = true;
                InputText.Texts = inputedName + "|";
            }
        }
        public void InputDraw(SpriteBatch spriteBatch)
        {
            InputText.Draw(spriteBatch);
        }
        public void EditorDraw(SpriteBatch spriteBatch) 
        {
            tileArsenal.Draw(spriteBatch);
            tileOfChoice.DrawSmall(spriteBatch, tileSheet);
            foreach (Text text in texts)
            {
                text.Draw(spriteBatch);
            }
            saveButton.Draw(spriteBatch);
            loadButton.Draw(spriteBatch);
        }
        public void GameDraw(SpriteBatch spriteBatch)
        {

        }
    }
}
