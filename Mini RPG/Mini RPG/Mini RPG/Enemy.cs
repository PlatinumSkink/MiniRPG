using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mini_RPG
{
    class Enemy : AnimatedObject
    {
        enum EnemyState { chase, stationary, damaged }
        EnemyState enemyState = EnemyState.chase;
        public Enemy(Point _sheetSize, string _textureName, Vector2 _position, float _speed)
            : base(_sheetSize, _textureName, _position, _speed)
        {

        }
        public override void Update(GameTime gameTime)
        {
            switch (enemyState)
            {
                case EnemyState.chase:
                    base.Update(gameTime);
                    break;
                case EnemyState.stationary:
                    break;
                case EnemyState.damaged:
                    break;
                default:
                    break;
            }
        }
        public void Hunt(Vector2 target)
        {
            Direction = (target - Pos);
        }
    }
}
