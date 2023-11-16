using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level.EndGame.Panels
{
    public class LosePanel : MonoBehaviour
    {
        [SerializeField] private Button _buttonTryAgain;
        [SerializeField] private Button _buttonGoMenu;

        public event Action TryAgain;
        public event Action GoMenu;

        private void OnEnable()
        {
            _buttonTryAgain.onClick.AddListener(OnClicked1);
            _buttonGoMenu.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _buttonTryAgain.onClick.RemoveListener(OnClicked1);
            _buttonGoMenu.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked1() =>
            TryAgain?.Invoke();

        private void OnClicked() =>
            GoMenu?.Invoke();
    }
}