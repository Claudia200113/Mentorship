using A2;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using UnityEngine;

    /*Manages the health of the GO that has the script. 
     * Has three main methods: 
     * 1.TakeDamage (recieves a int) -> Will rest health and check if the player is alive or death, in case it dies calls DeathFromDamage
     * 2. DeathFromDamage -> Destroys the game object
     * 3. GainHealth (recieves a int) -> Adds health to the current HP.
     */
    public class Health : MonoBehaviour
    {
        public bool DEBUG;

        public float currentHp;
        public float timeDamageArt = .3f;
        public float maxHp = 100f;
        private float counterDamage = 0;
        private bool damageTaken = false;
        [HideInInspector]
        private bool dead = false;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            //Gets the components in the GO
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        //Sets the current health to the max health everytime the game runs
        void Start()
        {
            currentHp = maxHp;
        }
        //Updates the damage art
        private void Update()
        {
            UpdateDamageArt();
        }

        //The object will take damage, set the art and substract the damage taken from the curren HP. Returns a bool.
        public bool TakeDamage(float damage)
        {
            currentHp -= damage;
            counterDamage = 0;
            //Setting this true calls UpdateDamageArt() so GO color is set to red
            damageTaken = true;

            //After taking damage will check if GO is alive
            if (currentHp > 0)
            {
                if (DEBUG)
                {
                    Debug.Log("HEALTH: " + gameObject.name + " was damaged, life now at " + currentHp);
                }

                dead = false;

            }
            else if (currentHp <= 0) //If health goes less than 0, DeathFromDamage is called 
            {
                if (DEBUG)
                {
                    Debug.Log("HEALTH:" + gameObject.name + " no life points left, calling DeathFromDamage()");
                }

                dead = true;
                DeathFromDamage();
            }
            //Returns the flag
            return dead;
        }

        //If health reaches 0, GO is deactivated.
        private void DeathFromDamage()
        {
            gameObject.SetActive(false);
            if (DEBUG)
            {
                Debug.Log("HEALTH: " + gameObject.name + " died from damage, gameObject deactivated");
            }
        }

        //Adds health to currentHP with a maximum of 100
        public void GainHealth(int health)
        {
            //If health is grater than 100 no health is added
            if (currentHp > 100)
            {
                if (DEBUG)
                {
                    Debug.Log("HEALTH:" + gameObject.name + " health´s is 100, can't add more");
                }
            }//If health is less than 100, extra helath is added
            else if (currentHp < 100)
            {
                currentHp += health;
                if (DEBUG)
                {
                    Debug.Log("HEALTH:" + gameObject.name + " gained " + health + ", now health is at: " + currentHp);
                }
            }
        }

        //Updates the art of the object that recieves damage
        private void UpdateDamageArt()
        {
            //Activates when damage is taken
            if (damageTaken)
            {
                spriteRenderer.color = Color.red;
                //Starts counting
                counterDamage += Time.deltaTime;

                //Compares to see is set time has passed (timeDamageArt represents how much time the sprite will be in red)
                if (counterDamage > timeDamageArt)
                {
                    spriteRenderer.color = Color.white;
                    damageTaken = false;
                }
            }
        }
    }

