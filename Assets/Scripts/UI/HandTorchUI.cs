using HandTorch;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HandTorchUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text tmpText;
        [SerializeField] private HandTorchCharge handTorchCharge;
        [SerializeField] private float maxChargeValue;
        
        private void Update()
        {
            float interpolateValue = Mathf.Clamp01(handTorchCharge.CurrentChargeLevel / handTorchCharge.MaxChargeLevel);
            float chargeValue = Mathf.Lerp(0, maxChargeValue, interpolateValue);
                
            tmpText.text = $"Заряд: {Mathf.Ceil(chargeValue)}%";
        }
    }
}
