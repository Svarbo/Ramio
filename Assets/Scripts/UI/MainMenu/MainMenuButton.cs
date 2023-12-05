using Transitions;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MainMenu
{
    [RequireComponent(typeof(Button))]
    public class MainMenuButton : MonoBehaviour
    {
        [SerializeField] private MenuSwitcher _menuSwitcher;

        private Button _button;

        private void Awake() =>
            _button = GetComponent<Button>();

        private void OnEnable() =>
            _button.onClick.AddListener(_menuSwitcher.EnableMainMenu);

        private void OnDisable() =>
            _button.onClick.RemoveListener(_menuSwitcher.EnableMainMenu);
    }
}