using Managers;
using UnityEngine;

namespace Enemy
{
    public class EnemyTrigger : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                SceneLoader.Instance.LoadLose();
            }
        }
    }
}
