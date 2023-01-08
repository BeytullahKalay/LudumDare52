using UnityEngine;

namespace Minion
{
    [RequireComponent(typeof(MinionStateController))]
    [RequireComponent(typeof(MinionMovementController))]
    [RequireComponent(typeof(MinionAnimationController))]
    [RequireComponent(typeof(MinionLootController))]
    public class MinionManager : MonoBehaviour
    {
        private MinionStateController _stateController;
        private MinionMovementController _movementController;
        private MinionAnimationController _animationController;
        private MinionLootController _lootController;


        private void Awake()
        {
            _stateController = GetComponent<MinionStateController>();
            _movementController = GetComponent<MinionMovementController>();
            _animationController = GetComponent<MinionAnimationController>();
            _lootController = GetComponent<MinionLootController>();
        }

        private void Start()
        {
            _movementController.TryGetAField(_stateController);
        }

        private void Update()
        {
            _animationController.PlayMoveAnimation(_movementController.GetSpeed());
            _animationController.DecideLootAnimationState(_movementController.GetDistanceToTargetLocation());
            _lootController.Looting(Time.deltaTime, _stateController.MinionState, _movementController.GetDistanceToTargetLocation());
            _movementController.GoBaseToGiveLoot(_lootController.IsLooted(),_stateController,_lootController);
            _movementController.TurnOwnField(_stateController,_lootController);
        }
    }
}