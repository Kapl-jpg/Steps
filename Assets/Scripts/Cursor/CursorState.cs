using UnityEngine;

namespace Cursor
{
    public class CursorState : MonoBehaviour
    {
        [SerializeField] private bool lockCursor;

        private void Start()
        {
            if (lockCursor)
            {
                CursorManager.Instance.LockCursor();
            }
            else
            {
                CursorManager.Instance.UnlockCursor();
            }
        }
    }
}
