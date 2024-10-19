using Interfaces;
using UnityEngine;

namespace HandTorch
{
    public class HandTorchShoot:MonoBehaviour
    {
        [SerializeField] private float sphereCastRadius;
        [SerializeField] private float distanceCast;
        [SerializeField] private LayerMask targetMask;

        private void Update()
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(screenCenter);
            
            if (Physics.SphereCast(ray,sphereCastRadius,out RaycastHit hit,distanceCast,targetMask))
            {
                hit.collider.TryGetComponent(out IDamageable damageable);
                damageable?.ApplyDamage();
            }
        }
    }
}