using UnityEngine;

namespace Audio
{
    public class Steps : MonoBehaviour
    {
        [SerializeField] private float intervalSteps;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private AudioClip stepAudioClips;
        [SerializeField] private AudioSource stepAudioSource;

        private float _stepTimer;

        private void Update()
        {
            PlayGroundSound();
        }

        private void PlayGroundSound()
        {
            if (rb.velocity.magnitude > 0.1f)
            {
                _stepTimer += Time.deltaTime;
                if (_stepTimer >= intervalSteps)
                {
                    stepAudioSource.PlayOneShot(stepAudioClips);
                    _stepTimer = 0;
                }
            }
            else
            {
                _stepTimer = 0;
            }
        }
    }
}
