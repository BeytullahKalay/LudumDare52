
namespace Enemy.State
{
    public class EnemyDeadState : EnemyBaseState
    {
        private bool _isDead = false;
        public override void EnterState(EnemyStateManager enemy)
        {
            if(_isDead) return;
            _isDead = true;
            
            enemy.Agent.isStopped = true;
            
            enemy.AnimationController.PlayDeadAnimation();

            enemy.EnemyHealth.DestroyLight();
        }

        public override void UpdateState(EnemyStateManager enemy)
        {
            enemy.SoulHarvest.Interact();
        }
    }
}
