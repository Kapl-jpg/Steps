using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private Rigidbody rb;

        private Vector2 _direction;
        private float _rotate;

        private void Update()
        {
            _direction = playerInput.MovementDirection;
            
            SetRotation();
        }

        private void FixedUpdate()
        {
            SetMovement();
        }

        private void SetMovement()
        {
            Vector3 move = new Vector3(_direction.x, 0, _direction.y);
            move = transform.TransformDirection(move);
            rb.velocity = new Vector3(
                move.x * movementSpeed, 
                rb.velocity.y,
                move.z * movementSpeed);
        }

        private void SetRotation()
        {
            _rotate += playerInput.MouseAxis.x * rotateSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0,_rotate,0);
        }
    }
}