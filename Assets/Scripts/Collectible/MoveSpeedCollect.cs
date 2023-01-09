using UnityEngine;

namespace Collectible
{
    public class MoveSpeedCollect : AbstractClasses.Collectible
    {
        [SerializeField] private float increaseMoveSpeedVal = 2f;
        private void OnTriggerEnter(Collider other)
        {
            Interact(other);
        }
        
        public override void Interact(Collider collider)
        {
            if (!collider.CompareTag("Player")) return;
        
            EventManager.CollectMoveSpeed?.Invoke(increaseMoveSpeedVal);

            Destroy(gameObject);
        }
    }
}
