using UnityEngine;

namespace Traps.Doors
{
    [RequireComponent(typeof(Animator))]
    public class Door : MonoBehaviour
    {
        private Animator _animator;
        private int _openAnimation = Animator.StringToHash("Open");

        private void Start() =>
            _animator = GetComponent<Animator>();

        public void Open() =>
            _animator.Play(_openAnimation);
        
        // TODO не используется Ж: используется в анимации
        public void Off() =>
            gameObject.SetActive(false);
    }
}