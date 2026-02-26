using A2;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


    [RequireComponent(typeof(Collider2D))]
    public class DamageOnCollision : MonoBehaviour
    {
        public bool DEBUG;

        public int damageToDeal = 10;

        //When colliding the make damage method is called
        private void OnCollisionEnter2D(Collision2D collision)
        {
            MakeDamage(collision);
        }

        //Retrieves the health script in the GO and deals damage to it
        private void MakeDamage(Collision2D collision)
        {
            //Gets the health script in the collision object (if any)
            Health health = collision.gameObject.GetComponentInParent<Health>();

            //If the object does not have a collider a warning is printed
            if (health == null)
            {
                Debug.LogWarning("DAMAGE ON COLLISION: " + collision.gameObject.name + " does not have a health script");
                return;
            }
            else
            {
                //If the collision had a health scripts, deals damage to it
                health.TakeDamage(damageToDeal);
            }

            if (DEBUG)
            {
                Debug.Log("DAMAGE ON COLLISION: Object was hit, will take damage");
            }
        }
    }

