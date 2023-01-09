using System;

namespace Enemy.State
{
    public class EnemyMoveState : EnemyBaseState
    {
        public override void EnterState(EnemyStateManager enemy)
        {
            FindTargetTransform(enemy);
            enemy.Agent.stoppingDistance = enemy.EnemyAttack.AttackDistance;
        }

        public override void UpdateState(EnemyStateManager enemy)
        {
            enemy.Agent.SetDestination(enemy.Target.position);
            enemy.AnimationController.PlayMoveAnimation(1);

            if (enemy.EnemyHealth.Health <= 0)
            {
                enemy.SwitchState(enemy.DeadState);
                return;
            }

            if (enemy.Agent.remainingDistance <= enemy.EnemyAttack.AttackDistance)
            {
                enemy.SwitchState(enemy.AttackState);
                return;
            }
        }

        private static void FindTargetTransform(EnemyStateManager enemy)
        {
            switch (enemy.EnemyMovement.GetTarget())
            {
                case EnemyTarget.Base:
                    enemy.Target = GameManager.Instance.BaseBuild;
                    break;
                case EnemyTarget.Player:
                    enemy.Target = GameManager.Instance.Player;
                    break;
                case EnemyTarget.Harvest:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}