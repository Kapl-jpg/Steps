using System.Collections;
using Interfaces;
using UnityEngine;

namespace Enemy
{
    public class EnemyAppearance : MonoBehaviour, IState
    {
        [SerializeField] private EnemyBehaviour enemyBehaviour;
        [SerializeField] private Vector2 minMaxTimeBeforeAppearance;
        [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
        [SerializeField] private GameObject body;
        [SerializeField] private float appearanceTime;

        private static readonly int DissolveValue = Shader.PropertyToID("_DissolveValue");

        
        public void Enter()
        {
            StartCoroutine(Appearance());
        }

        public void Execute()
        {

        }

        public void FixedExecute()
        {

        }

        public void Exit()
        {

        }
        
        private IEnumerator Appearance()
        {
            body.SetActive(false);
            float waitSeconds = Random.Range(minMaxTimeBeforeAppearance.x, minMaxTimeBeforeAppearance.y);
            yield return new WaitForSeconds(waitSeconds);

            body.SetActive(true);
            float dissolveValue = 0;
            while (dissolveValue < 1)
            {
                dissolveValue = Mathf.Clamp01(dissolveValue + Time.deltaTime / appearanceTime);
                skinnedMeshRenderer.material.SetFloat(DissolveValue, dissolveValue);
                yield return null;
            }

            enemyBehaviour.RunState();
        }
    }
}