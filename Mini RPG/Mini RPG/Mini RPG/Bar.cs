using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mini_RPG
{
    class Bar : GraphicalObject
    {
        int MaxContent;
        public int CurrentContent { get; set; }

        public Bar(int _MaxContent, string _textureName, Vector2 _position)
            : base(_textureName, _position)
        {
            MaxContent = _MaxContent;
            CurrentContent = MaxContent;
        }

        public void Update(Vector2 ParentPosition, int ParentHealth)
        {
            CurrentContent = ParentHealth;
            Pos = ParentPosition;
            Y -= Tile.tileSize;
        }

        public Rectangle BarRectangle()
        {
            float WidthDrawnProcentage = (float)CurrentContent / (float)MaxContent;
            return new Rectangle((int)(X - (Width * WidthDrawnProcentage) / 2 - 10), (int)Y, (int)(Width * WidthDrawnProcentage), Height);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, BarRectangle(), Color.White);
        }
    }
}
