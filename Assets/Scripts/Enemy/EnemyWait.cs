using Interfaces;
using UnityEngine;

namespace Enemy.States
{
    public class EnemyWait : MonoBehaviour,IState
    {
        [SerializeField] private GameObject enemyBody;
        
        public void Enter()
        {
            enemyBody.SetActive(false);
        }

        public void Execute()
        {
            
        }

        public void FixedExecute()
        {
            
        }

        public void Exit()
        {
            enemyBody.SetActive(true);
        }
    }
}
