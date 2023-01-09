using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class SoulHarvest : MonoBehaviour
    {
        [SerializeField] private float interactRange = 5f;
        [SerializeField] private GameObject imageGameObject;
        [SerializeField] private LayerMask whatIsPlayer;
        [SerializeField][Range(0,1)] private float harvestChance = .1f;
        
        private bool _canHarvest;

        private void Awake()
        {
            _canHarvest = Random.value < harvestChance;
        }

        public void Interact()
        {
            if (!_canHarvest) return;

            var coll = Physics.OverlapSphere(transform.position, interactRange, whatIsPlayer);

            if (coll.Length > 0)
            {
                imageGameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(gameObject);
                    EventManager.Harvest?.Invoke(transform);
                }
            }
            else
            {
                imageGameObject.SetActive(false);
            }
        }



        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, interactRange);
        }

        public bool GetCanHarvest()
        {
            return _canHarvest;
        }
    }
}