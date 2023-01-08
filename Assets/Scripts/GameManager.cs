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

    [Header("Transforms")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform baseBuild;

    [Header("LayerMask")]
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private LayerMask baseLayerMask;

    public Transform Player => player;
    public Transform BaseBuild => baseBuild;

    
    public LayerMask PlayerLayerMask => playerLayerMask;
    public LayerMask BaseLayerMask => baseLayerMask;
}
