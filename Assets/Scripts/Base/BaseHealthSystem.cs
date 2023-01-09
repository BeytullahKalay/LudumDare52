using AbstractClasses;
using DG.Tweening;
using UnityEngine;

namespace Base
{
    public class BaseHealthSystem : HealthSystem
    {

        private bool _canGetAttack = true;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            EventManager.Completed += SetCanGetAttackToFalse;
        }
        
        protected override void OnDisable()
        {
            base.OnDisable();
            EventManager.Completed -= SetCanGetAttackToFalse;
        }

        protected override void Awake()
        {
            Health = maxHealth;
        }
    
        public override void Die()
        {
            Health = 0;
            LiveState = LiveState.Dead;
            Debug.Log(transform.name + " object death");
            Debug.Log("GAME OVER");
            EventManager.GameOver?.Invoke();
        }

        public override void GetDamage(int damage)
        {
            if(!_canGetAttack) return;
            
            base.GetDamage(damage);
            transform.DOShakeScale(.2f, Vector3.one * .1f, 20);
        }

        private void SetCanGetAttackToFalse()
        {
            _canGetAttack = false;
        }
    }
}
