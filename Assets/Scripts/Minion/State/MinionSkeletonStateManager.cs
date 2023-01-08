using UnityEngine;
using UnityEngine.AI;

namespace Minion.State
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(MinionAnimationController))]
    public class MinionSkeletonStateManager : MonoBehaviour
    {
        [SerializeField] private float needLootTimeSeconds = 6;
    
        public float NeedLootTimeSeconds { get; private set; }
        public float CurrentLootTimeSeconds { get; set; }
    
        public GameObject Loot;
        public NavMeshAgent Agent;
        public Animator Animator;
        public MinionAnimationController MinionAnimationController;

        private MinionSkeletonBaseState _currentState;
        public MinionSkeletonLootState LootState = new MinionSkeletonLootState();
        public MinionSkeletonTransferState TransferState = new MinionSkeletonTransferState();

        private void Awake()
        {
            NeedLootTimeSeconds = needLootTimeSeconds;
            CurrentLootTimeSeconds = 0;
        }

        private void Start()
        {
            _currentState = LootState;
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
    }
}
