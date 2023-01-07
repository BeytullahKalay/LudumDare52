using System;
using Interfaces;
using UnityEngine;

namespace AbstractClasses
{
    public abstract class HealthSystem : MonoBehaviour,IHealthSystem
    {
        public LiveState LiveState;
        
        [SerializeField] private int maxHealth = 100;
        public int Health { get; private set; }

        public Action<int> TakeDamage;
        public Action OnDead;

        private void OnEnable()
        {
            TakeDamage += GetDamage;
            OnDead += Die;
        }

        private void OnDisable()
        {
            TakeDamage -= GetDamage;
            OnDead -= Die;
        }

        protected virtual void Awake()
        {
            Health = maxHealth;
        }

        public void GetDamage(int damage)
        {
            Health -= damage;
            
            if(Health <= 0) OnDead.Invoke();
        }

        public virtual void Die()
        {
            LiveState = LiveState.Dead;
            GetComponent<Rigidbody>().isKinematic = true;
            Destroy(GetComponent<Collider>());
            Debug.Log(transform.name + " object death");
        }
    }
}
