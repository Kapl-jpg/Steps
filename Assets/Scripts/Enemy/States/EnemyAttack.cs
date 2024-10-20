using UnityEngine;

namespace Enemy.States
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                sceneLoader.LoadLose();
            }
        }
    }
}
