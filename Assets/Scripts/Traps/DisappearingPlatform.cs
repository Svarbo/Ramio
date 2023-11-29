using Player;
using UnityEngine;

namespace Traps
{
    [RequireComponent(typeof(Animator))]
    public class DisappearingPlatform : MonoBehaviour
    {
        private Animator _animator;
        private int _disappearAnimation = Animator.StringToHash("Disappear");

        private void Awake() =>
            _animator = GetComponent<Animator>();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<MainHero>(out MainHero player))
                Disappear();
        }

        private void Disappear() =>
            _animator.Play(_disappearAnimation);

        public void Disable() =>
            gameObject.SetActive(false);
    }
}