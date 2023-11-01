using UnityEngine;

public class MovableTrap : MonoBehaviour
{
    [SerializeField] private TrapTarget _target;
    [SerializeField] private float _moveSpeed;

    private Transform _transform;
    private Vector3 _targetPosition;

    private void OnEnable()
    {
        _target.IsAchieved += Disable;
    }

    private void OnDisable()
    {
        _target.IsAchieved += Disable;
    }

    private void Awake()
    {
        _transform = transform;
        _targetPosition = _target.transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(_transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }

    private void Disable()
    {
        enabled = false;
    }
}