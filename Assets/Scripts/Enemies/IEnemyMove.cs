using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IEnemyMove
    {
        int Speed { get; set; }

        void Move(Vector3 startPosition, Vector3 endPosition);
    }
}