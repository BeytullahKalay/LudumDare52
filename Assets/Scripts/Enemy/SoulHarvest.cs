using UnityEngine;

namespace Enemy
{
    public class SoulHarvest : MonoBehaviour
    {
        [SerializeField] private float interactRange = 5f;
        [SerializeField] private GameObject imageGameObject;
        [SerializeField] private LayerMask whatIsPlayer;
        [SerializeField][Range(0,1)] private float harvestChance = .1f;
        
        private bool _isDead;
        private bool _canHarvest;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            _canHarvest = Random.value < harvestChance;
        }

        private void Update()
        {
            Interact();
        }

        private void Interact()
        {
            if (!_canHarvest) return;

            var coll = Physics.OverlapSphere(transform.position, interactRange, whatIsPlayer);

            if (coll.Length > 0 && _isDead)
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

        public void SetIsDeadTrue()
        {
            _isDead = true;
        }

        private void OnDrawGizmos()
        {
            if (!_isDead) return;
            Gizmos.DrawWireSphere(transform.position, interactRange);
        }
    }
}