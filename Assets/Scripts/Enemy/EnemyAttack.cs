using AbstractClasses;
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


        public float AttackDistance { get; private set; }
        public float TimeBetweenAttacks { get; private set; }
        
        private LayerMask _whatIsTargetLayer;

        private void Awake()
        {
            AttackDistance = attackDistance;
            TimeBetweenAttacks = timeBetweenAttacks;
        }


        // used by unity animation event
        public void Attack()
        {
            Debug.Log(transform.name + " Attacked!");
            var hitPlayer = Physics.OverlapSphere(attackPosition.position, attackDetectRadius, _whatIsTargetLayer);

            if (hitPlayer.Length > 0)
            {
                hitPlayer[0].GetComponent<HealthSystem>().TakeDamage?.Invoke(damage);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(attackPosition.position, attackDetectRadius);
        }

        public void SetWhatIsEnemyLayer(LayerMask targetLayer)
        {
            _whatIsTargetLayer = targetLayer;
        }
    }
}