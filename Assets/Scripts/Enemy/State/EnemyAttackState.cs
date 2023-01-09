using System;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyAttackState : EnemyBaseState
    {
        private float _lastAttackTime = float.MinValue;
        private LayerMask _whatIsTargetLayer;
        
        public override void EnterState(EnemyStateManager enemy)
        {
            FindAttackLayer(enemy.EnemyMovement.GetTarget());
            enemy.EnemyAttack.SetWhatIsEnemyLayer(_whatIsTargetLayer);
            enemy.AnimationController.PlayMoveAnimation(0);
        }

        public override void UpdateState(EnemyStateManager enemy)
        {
            if (enemy.EnemyHealth.Health <= 0)
            {
                enemy.SwitchState(enemy.DeadState);
                return;
            }

            if (enemy.Agent.remainingDistance > enemy.EnemyAttack.AttackDistance)
            {
                enemy.SwitchState(enemy.MoveState);
                return;
            }

            enemy.AnimationController.TriggerAttackAnimation(TryAttack(enemy));
            
            enemy.SwitchState(enemy.MoveState);

        }

        private bool TryAttack(EnemyStateManager enemy)
        {
            if (Time.time >= _lastAttackTime)
            {
                _lastAttackTime = Time.time + enemy.EnemyAttack.TimeBetweenAttacks;
                return true;
            }
            return false;
        }
        
        private void FindAttackLayer(EnemyTarget target)
        {
            switch (target)
            {
                case EnemyTarget.Base:
                    _whatIsTargetLayer = GameManager.Instance.BaseLayerMask;
                    break;
                case EnemyTarget.Player:
                    _whatIsTargetLayer = GameManager.Instance.PlayerLayerMask;
                    break;
                case EnemyTarget.Harvest:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(target), target, null);
            }
        }
    }
}
