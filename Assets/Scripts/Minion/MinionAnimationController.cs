using AbstractClasses;
using UnityEngine;

namespace Minion
{
    [RequireComponent(typeof(Animator))]
    public class MinionAnimationController : AnimationController
    {
        private const string Loot = "Loot";

        public void DecideLootAnimationState(float distanceToLootPosition)
        {
            if (distanceToLootPosition <= 0.1f)
            {
                PlayLootAnimation();
            }
            else
            {
                StopLootAnimation();
            }
        }

        private void PlayLootAnimation()
        {
            _animator.SetBool(Loot,true);
        }

        private void StopLootAnimation()
        {
            _animator.SetBool(Loot,false);
        }
    }
}
