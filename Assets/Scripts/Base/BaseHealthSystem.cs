using AbstractClasses;
using DG.Tweening;
using UnityEngine;

namespace Base
{
    public class BaseHealthSystem : HealthSystem
    {
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
            base.GetDamage(damage);
            transform.DOShakeScale(.2f, Vector3.one * .75f, 10);
        }
    }
}
