using AbstractClasses;

namespace Player
{
    public class PlayerAnimationController : AnimationController
    {
        private const string AttackSpeedString = "AttackSpeed";

        public override void PlayAttackAnimation()
        {
            _animator.SetBool(Attack,true);
        }

        public void StopAttackAnimation()
        {
            _animator.SetBool(Attack,false);
        }

        public void SetAttackAnimationSpeed(float speed)
        {
            _animator.SetFloat(AttackSpeedString, speed);
        }
        
        public void StopDeadAnimation()
        {
            _animator.SetBool(Dead,false);
        }
    }
}
