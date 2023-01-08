using UnityEngine;

namespace Enemy
{
    public class SoulHarvest : MonoBehaviour
    {
        [SerializeField] private float interactRange = 5f;
        [SerializeField] private GameObject canvasGameObject;
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
            
            
            canvasGameObject.transform.LookAt(_camera.transform.position);

            var coll = Physics.OverlapSphere(transform.position, interactRange, whatIsPlayer);

            if (coll.Length > 0 && _isDead)
            {
                canvasGameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(gameObject);
                    EventManager.Harvest?.Invoke(transform);
                }
            }
            else
            {
                canvasGameObject.SetActive(false);
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