using System;
using Managers;
using TMPro;
using UnityEngine;

namespace FieldScripts
{
    public class Field : MonoBehaviour
    {
        public FieldState State;
        [SerializeField] private Transform field;
        [SerializeField] private GameObject canvas;
        [SerializeField] private TMP_Text tmpText;
        [SerializeField] private GameObject interactImage;

        private BoxCollider _boxCollider;
        
        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void Start()
        {
            if (!State.IsOpen)
            {
                field.gameObject.SetActive(false);
                tmpText.text = State.Cost.ToString();
            }
            else
            {
                Destroy(canvas);
                Destroy(_boxCollider);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            
            if (!other.CompareTag("Player")) return;

            if (!State.IsOpen)
                interactImage.gameObject.SetActive(true);
            
            if (!Input.GetKey(KeyCode.E)) return;

            var amount = CollectedManager.Instance.CollectedGoldAmount;

            if (amount >= State.Cost)
            {
                amount -= State.Cost;
                EventManager.UpdateUI?.Invoke(amount);
                field.gameObject.SetActive(true);
                State.IsOpen = true;
                EventManager.OnFieldBuy?.Invoke();
                Destroy(_boxCollider);
                Destroy(canvas);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                interactImage.gameObject.SetActive(false);

            }
        }
    }
}