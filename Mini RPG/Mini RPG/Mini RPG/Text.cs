using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mini_RPG
{
    class Text : Position
    {
        string text;
        SpriteFont font;
        Color color;

        public Text(string _font, string _text, Color _color, Vector2 _position, ContentManager Content)
            : base(_position)
        {
            text = _text;
            Load(_font, Content);
            color = _color;
        }

        public void Load(string fontName, ContentManager Content)
        {
            font = Content.Load<SpriteFont>("Fonts/" + fontName);
        }

        public string Texts
        {
            get { return text; }
            set { text = value; }
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.DrawString(font, text, Pos, color);
        }
    }
}
