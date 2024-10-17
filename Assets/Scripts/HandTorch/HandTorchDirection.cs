using UnityEngine;

namespace HandTorch
{
    public class HandTorchDirection : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
    
        private void Update()
        {
            transform.rotation = cameraTransform.rotation;
        }
    }
}
