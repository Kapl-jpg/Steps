using UnityEngine;

namespace Managers
{
    public class SceneButtonHandler : MonoBehaviour
    {
        public void LoadGame()
        {
            SceneLoader.Instance.LoadGame();
        }

        public void LoadMenu()
        {
            Time.timeScale = 1;
            SceneLoader.Instance.LoadMenu();
        }

        public void Quit()
        {
            SceneLoader.Instance.Quit();
        }
    }
}
