using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyHealthSystem))]
    [RequireComponent(typeof(EnemyAttack))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private EnemyTarget target;
        [SerializeField] private float moveSpeed;

        private EnemyAttack _enemyAttack;
        private NavMeshAgent _agent;
        private EnemyHealthSystem _healthSystem;
        private GameManager _gm;


        public Transform TargetTransform { get;private set; }

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _healthSystem = GetComponent<EnemyHealthSystem>();
            
        }

        private void Start()
        {
            _agent.speed = moveSpeed;
            
            FindTargetTransform();

        }

        public void MoveToTarget()
        {
            if (_healthSystem.LiveState != LiveState.Alive)
            {
                StopAgent();
                return;
            }

            MoveTo(TargetTransform.position);
        }

        private void StopAgent()
        {
            _agent.speed = 0;
            _agent.angularSpeed = 0;
        }
        
        private void FindTargetTransform()
        {
            var gm = GameManager.Instance;
            switch (target)
            {
                case EnemyTarget.Base:
                    TargetTransform = gm.BaseBuild;
                    break;
                case EnemyTarget.Player:
                    TargetTransform = gm.Player;
                    break;
                case EnemyTarget.Harvest:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MoveTo(Vector3 movePos)
        {
            _agent.destination = movePos;
        }

        public float GetSpeed()
        {
            return _agent.velocity.magnitude;
        }

        public void SetAgentStopDistance(float stopDistance)
        {
            _agent.stoppingDistance = stopDistance;
        }
    }
}