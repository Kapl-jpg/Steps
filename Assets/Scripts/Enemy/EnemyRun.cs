using Interfaces;
using UnityEngine;

namespace Enemy
{
    public class EnemyRun : MonoBehaviour,IState
    {
        [SerializeField] private Transform bodyTransform;
        [SerializeField] private float distanceBeforePlayer;
        
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed;
        
        public void Enter()
        {
            SetNewPosition();
            SetRotation();
        }

        public void Execute()
        {
            SetRotation();
        }

        public void FixedExecute()
        {
            SetMovement();
        }

        public void Exit()
        {
            
        }

        private void SetNewPosition()
        {
            float randomX = Random.Range(-1f,1f);
            float randomY = Random.Range(-1f,1f);
            Vector2 normalizedVector = new Vector2(randomX, randomY).normalized;
            
            Vector3 playerPosition = new Vector3(playerTransform.position.x, bodyTransform.position.y, playerTransform.position.z);
            Vector3 targetOffsetVector = new Vector3(normalizedVector.x, 0, normalizedVector.y)*distanceBeforePlayer;

            bodyTransform.position = playerPosition + targetOffsetVector;
        }
    
        private void SetMovement()
        {
            Vector3 moveDirection = (playerTransform.position - bodyTransform.position).normalized;
            rb.velocity = moveDirection * speed;
        }
        
        private void SetRotation()
        {
            bodyTransform.LookAt(new Vector3(playerTransform.position.x,bodyTransform.position.y,playerTransform.position.z));
        }
    }
}
