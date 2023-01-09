using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private Rigidbody _rb;

        private void OnEnable()
        {
            EventManager.CollectMoveSpeed += IncreaseMoveSpeed;
        }

        private void OnDisable()
        {
            EventManager.CollectMoveSpeed -= IncreaseMoveSpeed;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 moveVector)
        {
            _rb.velocity = moveVector * moveSpeed;
        }

        private void IncreaseMoveSpeed(float speed)
        {
            moveSpeed += speed;
        }
    }
}