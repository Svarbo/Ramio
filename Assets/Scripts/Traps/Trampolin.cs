using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Trampolin : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;

    private float _currentDelay = 0;
    private Animator _animator;
    private int _isPushParameter = Animator.StringToHash("IsPush");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _currentDelay += Time.deltaTime;

        if (_currentDelay >= _delay)
            Push();
    }

    private void Push()
    {
        _currentDelay = 0;

        _animator.SetBool(_isPushParameter, true);
    }
}