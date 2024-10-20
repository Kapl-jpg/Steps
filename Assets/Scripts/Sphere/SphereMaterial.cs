using System;
using System.Collections;
using GameStates;
using UnityEngine;

namespace Sphere
{
    public class SphereMaterial:MonoBehaviour
    {
        [SerializeField] private GameStateManager gameStateManager;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private SphereMovement sphereMovement;
        [SerializeField] private Transform playerTransform;
        
        [SerializeField] private float distanceDissolve;
        [SerializeField] private float finalDissolveTime;
        
        private static readonly int DissolveValue = Shader.PropertyToID("_DissolveValue");
        private float _dissolveValue = 1;

        private bool _final;

        private void OnEnable()
        {
            gameStateManager.OnGameStateChanged += Final;
        }
        
        private void OnDisable()
        {
            gameStateManager.OnGameStateChanged -= Final;
        }

        private void Update()
        {
            SetMaterial();
        }
        
        private void SetMaterial()
        {
            if(_final)
                return;
            if (sphereMovement.PlayerInRange())
            {
                _dissolveValue = DistanceBeforePlayer() / distanceDissolve;
                meshRenderer.material.SetFloat(DissolveValue,Mathf.Lerp(1,0,_dissolveValue));
            }
        }

        private void Final(GameStateManager.GameState newState)
        {
            if(newState == GameStateManager.GameState.GameOver)
                StartCoroutine(FinalDissolve());
        }

        private IEnumerator FinalDissolve()
        {
            _final = true;
            while (_dissolveValue>0)
            {
                _dissolveValue = Mathf.Clamp01(_dissolveValue - Time.deltaTime / finalDissolveTime);
                meshRenderer.material.SetFloat(DissolveValue,_dissolveValue);
                yield return null;
            }
        }

        private float DistanceBeforePlayer()
        {
            return Vector3.Distance(playerTransform.position, transform.position);
        }
    }
}