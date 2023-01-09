using System.Collections.Generic;
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

    [Header("Upgrades")] [SerializeField] private List<GameObject> upgradeObjectList = new List<GameObject>();

    public Transform Player => player;
    public Transform BaseBuild => baseBuild;

    
    public LayerMask PlayerLayerMask => playerLayerMask;
    public LayerMask BaseLayerMask => baseLayerMask;


    public GameObject GetRandomUpgrade => upgradeObjectList[Random.Range(0, upgradeObjectList.Count)];
}
