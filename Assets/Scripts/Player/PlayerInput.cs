using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        private Vector2 _mouseAxis;
        public Vector2 MouseAxis => _mouseAxis;
        private Vector2 _movementDirection;
        public Vector2 MovementDirection => _movementDirection;

        public delegate void ChangeLightHandler();
        public ChangeLightHandler ChangeLight;

        private void Update()
        {
            SetMovementDirection();
            SetMouseRotateAxis();
            SetLight();
        }

        private void SetMouseRotateAxis()
        {
            float horizontalAxis = Input.GetAxis("Mouse X");
            float verticalAxis = Input.GetAxis("Mouse Y");
            _mouseAxis = new Vector2(horizontalAxis, verticalAxis);
        }

        private void SetMovementDirection()
        {
            float horizontalDirection = Input.GetAxis("Horizontal");
            float verticalDirection = Input.GetAxis("Vertical");
            _movementDirection = new Vector2(horizontalDirection, verticalDirection);
        }

        private void SetLight()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeLight?.Invoke();
            }
        }
    }
}
