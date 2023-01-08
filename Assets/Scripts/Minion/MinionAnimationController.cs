using AbstractClasses;
using UnityEngine;

namespace Minion
{
    [RequireComponent(typeof(Animator))]
    public class MinionAnimationController : AnimationController
    {
        private const string Loot = "Loot";

        public void PlayLootAnimation()
        {
            _animator.SetBool(Loot,true);
        }

        public void StopLootAnimation()
        {
            _animator.SetBool(Loot,false);
        }
    }
}
