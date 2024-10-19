using UnityEngine;

namespace Enemy.States
{
    public class EnemyStateMachine
    {
        private IState _currentState;
    
        public void ChangeState(IState newState)
        {
            if(_currentState == newState)
                return;
            
            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
        }

        public void Update()
        {
            _currentState?.Execute();
        }

        public void FixedUpdate()
        {
            _currentState?.FixedExecute();
        }
    }
}