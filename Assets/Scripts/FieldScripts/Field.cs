using UnityEngine;

namespace FieldScripts
{
    public class Field : MonoBehaviour
    {
        public FieldState State;

        private void Start()
        {
            if (!State.IsOpen)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
