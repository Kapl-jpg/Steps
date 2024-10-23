using Interfaces;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour,IDamageable
    {
        [SerializeField] private EnemyBehaviour enemyBehaviour;

        public void ApplyDamage()
        {
            enemyBehaviour.Death();
        }
    }
}
