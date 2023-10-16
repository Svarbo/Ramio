using UnityEngine;

public class SwitchablePlatform : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private bool _isStartActive;

    private GameObject _gameObject;
    private float _currentDelay = 0;
    private bool _isActive;

    private void Start()
    {
        _gameObject = gameObject;
        _isActive = _isStartActive;

        Switch(_isActive);
    }

    private void Update()
    {
        _currentDelay += Time.deltaTime;

        if (_currentDelay >= _delay)
            Switch(!_isActive);
    }

    private void Switch(bool isActive)
    {
        _gameObject.SetActive(isActive);
        _currentDelay = 0;
    }
}