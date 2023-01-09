using AbstractClasses;

namespace Enemy
{
    public class EnemyAnimationController : AnimationController
    {
        public void TriggerAttackAnimation(bool canAttack)
        {
            if (canAttack)
                PlayAttackAnimation();
        }
    }
}
