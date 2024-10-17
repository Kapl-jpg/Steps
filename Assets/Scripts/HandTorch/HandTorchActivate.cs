using Player;
using UnityEngine;

namespace HandTorch
{
    public class HandTorchActivate:MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Light handTorchLight;

        private void OnEnable()
        {
            playerInput.ChangeLight += ChangeLight;
        }

        private void OnDisable()
        {
            playerInput.ChangeLight -= ChangeLight;
        }

        private void ChangeLight()
        {
            handTorchLight.enabled = !handTorchLight.enabled;
        }
    }
}