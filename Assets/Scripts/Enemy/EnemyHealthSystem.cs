using AbstractClasses;
using UnityEngine;
using DG.Tweening;

namespace Enemy
{
    [RequireComponent(typeof(SoulHarvest))]
    public class EnemyHealthSystem : HealthSystem
    {
        [SerializeField] private Transform soul;
        [SerializeField] private Transform gold;

        private SoulHarvest _soulHarvest;

        protected override void Awake()
        {
            base.Awake();
            OnDead += SoulWaveEffect;
            _soulHarvest = GetComponent<SoulHarvest>();
        }

        private void SoulWaveEffect()
        {
            if (_soulHarvest.GetCanHarvest())
            {
                Swing(soul);
            }
            else
            {
                Swing(gold);
            }
        }

        private void Swing(Transform swingObject)
        {
            swingObject.gameObject.SetActive(true);
            swingObject.DOMoveY(2, 2).OnComplete(() => { swingObject.DOMoveY(1, 2).SetLoops(-1, LoopType.Yoyo); });
            swingObject.DORotate(Vector3.one * 360,1 ).SetLoops(-1, LoopType.Yoyo);
        }
    }
}