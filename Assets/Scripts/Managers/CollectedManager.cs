using TMPro;
using UnityEngine;

namespace Managers
{
    public class CollectedManager : MonoBehaviour
    {

        #region Singleton

        public static CollectedManager Instance;
        
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
        
        
        [SerializeField] private TMP_Text tmpText;
        public int CollectedGoldAmount;

        private void OnEnable()
        {
            EventManager.CollectGold += CollectGold;
            EventManager.UpdateUI += UpdateTempText;
        }

        private void OnDisable()
        {
            EventManager.CollectGold -= CollectGold;
            EventManager.UpdateUI -= UpdateTempText;
        }

        private void Start()
        {
            EventManager.UpdateUI?.Invoke(CollectedGoldAmount);
        }

        private void CollectGold(int goldAmount)
        {
            CollectedGoldAmount += goldAmount;
            EventManager.UpdateUI?.Invoke(CollectedGoldAmount);

            if (CollectedGoldAmount >= 50)
            {
                Debug.Log("Level Completed!");
            }
        }

        private void UpdateTempText(int goldAmount)
        {
            tmpText.text = goldAmount + "/200";
        }
    }
}