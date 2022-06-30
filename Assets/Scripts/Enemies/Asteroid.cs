using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : EnemyFactory
    {
        Rigidbody2D asteroidRigidbody;
        public EnemyMovement enemyMovement;

        public Health health;

        internal void InstantiateAsteroid()
        {
            asteroidRigidbody = GetComponent<Rigidbody2D>();
            enemyMovement = new EnemyMovement(100, asteroidRigidbody);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                if (health.Current > 1)
                {
                    health.Current--;
                    Destroy(collision.gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }

        void OnDisable()
        {
            GameStarter.onAsteroidDestroyed.Invoke();
        }
    }
}