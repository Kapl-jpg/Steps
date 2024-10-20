using Interfaces;
using UnityEngine;

namespace Enemy.States
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
