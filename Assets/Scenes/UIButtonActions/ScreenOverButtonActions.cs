using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes.UIButtonActions
{
    public class ScreenOverButtonActions : MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
