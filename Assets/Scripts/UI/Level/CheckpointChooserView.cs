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
            _positiveResponseButton.onClick.AddListener(() => ReceiveResponse(true));
            _negativeResponseButton.onClick.AddListener(() => ReceiveResponse(false));
        }

        private void OnDisable()
        {
            _positiveResponseButton.onClick.RemoveAllListeners();
            _negativeResponseButton.onClick.RemoveAllListeners();
        }

        private void ReceiveResponse(bool value)
        {
            CheckpointChanged?.Invoke(value);
            gameObject.SetActive(false);
        }
    }
}