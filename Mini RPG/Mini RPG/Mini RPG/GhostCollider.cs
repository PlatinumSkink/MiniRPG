using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mini_RPG
{
    class GhostCollider:Position
    {
        Vector2 size;
        public GhostCollider(Vector2 _size, Vector2 _position)
            : base(_position)
        {
            size = _size;
        }
        public Rectangle Collider()
        {
            return new Rectangle((int)X, (int)Y, (int)size.X, (int)size.Y);
        }
    }
}
