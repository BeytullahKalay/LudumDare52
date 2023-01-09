using UnityEngine;

namespace Collectible
{
    public class AttackSpeedCollect : AbstractClasses.Collectible
    {
        [SerializeField] private float increaseAttackSpeedVal = .25f;
        private void OnTriggerEnter(Collider other)
        {
            Interact(other);
        }
        
        public override void Interact(Collider collider)
        {
            if (!collider.CompareTag("Player")) return;
        
            EventManager.CollectAttackSpeed?.Invoke(increaseAttackSpeedVal);

            Destroy(gameObject);
        }
    }
}
