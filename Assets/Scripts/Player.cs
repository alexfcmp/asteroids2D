using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Player : MonoBehaviour
    {
        [SerializeField] readonly int speed;
        [SerializeField] readonly int force;

        [SerializeField] Rigidbody2D prefabBullet;
        [SerializeField] Transform barrel;

        [SerializeField] int hp;

        PlayerMovement playerMovement;

        void Start()
        {
            playerMovement = new PlayerMovement(speed, transform);
        }
        void Update()
        {
            playerMovement.Move(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, Time.deltaTime);

            if (Input.GetButtonDown("Fire1"))
            {
                var ammo = Instantiate(prefabBullet, barrel.position, barrel.rotation);
                ammo.AddForce(barrel.up * force);
            }
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (hp > 0)
            {
                hp--;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}