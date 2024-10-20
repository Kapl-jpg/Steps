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
            SceneLoader.Instance.LoadMenu();
        }

        public void Quit()
        {
            SceneLoader.Instance.Quit();
        }
    }
}
