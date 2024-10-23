using UnityEngine;

namespace Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private EnemyRun runState;
        [SerializeField] private EnemyAppearance appearanceState;
        [SerializeField] private EnemyDissolve dissolveState;

        private bool _isDead;
        private EnemyStateMachine _enemyStateMachine;

        private void Start()
        {
            _enemyStateMachine = new EnemyStateMachine();
            _enemyStateMachine.ChangeState(appearanceState);
        }

        private void Update()
        {
            _enemyStateMachine.Update();
        }

        private void FixedUpdate()
        {
            _enemyStateMachine.FixedUpdate();
        }

        public void Appearance()
        {
            _enemyStateMachine.ChangeState(appearanceState);
        }

        public void RunState()
        {
            _enemyStateMachine.ChangeState(runState);
        }
        
        public void Death()
        {
            _enemyStateMachine.ChangeState(dissolveState);
        }
        
    }
}