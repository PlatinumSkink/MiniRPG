using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Mini_RPG
{
    [Serializable]
    abstract class Position
    {
        public static ContentManager content;

        Vector2 position;

        public virtual float X
        {
            get { return position.X; }
            set { position.X = value; }
        }
        public virtual float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
        public Vector2 Pos
        {
            get { return position; }
            set { position = value; }
        }

        public Position(Vector2 _position)
        {
            position = _position;
        }
    }
}
