using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class PlayerRotation : IRotate
    {
        readonly Transform transform;

        public PlayerRotation(Transform transform)
        {
            this.transform = transform;
        }

        public void Rotate(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}