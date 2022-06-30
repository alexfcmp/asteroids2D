using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyMovement : IEnemyMove
    {
        public int Speed { get; set; }
        readonly Rigidbody2D rigidbody;

        public EnemyMovement(int speed, Rigidbody2D rigidbody)
        {
            Speed = speed;
            this.rigidbody = rigidbody;
        }

        public void Move(Vector3 startPosition, Vector3 endPosition)
        {
            var direction = (startPosition - endPosition) * Speed;
            Debug.Log(rigidbody);
            rigidbody.AddForce(direction);
        }
    }
}