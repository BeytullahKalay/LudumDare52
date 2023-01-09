using UnityEngine;

namespace Collectible
{
    public class GoldCollect : AbstractClasses.Collectible
    {
        private void OnTriggerEnter(Collider other)
        {
            Interact(other);
        }

        public override void Interact(Collider collider)
        {
            if (!collider.CompareTag("Player")) return;
        
            EventManager.CollectGold?.Invoke(1);

            Destroy(gameObject);
        }
    }
}