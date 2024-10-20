using Player;
using UnityEngine;

namespace HandTorch
{
    public class HandTorchActivate:MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Light handTorchLight;
        [SerializeField] private HandTorchCharge handTorchCharge;
        private void OnEnable()
        {
            playerInput.ChangeLight += ChangeLight;
        }

        private void OnDisable()
        {
            playerInput.ChangeLight -= ChangeLight;
        }

        private void Update()
        {
            if (handTorchCharge.ChargeIsOut && handTorchLight.enabled)
            {
                handTorchLight.enabled = false;
            }
        }

        private void ChangeLight()
        {
            if(!handTorchCharge.ChargeIsOut)
                handTorchLight.enabled = !handTorchLight.enabled;
        }
    }
}