using UnityEngine;

namespace Traps
{
    [RequireComponent(typeof(Animator))]
    public class Burner : MonoBehaviour
    {
        [SerializeField] private DamageZone _damageZone;
        [SerializeField] private float _delay = 2f;
        [SerializeField] private float _workTime = 0.8f;
        [SerializeField] private bool _isStartActive = false;

        private Animator _animator;
        private float _currentDelay = 0;
        private float _currentWorkTime = 0;
        private int _isActiveParameter = Animator.StringToHash("IsOn");

        private void Awake() =>
            _animator = GetComponent<Animator>();

        private void Update()
        {
            if (_isStartActive)
            {
                _currentWorkTime += Time.deltaTime;

                if (_currentWorkTime >= _workTime)
                    Off();
            }
            else
            {
                _currentDelay += Time.deltaTime;

                if (_currentDelay >= _delay)
                    On();
            }
        }

        private void On()
        {
            _animator.SetBool(_isActiveParameter, true);

            _isStartActive = true;
            _damageZone.gameObject.SetActive(true);

            _currentDelay = 0;
        }

        private void Off()
        {
            _isStartActive = false;
            _damageZone.gameObject.SetActive(false);

            _animator.SetBool(_isActiveParameter, false);

            _currentWorkTime = 0;
        }
    }
}