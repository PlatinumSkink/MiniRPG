using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Mini_RPG
{
    class Menu : State
    {
        Point mousePosition;

        List<Text> choice = new List<Text>();

        Text game;
        Text edit;
        Text quit;

        public Menu(bool _visible)
            : base(_visible)
        {
            game = new Text("AndyRegular", "Press 1 to play game", Color.White, new Vector2(100, 100));
            edit = new Text("AndyRegular", "Press 2 to start editor", Color.White, new Vector2(100, 150));
            quit = new Text("AndyRegular", "Press 3 to quit game", Color.White, new Vector2(100, 200));
            choice.Add(game);
            choice.Add(edit);
            choice.Add(quit);
        }
        public string Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            mousePosition = new Point(ms.X, ms.Y);

            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.D1))
            {
                return "Game";
            }
            if (ks.IsKeyDown(Keys.D2))
            {
                return "Editor";
            }
            if (ks.IsKeyDown(Keys.D3))
            {
                return "Quit";
            }
            return "None";
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var text in choice)
            {
                text.Draw(spriteBatch);
            }
        }
        public void UIDraw(SpriteBatch spriteBatch)
        {

        }
    }
}
