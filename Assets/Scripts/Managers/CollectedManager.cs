using System;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class CollectedManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text tmpText;
        [SerializeField] private int collectedGoldAmount;
        
        private void OnEnable()
        {
            EventManager.CollectGold += CollectOneGold;
            EventManager.UpdateUI += UpdateTempText;
        }

        private void OnDisable()
        {
            EventManager.CollectGold -= CollectOneGold;
            EventManager.UpdateUI -= UpdateTempText;
        }

        private void Start()
        {
            EventManager.UpdateUI?.Invoke(collectedGoldAmount);
        }

        private void CollectOneGold()
        {
            collectedGoldAmount++;
            EventManager.UpdateUI?.Invoke(collectedGoldAmount);
        }

        private void UpdateTempText(int goldAmount)
        {
            tmpText.text = "50/" + goldAmount;
        }
    }
}
