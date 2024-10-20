using System.Collections;
using Enemy.States;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private EnemyRun runState;
        [SerializeField] private EnemyWait waitState;
        [SerializeField] private Vector2 minMaxTimeBeforeAppearance;
        [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
        [SerializeField] private float appearanceTime;
        [SerializeField] private float dissolveTime;

        private bool _isDead;
        private EnemyStateMachine _enemyStateMachine;

        private static readonly int DissolveValue = Shader.PropertyToID("_DissolveValue");

        private void Start()
        {
            _enemyStateMachine = new EnemyStateMachine();
            _enemyStateMachine.ChangeState(waitState);
            StartCoroutine(Appearance());
        }

        private void Update()
        {
            _enemyStateMachine.Update();
        }

        private void FixedUpdate()
        {
            _enemyStateMachine.FixedUpdate();
        }

        private IEnumerator Appearance()
        {
            float waitSeconds = Random.Range(minMaxTimeBeforeAppearance.x, minMaxTimeBeforeAppearance.y);
            yield return new WaitForSeconds(waitSeconds);
            
            _enemyStateMachine.ChangeState(runState);

            float dissolveValue = 0;
            while (dissolveValue < 1)
            {
                dissolveValue = Mathf.Clamp01(dissolveValue + Time.deltaTime / appearanceTime);
                skinnedMeshRenderer.material.SetFloat(DissolveValue, dissolveValue);
                yield return null;
            }
        }

        public void Death()
        {
            if(!_isDead)
                StartCoroutine(Dissolve());
        }

        private IEnumerator Dissolve()
        {
            _isDead = true;
            
            float dissolveValue = 1;
            while (dissolveValue > 0)
            {
                dissolveValue = Mathf.Clamp01(dissolveValue - Time.deltaTime / dissolveTime);
                skinnedMeshRenderer.material.SetFloat(DissolveValue, dissolveValue);
                yield return null;
            }
            _enemyStateMachine.ChangeState(waitState);
            _isDead = false;
            StartCoroutine(Appearance());
        }
    }
}