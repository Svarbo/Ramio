using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Burner : MonoBehaviour
{
    [SerializeField] private DamageZone _damageZone;
    [SerializeField] private AudioClip _switchSound;
    [SerializeField] private float _delay = 2f;
    [SerializeField] private float _workTime = 0.8f;
    [SerializeField] private bool _isStartActive = false;

    private Animator _animator;
    private AudioSource _audioSource;
    private float _currentDelay = 0;
    private float _currentWorkTime = 0;
    private int _isActiveParameter = Animator.StringToHash("IsOn");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

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

            if(_currentDelay >= _delay)
                On();
        }
    }

    private void On()
    {
        _isStartActive = true;
        _animator.SetBool(_isActiveParameter, true);
        _damageZone.gameObject.SetActive(true);

        _currentDelay = 0;
        _audioSource.PlayOneShot(_switchSound);
    }

    private void Off()
    {
        _isStartActive = false;
        _animator.SetBool(_isActiveParameter, false);
        _damageZone.gameObject.SetActive(false);

        _currentWorkTime = 0;
        _audioSource.PlayOneShot(_switchSound);
    }
}