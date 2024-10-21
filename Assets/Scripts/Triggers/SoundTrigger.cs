using UnityEngine;

namespace Triggers
{
    public class SoundTrigger : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip audioClip;
        [SerializeField] private bool disableTrigger = true;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                audioSource.PlayOneShot(audioClip);
                gameObject.SetActive(!disableTrigger);
            }
        }
    }
}
