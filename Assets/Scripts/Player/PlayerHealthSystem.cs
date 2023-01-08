using System;
using System.Collections;
using AbstractClasses;
using UnityEngine;

namespace Player
{
    public class PlayerHealthSystem : HealthSystem
    {
        [SerializeField] private float spawnAfterSeconds = 4f;
        [SerializeField] private Transform spawnTransform;
        
        private PlayerManager _playerManager;
        private PlayerLookAt _playerLookAt;

        private IEnumerator _coroutine;

        public Action OnSpawn;
        
        protected override void Awake()
        {
            base.Awake();
            OnSpawn += OnPlayerSpawn;
            _playerManager = GetComponent<PlayerManager>();
            _playerLookAt = GetComponent<PlayerLookAt>();
        }

        private void Start()
        {
            _coroutine = RespawnPlayerAfter(spawnAfterSeconds);
        }

        public override void Die()
        {
            base.Die();
            OnPlayerDeath();
        }

        private void OnPlayerDeath()
        {
            _playerManager.enabled = false;
            _playerLookAt.enabled = false;

            StartCoroutine(_coroutine);
        }

        private void OnPlayerSpawn()
        {
            _playerManager.enabled = true;
            _playerLookAt.enabled = true;
            
            Health = maxHealth;
            LiveState = LiveState.Alive;
            rb.isKinematic = false;
            coll.enabled = true;

            transform.position = spawnTransform.position;
            
            Debug.Log("Player spawned");
        }

        private IEnumerator RespawnPlayerAfter(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            OnSpawn?.Invoke();
        }
    }
}
