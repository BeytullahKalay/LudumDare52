using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private int damage = 50;
        [SerializeField] private Transform attackPositionTransform;
        [SerializeField] private float attackSpeed = 1;
        [SerializeField] private GameObject bulletPrefab;

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
    }
}