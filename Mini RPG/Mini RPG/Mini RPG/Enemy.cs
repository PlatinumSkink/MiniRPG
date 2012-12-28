using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mini_RPG
{
    class Enemy : LivingObject
    {
        enum EnemyState { chase, stationary, damaged }
        EnemyState enemyState = EnemyState.chase;
        public Enemy(string _Name, Point _sheetSize, string _textureName, Vector2 _position, float _speed)
            : base(_Name, _sheetSize, _textureName, _position, _speed)
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
        public void AdjustDirection(Vector2 playerLocation, Vector2 CameraOffset)
        {
            switch (enemyState)
            {
                case EnemyState.chase:
                    Vector2 distance = new Vector2(playerLocation.X - X/* - CameraOffset.X*/, playerLocation.Y - Y/* - CameraOffset.Y*/);
                    rotation = (float)Math.Atan2(distance.Y, distance.X);
                    break;
                case EnemyState.stationary:
                    break;
                case EnemyState.damaged:
                    break;
                default:
                    break;
            }
        }
    }
}
