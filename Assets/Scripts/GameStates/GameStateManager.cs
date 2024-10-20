using System;
using UnityEngine;

namespace GameStates
{
    public class GameStateManager:MonoBehaviour
    {
        public enum GameState
        {
            Playing,
            Paused,
            GameOver
        }

        private GameState _currentState;

        public event Action<GameState> OnGameStateChanged;
        
        private void Start()
        {
            ChangeState(GameState.Playing);
        }

        public void ChangeState(GameState newState)
        {
            if (_currentState != newState)
            {
                _currentState = newState;
                OnGameStateChanged?.Invoke(newState);
            }
        }

        public void PauseGame()
        {
            ChangeState(GameState.Paused);
        }

        public void ResumeGame()
        {
            ChangeState(GameState.Playing);
        }

        public void EndGame()
        {
            ChangeState(GameState.GameOver);
        }
        
        public GameState GetCurrentState()
        {
            return _currentState;
        }
    }
}