using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public interface IMove
    {
        int Speed { get; set; }

        void Move(float hor, float ver, float deltaTime);
    }
}