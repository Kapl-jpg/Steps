using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private CharacterController controller;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotateSpeed;

        private Vector2 _direction;

        private void Update()
        {
            _direction = playerInput.MovementDirection;
            
            SetMovement();
            SetRotation();
        }
        
        private void SetMovement()
        {
            Vector3 move = new Vector3(_direction.x, 0, _direction.y);
            move = transform.TransformDirection(move);
            controller.Move(move * (movementSpeed * Time.deltaTime));
        }
        
        private void SetRotation()
        {
            transform.Rotate(new Vector3(0,playerInput.MouseAxis.x * rotateSpeed,0));
        }
    }
}