using Interfaces;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerHealthSystem))]
    [RequireComponent(typeof(PlayerAnimationController))]
    [RequireComponent(typeof(PlayerAttack))]
    public class PlayerManager : MonoBehaviour
    {
        private IMovementInput _movementInput;
        private IAttackInput _attackInput;
        private PlayerMovement _playerMovement;
        private PlayerHealthSystem _playerHealthSystem;
        private PlayerAnimationController _playerAnimationController;
        private PlayerAttack _playerAttack;

        private void Awake()
        {
            _movementInput = GetComponent<IMovementInput>();
            _attackInput = GetComponent<IAttackInput>();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerHealthSystem = GetComponent<PlayerHealthSystem>();
            _playerAnimationController = GetComponent<PlayerAnimationController>();
            _playerAttack = GetComponent<PlayerAttack>();
        }

        private void Start()
        {
            _playerHealthSystem.OnDead += _playerAnimationController.PlayDeadAnimation;
            _playerAnimationController.SetAttackAnimationSpeed(_playerAttack.GetAttackSpeed());
        }

        private void Update()
        {
            _playerAnimationController.PlayMoveAnimation(_movementInput.MoveVector3.magnitude);
            _playerAttack.Attack(_attackInput.AttackKey,_playerAnimationController);
        }

        private void FixedUpdate()
        {
            _playerMovement.Move(_movementInput.MoveVector3);
        }
    }
}