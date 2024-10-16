using UnityEngine;

namespace Triggers
{
    public class SoundTrigger : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private bool disableTrigger;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                audioSource.Play();
                gameObject.SetActive(disableTrigger);
            }
        }
    }
}
