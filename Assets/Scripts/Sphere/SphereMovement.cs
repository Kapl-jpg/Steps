using GameStates;
using UnityEngine;

namespace Sphere
{
    public class SphereMovement : MonoBehaviour
    {
        [SerializeField] private GameStateManager gameStateManager;
        [SerializeField] private Transform[] points;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float minDistance;
        
        private Vector3 _targetPoint;
        private int _pointIndex;

        private bool _final;

        private void Start()
        {
            _pointIndex = 0;
            _targetPoint = points[_pointIndex].position;
        }

        private void Update()
        {
            SetMovement();
        }

        private void SetMovement()
        {
            if (_final)
                return;
            
            if(PlayerInRange())
                transform.position = Vector3.MoveTowards(transform.position, _targetPoint, movementSpeed * Time.deltaTime);
            
            if (transform.position == _targetPoint)
            {
                if (_pointIndex < points.Length-1)
                {
                    _pointIndex++;
                    _targetPoint = points[_pointIndex].position;
                }
                else
                {
                    _final = true;
                    gameStateManager.EndGame();
                }
            }
        }
        public bool PlayerInRange()
        {
            return Vector3.Distance(transform.position, playerTransform.position)<minDistance;
        }
    }
}
