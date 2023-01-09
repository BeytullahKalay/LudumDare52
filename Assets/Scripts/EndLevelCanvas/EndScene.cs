using UnityEngine;

namespace EndLevelCanvas
{
    public class EndScene : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject levelCompletedPanel;

        private void OnEnable()
        {
            EventManager.GameOver += OpenGameOverPanel;
            EventManager.Completed += OpenLevelCompletedPanel;
        }

        private void OnDisable()
        {
            EventManager.GameOver -= OpenGameOverPanel;
            EventManager.Completed -= OpenLevelCompletedPanel;
        }


        private void OpenGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }

        private void OpenLevelCompletedPanel()
        {
            levelCompletedPanel.SetActive(true);
        }
    }
}
