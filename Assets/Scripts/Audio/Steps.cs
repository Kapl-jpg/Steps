using UnityEngine;
using Random = UnityEngine.Random;

namespace Audio
{
    public class Steps : MonoBehaviour
    {
        [SerializeField] private float intervalSteps;
        [SerializeField] private CharacterController controller;
        [SerializeField] private AudioClip[] stepAudioClips;
        [SerializeField] private AudioSource stepAudioSource;
        
        private float _stepTimer;
        private void Update()
        {
            if (controller.velocity.magnitude > 0.1f)
            {
                _stepTimer += Time.deltaTime;
                if (_stepTimer >= intervalSteps)
                {
                    PlayStepSound();
                    _stepTimer = 0;
                }
            }
            else
            {
                _stepTimer = 0;
            }
        }

        private void PlayStepSound()
        {
            int randomClip = Random.Range(0, stepAudioClips.Length);
            stepAudioSource.PlayOneShot(stepAudioClips[randomClip]);
        }
    }
}
