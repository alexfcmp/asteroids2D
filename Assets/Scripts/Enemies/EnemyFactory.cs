using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class EnemyFactory : MonoBehaviour
    {
        public static Asteroid CreateEnemyAsteroid(Health health, Vector2 position)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemies/Asteroid"), position, Quaternion.identity);
            enemy.InstantiateAsteroid();

            enemy.health = health;
            Debug.Log(health);

            return enemy;
        }
        public static Ship CreateEnemyShip(Health health, Vector2 position)
        {
            var enemy = Instantiate(Resources.Load<Ship>("Enemies/Ship"), position, Quaternion.identity);
            enemy.InstantiateShip();

            enemy.health = health;

            return enemy;
        }
    }
}