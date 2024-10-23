using UnityEngine;

namespace Triggers
{
    public class AnimationTrigger : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private bool disableTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                animator.SetTrigger("Play");
            }
        }

        public void DisableTrigger()
        {
            gameObject.SetActive(!disableTrigger);
        }
    }
}