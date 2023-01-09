using UnityEngine;

public class GoldCollectFromPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
            
        if (!Input.GetKeyDown(KeyCode.E)) return;

        EventManager.CollectGold?.Invoke(1);

        Destroy(gameObject);
    }
}
