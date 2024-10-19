using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
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
    
}
