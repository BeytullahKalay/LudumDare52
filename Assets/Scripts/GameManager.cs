using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion


    [SerializeField] private Transform player;
    [SerializeField] private Transform baseBuild;
    [SerializeField] private Transform playerSpawnPosition;

    public Transform Player => player;
    public Transform BaseBuild => baseBuild;
    public Transform PlayerSpawnPosition => playerSpawnPosition;
}
