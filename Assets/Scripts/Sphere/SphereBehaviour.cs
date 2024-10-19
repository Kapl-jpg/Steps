using System.Collections;
using UnityEngine;

namespace Sphere
{
    public class SphereBehaviour : MonoBehaviour
    {
        [SerializeField] private new Light light;
        [SerializeField] private new ParticleSystem particleSystem;
        [SerializeField] private Transform[] points;
        [SerializeField] private float movementSpeed;
        [SerializeField] private Transform enemyBodyTransform;
        [SerializeField] private Vector2 minMaxLightDistance;
        [SerializeField] private MeshRenderer meshRenderer;

        [Header("Final light values")] [SerializeField]
        private float lightSpeed;
        [SerializeField][ColorUsage(false,true)] private Color finalColor;
        [SerializeField] private float finalIntensity;
        [SerializeField] private float finalRange;

        private Vector3 _targetPoint;
        private int _pointIndex;
        private float _changeDistance;
        private float _startRange;
        private float _startIntensity;
        private Color _startColor;

        private bool _final;
        private float _dissolveValue = 1;
        private static readonly int DissolveValue = Shader.PropertyToID("_DissolveValue");

        private void Start()
        {
            _pointIndex = 0;
            _startRange = light.range;
            _startIntensity = light.intensity;
            _changeDistance = minMaxLightDistance.y - minMaxLightDistance.x;
            _targetPoint = points[_pointIndex].position;
            _startColor = light.color;
        }

        private void Update()
        {
            if (_final)
                return;
            SetMovement();
            SetLight();
        }

        private void SetMovement()
        {
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
                    StartCoroutine(FinalLight());
                }
            }
        }

        private IEnumerator FinalLight()
        {
            _final = true;
            particleSystem.gameObject.SetActive(false);
            while (_dissolveValue>0)
            {
                _dissolveValue -= Time.deltaTime/lightSpeed;
                light.color = Color.Lerp(finalColor,_startColor ,_dissolveValue);
                light.range = Mathf.Lerp(finalRange,_startRange,_dissolveValue);
                light.intensity = Mathf.Lerp(finalIntensity,_startIntensity,_dissolveValue);
                meshRenderer.material.SetFloat(DissolveValue,_dissolveValue);
                yield return null;

            }
        }

        private void SetLight()
        {
            if (DistanceBetweenEnemy() < minMaxLightDistance.y)
            {
                _dissolveValue = DistanceBetweenEnemy() / _changeDistance;
                meshRenderer.material.SetFloat(DissolveValue,_dissolveValue);
            }
        }

        private float DistanceBetweenEnemy()
        {
            return Vector3.Distance(transform.position, enemyBodyTransform.position);
        }
    }
}
