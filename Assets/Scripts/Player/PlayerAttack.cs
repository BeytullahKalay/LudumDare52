using System;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private int damage = 50;
        [SerializeField] private Transform attackPositionTransform;
        [SerializeField] private float attackSpeed = 1;
        [SerializeField] private GameObject bulletPrefab;

        private void OnEnable()
        {
            EventManager.CollectAttackSpeed += IncreaseAttackSpeedAnimation;
        }

        private void OnDisable()
        {
            EventManager.CollectAttackSpeed -= IncreaseAttackSpeedAnimation;
        }

        public void Attack(KeyCode attackKey, PlayerAnimationController animationController)
        {
            if (Input.GetKey(attackKey))
            {
                animationController.PlayAttackAnimation();
            }
            else
            {
                animationController.StopAttackAnimation();
            }
        }


        // used by unity animation event
        public void SpawnBullet()
        {
            var bullet = Instantiate(bulletPrefab, attackPositionTransform.position, attackPositionTransform.rotation);
            bullet.GetComponent<Bullet>().Damage = damage;
        }

        public float GetAttackSpeed()
        {
            return attackSpeed;
        }

        private void IncreaseAttackSpeedAnimation(float increaseAmount)
        {
            attackSpeed += increaseAmount;
            EventManager.UpdateAnimationSpeed?.Invoke();
        }
    }
}