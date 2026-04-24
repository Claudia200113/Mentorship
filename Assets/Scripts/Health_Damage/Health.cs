using System;
using A2;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using UI;
using UnityEngine;

    public class Health : MonoBehaviour
    {
        public bool DEBUG;

        public float currentHp;
        public float timeDamageArt = .3f;
        public float maxHp = 100f;
        private float counterDamage = 0;
        private bool damageTaken = false;
        public bool dead = false;
        private SpriteRenderer spriteRenderer;
        
        public static event Action OnPlayerDeath;

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

        public void TakeDamage(float damage)
        {
            currentHp -= damage;
            counterDamage = 0;
            damageTaken = true;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.damage);
            
            if (currentHp > 0)
            {
                if (DEBUG)
                {
                    Debug.Log("HEALTH: " + gameObject.name + " was damaged, life now at " + currentHp);
                }


            }
            else if (currentHp <= 0) //If health goes less than 0, DeathFromDamage is called 
            {
                if (DEBUG)
                {
                    Debug.Log("HEALTH:" + gameObject.name + " no life points left, calling DeathFromDamage()");
                }

                DeathFromDamage();
            }
        }

        private void DeathFromDamage()
        {
            dead = true;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.death);
            OnPlayerDeath?.Invoke();
        }

        public void GainHealth(int health)
        {
            
                if (currentHp < 100)
                {
                    currentHp += health;
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

