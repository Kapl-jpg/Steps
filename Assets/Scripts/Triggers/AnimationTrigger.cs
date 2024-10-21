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
                print("trigger");
                animator.SetTrigger("Play");
                gameObject.SetActive(!disableTrigger);
            }
        }
    }
}