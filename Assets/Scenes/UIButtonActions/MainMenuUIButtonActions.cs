using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.UIButtonActions
{
    public class MainMenuUIButtonActions : MonoBehaviour
    {
        public void LoadGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
