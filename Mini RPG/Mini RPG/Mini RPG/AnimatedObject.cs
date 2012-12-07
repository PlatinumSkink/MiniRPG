using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mini_RPG
{
    class AnimatedObject : MovingObject
    {
        Point sheetSize;
        Point spriteSize;
        Point currentSprite = Point.Zero;

        public float rotation { get; set; }
        public Vector2 origin { get; set; }

        public override int Width
        {
            get { return base.Width / sheetSize.X; }
        }
        public override int Height
        {
            get { return base.Height / sheetSize.Y; }
        }
        public override float X
        {
            get { return base.X; }
            set { base.X = value; }
        }
        public override float Y
        {
            get { return base.Y; }
            set { base.Y = value; }
        }

        public AnimatedObject(Point _sheetSize, string _textureName, Vector2 _position, float speed)
            : base(_textureName, _position, speed)
        {
            sheetSize = _sheetSize;
            rotation = 0f;
            origin = new Vector2(Width / 2, Height / 2);
        }

        public override Rectangle CollisionRectangle()
        {
            //return new Rectangle((int)X, (int)Y, spriteSize.X, spriteSize.Y);
            return new Rectangle((int)X, (int)Y, Width, Height);
        }

        public virtual Rectangle SourceRectangle()
        {
            return new Rectangle(currentSprite.X * Width, currentSprite.Y * Height, Width, Height);
        }

        public override void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, CollisionRectangle(), SourceRectangle(), Color.White, rotation, origin, SpriteEffects.None, 0f);
        }
    }
}
