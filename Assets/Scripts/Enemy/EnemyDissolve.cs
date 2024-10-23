using System.Collections;
using Interfaces;
using UnityEngine;

namespace Enemy
{
    public class EnemyDissolve : MonoBehaviour,IState
    {
        [SerializeField] private EnemyBehaviour enemyBehaviour;
        [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
        [SerializeField] private float dissolveTime;
        private static readonly int DissolveValue = Shader.PropertyToID("_DissolveValue");
        
        public void Enter()
        {
            StartCoroutine(Dissolve());
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
        
        
        private IEnumerator Dissolve()
        {
            float dissolveValue = 1;
            while (dissolveValue > 0)
            {
                dissolveValue = Mathf.Clamp01(dissolveValue - Time.deltaTime / dissolveTime);
                skinnedMeshRenderer.material.SetFloat(DissolveValue, dissolveValue);
                yield return null;
            }
            enemyBehaviour.Appearance();
        }
    }
}
