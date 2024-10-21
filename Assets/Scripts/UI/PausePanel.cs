using Cursor;
using GameStates;
using Player;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameStateManager gameStateManager;

    private void OnEnable()
    {
        playerInput.OnPause += ChangeActivityMenuPanel;
    }
    
    private void OnDisable()
    {
        playerInput.OnPause -= ChangeActivityMenuPanel;
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
        gameStateManager.PauseGame();
        CursorManager.Instance.UnlockCursor();
        Time.timeScale = 0;
    }

    private void ExitMenuPanel()
    {
        menuPanel.SetActive(false);
        gameStateManager.ResumeGame();
        CursorManager.Instance.LockCursor();
        Time.timeScale = 1;
    }
}
