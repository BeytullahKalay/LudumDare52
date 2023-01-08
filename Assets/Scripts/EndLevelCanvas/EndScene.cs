using UnityEngine;

namespace EndLevelCanvas
{
    public class EndScene : MonoBehaviour
    {
        [SerializeField] private GameObject panelToOpen;

        private void OnEnable()
        {
            EventManager.GameOver += OpenPanel;
        }

        private void OnDisable()
        {
            EventManager.GameOver -= OpenPanel;
        }


        private void OpenPanel()
        {
            panelToOpen.SetActive(true);
        }
    }
}
