using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] int speed;
        [SerializeField] int force;

        [SerializeField] Rigidbody2D prefabBullet;
        [SerializeField] Transform barrel;
        Rigidbody2D playerRigidbody;

        [SerializeField] Health health { get; set; }

        PlayerMovement playerMovement;

        PlayerRotation playerRotation;
        Camera cameraP;

        void Start()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            cameraP = Camera.main;
            health = new Health(3);
            playerMovement = new PlayerMovement(speed, playerRigidbody);
            playerRotation = new PlayerRotation(transform);
        }
        void Update()
        {
            var direction = Input.mousePosition - cameraP.WorldToScreenPoint(transform.position);
            playerRotation.Rotate(direction);

            playerMovement.Move(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, Time.deltaTime);

            if (Input.GetButtonDown("Fire1"))
            {
                var ammo = Instantiate(prefabBullet, barrel.position, barrel.rotation);
                ammo.AddForce(barrel.up * force);
            }
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                if (health.Current > 1)
                {
                    health.Current--;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}