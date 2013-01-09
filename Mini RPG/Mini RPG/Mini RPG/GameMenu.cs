using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mini_RPG
{
    class GameMenu : GraphicalObject
    {
        bool visible = false;

        bool ColorChecker = true;
        bool OneBlue = false;

        public List<Text> MenuChoices = new List<Text>();

        public GameMenu(string _textureName, Vector2 _position)
            : base(_textureName, _position)
        {
            MenuChoices.Add(new Text("SegoeUIMono", "Overview", Color.White, Vector2.Zero));
            MenuChoices.Add(new Text("SegoeUIMono", "Status", Color.White, Vector2.Zero));
            MenuChoices.Add(new Text("SegoeUIMono", "Inventory", Color.White, Vector2.Zero));
            MenuChoices.Add(new Text("SegoeUIMono", "Options", Color.White, Vector2.Zero));
            MenuChoices.Add(new Text("SegoeUIMono", "Exit Game", Color.White, Vector2.Zero));
            for (int i = 0; i < MenuChoices.Count; i++)
            {
                MenuChoices[i].Y = Y + 60 + 40 * i;
                MenuChoices[i].X = X + 80;
            }
        }
        public void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            Point mousePosition = new Point(ms.X, ms.Y);
            for (int i = 0; i < MenuChoices.Count; i++)
            {
                if (MenuChoices[i].ButtonRectangle().Contains(mousePosition) && OneBlue == false)
                {
                    MenuChoices[i].Colors = Color.Blue;
                    OneBlue = true;
                }
                else
                {
                    MenuChoices[i].Colors = Color.White;
                }
            }
            OneBlue = false;
        }
        public void SwitchVisibility()
        {
            if (visible == true)
            {
                visible = false;
            }
            else if (visible == false)
            {
                visible = true;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (visible == true)
            {
                base.Draw(spriteBatch);
                foreach (Text text in MenuChoices)
                {
                    text.Draw(spriteBatch);
                }
            }
        }
    }
}
