using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Asteroids
{
    public sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] GameObject[] spawners;
        Health asteroidHealth;
        Health shipHeath;
        Vector3 randomPosition { get { return spawners[Random.Range(0, spawners.Length - 1)].transform.position; } set { ;} }

        public static UnityAction onAsteroidDestroyed;
        public static UnityAction onShipDestroyed;

        void Start()
        {
            asteroidHealth = new Health(3);
            shipHeath = new Health(6);

            onAsteroidDestroyed += OnAsteroidDestroy;

            randomPosition = spawners[Random.Range(0, spawners.Length - 1)].transform.position;
            OnAsteroidDestroy();
            OnShipDestroyed();
        }

        void OnAsteroidDestroy()
        {
            var enemy = EnemyFactory.CreateEnemyAsteroid(asteroidHealth, randomPosition);
            enemy.enemyMovement.Move(enemy.transform.position, randomPosition);
        }

        void OnShipDestroyed()
        {
            var enemy = EnemyFactory.CreateEnemyShip(shipHeath, randomPosition);
            enemy.enemyMovement.Move(enemy.transform.position, randomPosition);
        }
    }
}