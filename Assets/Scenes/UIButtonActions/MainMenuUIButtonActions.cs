using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.UIButtonActions
{
    public class MainMenuUIButtonActions : MonoBehaviour
    {
        [SerializeField] private GameObject buttons;
        [SerializeField] private GameObject howToPlayPanel;
        public void LoadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void HowToPlay()
        {
            buttons.SetActive(false);
            howToPlayPanel.SetActive(true);
        }

        public void ReturnToMenuFromHowToPlay()
        {
            buttons.SetActive(true);
            howToPlayPanel.SetActive(false);
        }
    }
}
