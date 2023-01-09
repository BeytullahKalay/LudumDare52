using UnityEngine;

public class GoldCollectFromPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        EventManager.CollectGold?.Invoke(1);

        Destroy(gameObject);
    }
}
