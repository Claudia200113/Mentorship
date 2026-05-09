using UnityEngine;


//Damages the other object with which it collides.
    public class DamageOnCollision : MonoBehaviour
    {
        public bool DEBUG;

        public int damageToDeal = 10;
        
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
            if (health != null)
            {
                health.TakeDamage(damageToDeal);
            }
        }
    }

