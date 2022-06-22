using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerMovement : IMove
    {
        public int Speed { get; set; }
        Vector3 move;
        readonly Transform transform;

        public PlayerMovement(int speed, Transform transform)
        {
            Speed = speed;
            this.transform = transform;
        }

        public void Move(float hor, float ver, float deltaTime)
        {
            move.Set(hor, ver, 0.0f);
            transform.localPosition += move;
        }
    }
}