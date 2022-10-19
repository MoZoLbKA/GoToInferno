using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;
using System.Collections.Generic;
using UnityEngine;
 namespace Assets.Scripts.Player
{
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
            if (timer >= ImmortalityTime && !IsDie)
            {
                timer = 0;
                currentHealth -= damage;
                if (currentHealth <= 0)
                {
                    if (dieSound != null)
                    {
                        AudioSource.PlayClipAtPoint(dieSound, _transform.position);
                    }
                    if (animator != null)
                        animator.SetTrigger("IsDie");
                }
                else
                {
                    if (hurtSound != null)
                    {
                        AudioSource.PlayClipAtPoint(hurtSound, _transform.position);
                    }
                    if (animator != null)
                        animator.SetTrigger("Hurt");
                    Debug.Log("Hurt");
                }
                OnHealthHandleer?.Invoke();
            }
        }

        public void Heal(int value)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Stat> GetStats()
        {
            throw new System.NotImplementedException();
        }
    }
}