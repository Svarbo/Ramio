using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class JumpButtonAnimationView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Button _button;
        private int pressHash = Animator.StringToHash("Press");
        private void OnEnable() =>
            _button.onClick.AddListener(Click);

        private void OnDisable() =>
            _button.onClick.RemoveListener(Click);

        private void Click()
        {
            _animator.SetTrigger(pressHash);
        }
    }
}