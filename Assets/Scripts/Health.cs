using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class Health 
    {
        internal int Max { get; set; }
        internal int Current { get; set; }

        public Health(int max)
        {
            Max = max;
            Current = max;
        }
    }
}