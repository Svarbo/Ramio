using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu
{
    public class BackToMainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private MenuSwitcher _menuSwitcher;
        
        private void OnEnable() =>
            _button.onClick.AddListener(EnableMainMenu);

        private void OnDisable() =>
            _button.onClick.RemoveListener(EnableMainMenu);

        public void EnableMainMenu() =>
            _menuSwitcher.EnableMainMenu();
    }
}