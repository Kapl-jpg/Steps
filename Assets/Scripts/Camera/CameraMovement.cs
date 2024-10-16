using System;
using UnityEngine;

namespace Camera
{
    [ExecuteInEditMode]
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Vector3 offset;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

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
