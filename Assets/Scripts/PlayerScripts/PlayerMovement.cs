using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class PlayerMovement : IMove
    {
        public int Speed { get; set; }
        Vector2 move;
        readonly Rigidbody2D rigidbody;

        public PlayerMovement(int speed, Rigidbody2D rigidbody)
        {
            Speed = speed;
            this.rigidbody = rigidbody;
        }

        public void Move(float hor, float ver, float deltaTime)
        {
            move.Set(hor * deltaTime, ver * deltaTime);
            rigidbody.AddForce(move);
        }
    }
}