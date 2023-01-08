using UnityEngine;

namespace Minion
{
    public class MinionLootController : MonoBehaviour
    {
        [SerializeField] private float needLootTimeSeconds = 10;

        public float CurrentLootTimeSeconds { get; set; }

        [SerializeField] private GameObject loot;
        
        public void Looting(float second,MinionState state,float distanceToField)
        {
            if (state != MinionState.Loot || distanceToField > .1f) return;
            
            CurrentLootTimeSeconds += second;
        }

        public bool IsLooted()
        {
            return CurrentLootTimeSeconds >= needLootTimeSeconds;
        }

        private void Update()
        {
            loot.SetActive(IsLooted());
        }
    }
}
