using UnityEngine;

namespace HandTorch
{
    public class HandTorchCharge : MonoBehaviour
    {
        [SerializeField] private float maxChargeLevel;
        public float MaxChargeLevel => maxChargeLevel;
        
        [SerializeField] private new Light light;
        
        private float _currentChargeLevel;
        public float CurrentChargeLevel => _currentChargeLevel;
        
        public bool ChargeIsOut { get; private set; }

        private void Start()
        {
            _currentChargeLevel = maxChargeLevel;
        }

        private void Update()
        {
            if (light.enabled)
            {
                if (_currentChargeLevel > 0)
                {
                    _currentChargeLevel -= Time.deltaTime;
                }
                else
                {
                    ChargeIsOut = true;
                }
            }
        }
    }
}