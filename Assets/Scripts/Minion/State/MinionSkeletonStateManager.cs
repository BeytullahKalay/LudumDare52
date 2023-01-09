using System;
using FieldScripts;
using Managers;
using UnityEngine;
using UnityEngine.AI;

namespace Minion.State
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(MinionAnimationController))]
    public class MinionSkeletonStateManager : MonoBehaviour
    {
        [SerializeField] private float needLootTimeSeconds = 6;
    
        public float NeedLootTimeSeconds { get; private set; }
        public float CurrentLootTimeSeconds { get; set; }

        public Field Field;
        public GameObject Loot;
        public NavMeshAgent Agent;
        public MinionAnimationController MinionAnimationController;

        private MinionSkeletonBaseState _currentState;
        public MinionSkeletonIdleState IdleState = new MinionSkeletonIdleState();
        public MinionSkeletonLootState LootState = new MinionSkeletonLootState();
        public MinionSkeletonTransferState TransferState = new MinionSkeletonTransferState();

        private void OnEnable()
        {
            EventManager.OnFieldBuy += RunStateMachine;
        }

        private void OnDisable()
        {
            EventManager.OnFieldBuy -= RunStateMachine;
        }

        private void Awake()
        {
            NeedLootTimeSeconds = needLootTimeSeconds;
            CurrentLootTimeSeconds = 0;
        }

        private void Start()
        {
            _currentState = IdleState;
            _currentState.EnterState(this);
        }

        private void Update()
        {
            _currentState.UpdateState(this);
        }

        public void SwitchState(MinionSkeletonBaseState state)
        {
            _currentState = state;

            _currentState.EnterState(this);
        }
        
        private void RunStateMachine()
        {
            if (Field == null)
            {
                _currentState = IdleState;
                _currentState.EnterState(this);
            }
        }
    }
}
