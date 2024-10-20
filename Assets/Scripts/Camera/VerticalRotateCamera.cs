using Player;
using UnityEngine;

namespace Camera
{
    public class VerticalRotateCamera : MonoBehaviour
    {
        [SerializeField] private float sensitivity;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Vector2 minMaxRotateAngle;
        private float _rotationX;

        private void Update()
        {
            VerticalRotate();
        }

        private void VerticalRotate()
        {
            _rotationX = Mathf.Clamp(_rotationX - playerInput.MouseAxis.y * sensitivity,
                -minMaxRotateAngle.x,
                minMaxRotateAngle.y);
            transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        }
    }
}