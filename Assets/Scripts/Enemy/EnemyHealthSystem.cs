using AbstractClasses;
using UnityEngine;
using DG.Tweening;

namespace Enemy
{
    public class EnemyHealthSystem : HealthSystem
    {
        [SerializeField] private Transform soul;

        protected override void Awake()
        {
            base.Awake();
            OnDead += SoulWaveEffect;
        }

        private void SoulWaveEffect()
        {
            soul.gameObject.SetActive(true);
            soul.DOMoveY(2, 2).OnComplete(() =>
            {
                soul.DOMoveY(1, 2).SetLoops(-1, LoopType.Yoyo);
            });
        }
    }
}