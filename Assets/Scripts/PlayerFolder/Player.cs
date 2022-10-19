using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;
 namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour, IHealth, IStats
    {
        public delegate void TakenDamage();
        public event TakenDamage OnHealthHandleer;

        [Header("Характеристики персонажа")]
        [SerializeField] private int maxHealth;
        [SerializeField] private float immortalityTimeAfterHit;
        [SerializeField] private float speed;

        [Header("Звуки")]
        [SerializeField] private AudioClip hurtSound;
        [SerializeField] private AudioClip dieSound;


        private int currentHealth;
        private Animator animator;
        private float timer = Mathf.Infinity;
        private Transform _transform;
        public bool IsDie => currentHealth <= 0;
        public float ImmortalityTime => immortalityTimeAfterHit;
        public int MaxHealth => maxHealth;
        public int CurrentHealth => currentHealth;
        public float Speed => speed;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            currentHealth = maxHealth;
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            timer += Time.deltaTime;
        }
        public void TakeDamage(int damage)
        {
            if (damage < 0)            
                throw new ArgumentOutOfRangeException(); 
            
            if (timer >= ImmortalityTime && !IsDie)
            {
                timer = 0;
                currentHealth -= damage;
                if (currentHealth <= 0)
                {
                    Die();
                }
                else
                {
                    Hurt();
                }
                OnHealthHandleer?.Invoke();
            }
        }
        private void Hurt()
        {
            if (hurtSound != null)
                AudioSource.PlayClipAtPoint(hurtSound, _transform.position);
            animator.SetTrigger("Hurt");
        }
        private void Die()
        {
            StopAllCoroutines();
            if (dieSound != null)
                AudioSource.PlayClipAtPoint(dieSound, _transform.position);
            animator.SetTrigger("Die");
            Destroy(gameObject);
            Time.timeScale = 0;
           
        }
        public void Heal(int value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stat> GetStats()
        {
            throw new NotImplementedException();
        }
    }
}