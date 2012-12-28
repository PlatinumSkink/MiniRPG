using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Mini_RPG
{
    class Button:GraphicalObject
    {
        Text name;
        public Button(string textureName, Vector2 position, string text, ContentManager Content)
            : base(textureName, position, Content)
        {
            name = new Text("SegoeUIMono", text, Color.White, new Vector2(Pos.X/* + Width / 4*/, Pos.Y/* + Height / 4*/), Content);
        }
        public bool IsPressed(Point point)
        {
            MouseState ms = Mouse.GetState();
            if (CollisionRectangle().Contains(new Point(ms.X, ms.Y)) && ms.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            name.Draw(spriteBatch);
        }
    }
}
