using UnityEngine;

namespace Camera
{
    [ExecuteInEditMode]
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Vector3 offset;

        private void Update()
        {
            SetMovement();
        }

        private void SetMovement()
        {
            if (playerTransform)
            {
                transform.position = playerTransform.position + offset;
            }
        }
    }
}
