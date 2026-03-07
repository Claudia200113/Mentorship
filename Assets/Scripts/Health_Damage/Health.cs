using A2;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using UnityEngine;

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
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        void Start()
        {
            currentHp = maxHp;
        }
        private void Update()
        {
            UpdateDamageArt();
        }

        public bool TakeDamage(float damage)
        {
            currentHp -= damage;
            counterDamage = 0;
            damageTaken = true;

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

        private void DeathFromDamage()
        {
            //gameObject.SetActive(false);
            GameManager.Instance.sceneHandler.GoToGameOver();
            if (DEBUG)
            {
                Debug.Log("HEALTH: " + gameObject.name + " died from damage, gameObject deactivated");
            }
        }

        public void GainHealth(int health)
        {
            if (currentHp > 100)
            {
                if (DEBUG)
                {
                    Debug.Log("HEALTH:" + gameObject.name + " health´s is 100, can't add more");
                }
                else if (currentHp < 100)
                {
                    currentHp += health;
                    if (DEBUG)
                    {
                        Debug.Log(
                            "HEALTH:" + gameObject.name + " gained " + health + ", now health is at: " + currentHp);
                    }
                }
            }
        }

        private void UpdateDamageArt()
        {
            if (damageTaken)
            {
                spriteRenderer.color = Color.red;
                counterDamage += Time.deltaTime;

                if (counterDamage > timeDamageArt)
                {
                    spriteRenderer.color = Color.white;
                    damageTaken = false;
                }
            }
        }
    }

