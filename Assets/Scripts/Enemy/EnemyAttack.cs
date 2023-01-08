using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private int damage = 50;
        [SerializeField] private Transform attackPosition;
        [SerializeField] private float attackDetectRadius = 3f;
        [SerializeField] private float attackDistance;
        [SerializeField] private float timeBetweenAttacks = 1;
        [SerializeField] private LayerMask whatIsPlayer;

        public float AttackDistance { get; private set; }

        private float _lastAttackTime = float.MinValue;

        private void Awake()
        {
            AttackDistance = attackDistance;
        }


        public bool TryAttack(Transform targetTransform)
        {
            if (!(attackDistance >= Vector3.Distance(targetTransform.position, transform.position))) return false;

            if (Time.time > _lastAttackTime)
            {
                _lastAttackTime = Time.time + timeBetweenAttacks;
                return true;
            }
            else
            {
                return false;
            }
        }

        // used by unity animation event
        public void Attack()
        {
            Debug.Log(transform.name + " Attacked!");
            var hitPlayer = Physics.OverlapSphere(attackPosition.position, attackDetectRadius, whatIsPlayer);
            

            if (hitPlayer.Length > 0)
            {
                hitPlayer[0].GetComponent<PlayerHealthSystem>().TakeDamage?.Invoke(damage);
            }
    
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(attackPosition.position, attackDetectRadius);
        }
    }
}