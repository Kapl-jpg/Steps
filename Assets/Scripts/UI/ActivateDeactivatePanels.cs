using UnityEngine;

namespace UI
{
    public class ActivateDeactivatePanels : MonoBehaviour
    {
        public void ChangePanel(GameObject panel)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
