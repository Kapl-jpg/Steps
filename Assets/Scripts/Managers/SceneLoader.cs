using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    
        public void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }
    
        public void LoadMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    
        public void LoadWin()
        {
            SceneManager.LoadScene("Win");
        }
    
        public void LoadLose()
        {
            SceneManager.LoadScene("Lose");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
