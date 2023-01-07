using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(EnemyAnimationController))]
    [RequireComponent(typeof(EnemyHealthSystem))]
    [RequireComponent(typeof(EnemyAttack))]
    public class EnemyManager : MonoBehaviour
    {
        private EnemyMovement _enemyMovement;
        private EnemyAnimationController _enemyAnimationController;
        private EnemyHealthSystem _enemyHealthSystem;
        private EnemyAttack _enemyAttack;

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
            _enemyAnimationController = GetComponent<EnemyAnimationController>();
            _enemyHealthSystem = GetComponent<EnemyHealthSystem>();
            _enemyAttack = GetComponent<EnemyAttack>();
        }
        
        private void Start()
        {
            _enemyHealthSystem.OnDead += _enemyAnimationController.PlayDeadAnimation;
            _enemyMovement.SetAgentStopDistance(_enemyAttack.AttackDistance);
        }

        private void Update()
        {
            _enemyAnimationController.PlayMoveAnimation(_enemyMovement.GetSpeed());
            _enemyAnimationController.TriggerAttackAnimation(_enemyAttack.TryAttack(_enemyMovement.TargetTransform));
        }

        private void FixedUpdate()
        {
            _enemyMovement.MoveToTarget();
        }
    }
}