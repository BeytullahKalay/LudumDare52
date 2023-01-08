using UnityEngine;

public class HarvestManager : MonoBehaviour
{
    [SerializeField] private GameObject minionSkeleton;

    private void OnEnable()
    {
        EventManager.Harvest += SpawnMinion;
    }

    private void OnDisable()
    {
        EventManager.Harvest -= SpawnMinion;
    }

    private void SpawnMinion(Transform spawnTransform)
    {
        Instantiate(minionSkeleton, spawnTransform.position, spawnTransform.rotation);
    }
}
