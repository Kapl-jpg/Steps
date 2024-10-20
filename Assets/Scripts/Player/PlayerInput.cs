using System;
using GameStates;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private GameStateManager gameStateManager;
        private Vector2 _mouseAxis;
        public Vector2 MouseAxis => _mouseAxis;
        private Vector2 _movementDirection;
        public Vector2 MovementDirection => _movementDirection;

        public event Action OnChangeTorch;

        public event Action OnPause;

        private void Update()
        {
            if(gameStateManager.GetCurrentState() == GameStateManager.GameState.Paused)
                return;
            SetMovementDirection();
            SetMouseRotateAxis();
            SetLight();
            SetPause();
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
                OnChangeTorch?.Invoke();
            }
        }

        private void SetPause()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPause?.Invoke();
            }
        }
    }
}
