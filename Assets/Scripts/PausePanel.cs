using Player;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput.Pause += ChangeActivityMenuPanel;
    }
    
    private void OnDisable()
    {
        playerInput.Pause -= ChangeActivityMenuPanel;
    }

    public void ChangeActivityMenuPanel()
    {
        if (menuPanel.activeSelf)
        {
            ExitMenuPanel();
        }
        else
        {
            OpenMenuPanel();
        }
    }

    private void OpenMenuPanel()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void ExitMenuPanel()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
