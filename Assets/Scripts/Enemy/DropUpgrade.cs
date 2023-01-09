using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class DropUpgrade : MonoBehaviour
    {
        [SerializeField][Range(0, 1)] private float upgradeDropChance = 0;

        private bool _drop;

        private void Awake()
        {
            _drop = Random.value < upgradeDropChance;
        }

        public void TryDrop()
        {
            if (!_drop) return;

            Instantiate(GameManager.Instance.GetRandomUpgrade, transform.position, quaternion.identity);
        }
    }
}