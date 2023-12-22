using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level
{
    public class CheckpointChooserView : MonoBehaviour
    {
        [SerializeField] private Button _positiveResponseButton;
        [SerializeField] private Button _negativeResponseButton;

        public event Action<bool> CheckpointChanged;

        private void OnEnable()
        {
            _positiveResponseButton.onClick.AddListener(OnPositiveResponse);
            _negativeResponseButton.onClick.AddListener(OnNegativeResponse);
        }

        private void OnDisable()
        {
            _positiveResponseButton.onClick.RemoveListener(OnPositiveResponse);
            _negativeResponseButton.onClick.RemoveListener(OnNegativeResponse);
        }

        private void OnPositiveResponse()
        {
            CheckpointChanged?.Invoke(true);
            gameObject.SetActive(false);
        }

        private void OnNegativeResponse()
        {
            CheckpointChanged?.Invoke(false);
            gameObject.SetActive(false);
        }
    }
}