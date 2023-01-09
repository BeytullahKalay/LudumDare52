using AbstractClasses;
using UnityEngine;
using DG.Tweening;

namespace Enemy
{
    [RequireComponent(typeof(SoulHarvest))]
    [RequireComponent(typeof(DropUpgrade))]
    public class EnemyHealthSystem : HealthSystem
    {
        [SerializeField] private Transform soul;
        [SerializeField] private GameObject gold;
        [SerializeField] GameObject lightObject;

        private SoulHarvest _soulHarvest;
        private DropUpgrade _dropUpgrade;

        protected override void Awake()
        {
            base.Awake();
            OnDead += Drops;
            
            _soulHarvest = GetComponent<SoulHarvest>();
            _dropUpgrade = GetComponent<DropUpgrade>();
        }

        private void Drops()
        {
            if (_soulHarvest.GetCanHarvest())
            {
                Swing(soul);
            }
            else
            {
                Destroy(gameObject,2f);
                _dropUpgrade.TryDrop();
            }
            // else
            // {
            //     var obj = Instantiate(gold, transform.position, gold.transform.rotation);
            //     Swing(obj.transform);
            //     Destroy(gameObject);
            // }
        }

        private void Swing(Transform swingObject)
        {
            swingObject.gameObject.SetActive(true);
            swingObject.DOMoveY(2, 2).OnComplete(() => { swingObject.DOMoveY(1, 2).SetLoops(-1, LoopType.Yoyo); });
            swingObject.DORotate(Vector3.one * 360,1 ).SetLoops(-1, LoopType.Yoyo);
        }

        public void DestroyLight()
        {
            Destroy(lightObject);
        }
    }
}