using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level.EndGame.Panels
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField] private Button _buttonGoToNextLevel;
        [SerializeField] private Button _buttonGoMenu;

        public event Action GoToNextLevel;
        public event Action GoMenu;

        private void OnEnable()
        {
            _buttonGoToNextLevel.onClick.AddListener(OnClicked1);
            _buttonGoMenu.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _buttonGoToNextLevel.onClick.RemoveListener(OnClicked1);
            _buttonGoMenu.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked1() =>
            GoToNextLevel?.Invoke();

        private void OnClicked() =>
            GoMenu?.Invoke();
    }
}