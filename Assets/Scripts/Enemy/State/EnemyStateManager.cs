using UnityEngine;
using UnityEngine.AI;

namespace Enemy.State
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAttack))]
    [RequireComponent(typeof(EnemyAnimationController))]
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(EnemyHealthSystem))]
    [RequireComponent(typeof(SoulHarvest))]
    public class EnemyStateManager : MonoBehaviour
    {
        public NavMeshAgent Agent;

        public EnemyAttack EnemyAttack;

        public Transform Target;

        public EnemyAnimationController AnimationController;

        public EnemyMovement EnemyMovement;
        
        public EnemyHealthSystem EnemyHealth;
        
        public SoulHarvest SoulHarvest;

        public DropUpgrade DropUpgrade;


        private EnemyBaseState _currentState;
        public EnemyAttackState AttackState = new EnemyAttackState();
        public EnemyMoveState MoveState = new EnemyMoveState();
        public EnemyDeadState DeadState = new EnemyDeadState();

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            EnemyAttack = GetComponent<EnemyAttack>();
            AnimationController = GetComponent<EnemyAnimationController>();
            EnemyMovement = GetComponent<EnemyMovement>();
        }

        private void Start()
        {
            _currentState = MoveState;
            _currentState.EnterState(this);
        }

        private void Update()
        {
            _currentState.UpdateState(this);
        }

        public void SwitchState(EnemyBaseState state)
        {
            _currentState = state;
            _currentState.EnterState(this);
        }
    }
}