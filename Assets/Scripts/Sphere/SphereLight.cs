using System.Collections;
using GameStates;
using Managers;
using UnityEngine;

namespace Sphere
{
    public class SphereLight : MonoBehaviour
    {
        [SerializeField] private new Light light;
        [SerializeField] private GameStateManager gameStateManager;

        [SerializeField] private float changeLightSpeed;
        [SerializeField] private float finalIntensity;
        [SerializeField] private float finalRange;
        [SerializeField] private Color finalColor;

        private float _startRange;
        private float _startIntensity;
        private Color _startColor;

        private void Start()
        {
            _startRange = light.range;
            _startIntensity = light.intensity;
            _startColor = light.color;
        }

        private void OnEnable()
        {
            gameStateManager.OnGameStateChanged += Final;
        }

        private void OnDisable()
        {
            gameStateManager.OnGameStateChanged -= Final;
        }

        private void Final(GameStateManager.GameState newState)
        {
            if (newState == GameStateManager.GameState.GameOver)
                StartCoroutine(FinalLight());
        }

        private IEnumerator FinalLight()
        {
            float lightValue = 0f;
            while (lightValue < 1)
            {
                lightValue += Time.deltaTime / changeLightSpeed;
                light.color = Color.Lerp(_startColor, finalColor, lightValue);
                light.range = Mathf.Lerp(_startRange, finalRange, lightValue);
                light.intensity = Mathf.Lerp(_startIntensity, finalIntensity, lightValue);
                yield return null;
            }

            SceneLoader.Instance.LoadWin();
        }
    }
}