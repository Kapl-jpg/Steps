using UnityEngine;

namespace UI
{
    public class ActivateDeactivatePanels : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private GameObject titleGame;
        
        public void ChangePanel()
        {
            panel.SetActive(!panel.activeSelf);
            titleGame.SetActive(!titleGame.activeSelf);
        }
    }
}
