using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mini_RPG
{
    [Serializable]
    class GraphicalObject : Position
    {
        protected Texture2D texture;

        public virtual int Width
        {
            get { return texture.Width; }
        }
        public virtual int Height
        {
            get { return texture.Height; }
        }

        public GraphicalObject(string _textureName, Vector2 _position, ContentManager Content)
            : base(_position)
        {
            Load(_textureName, Content);
        }

        public void Load(string textureName, ContentManager Content) 
        {
            texture = Content.Load<Texture2D>("Graphics/" + textureName);
        }

        public virtual Rectangle CollisionRectangle()
        {
            return new Rectangle((int)X, (int)Y, Width, Height);
        }

        public virtual void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, CollisionRectangle(), Color.White);
        }
    }
}
