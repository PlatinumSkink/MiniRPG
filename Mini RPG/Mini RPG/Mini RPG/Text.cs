using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mini_RPG
{
    class Text : Position
    {
        string text;
        SpriteFont font;
        Color color;

        public Text(string _font, string _text, Color _color, Vector2 _position)
            : base(_position)
        {
            text = _text;
            Load(_font);
            color = _color;
        }

        public void Load(string fontName)
        {
            font = Core.Content.Load<SpriteFont>("Fonts/" + fontName);
        }

        public string Texts
        {
            get { return text; }
            set { text = value; }
        }

        public Color Colors
        {
            get { return color; }
            set { color = value; }
        }

        public Rectangle ButtonRectangle()
        {
            return new Rectangle(80, 30, (int)X, (int)Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, Pos, color);
        }
    }
}
