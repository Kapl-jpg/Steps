using UnityEngine;

public class ChangeCursor:MonoBehaviour
{
    [SerializeField] private bool lockCursor;
    private void Start()
    {
        if(lockCursor)
            LockCursor();
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    public static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
