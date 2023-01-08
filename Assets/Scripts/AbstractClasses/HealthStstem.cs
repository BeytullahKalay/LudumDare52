using System;
using Interfaces;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace AbstractClasses
{
    public abstract class HealthSystem : MonoBehaviour,IHealthSystem
    {
        public LiveState LiveState;
        
        [SerializeField] protected int maxHealth = 100;
        public int Health { get; set; }

        public Action<int> TakeDamage;
        public Action OnDead;

        protected Rigidbody rb;
        protected Collider coll;

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
            rb = GetComponent<Rigidbody>();
            coll = GetComponent<Collider>();
        }

        public void GetDamage(int damage)
        {
            Health -= damage;
            if(Health <= 0) OnDead.Invoke();
        }

        public virtual void Die()
        {
            Health = 0;
            LiveState = LiveState.Dead;
            rb.isKinematic = true;
            coll.enabled = false;
            Debug.Log(transform.name + " object death");
        }
    }
}
