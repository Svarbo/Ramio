using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    private Vector3 _offset;
    private Transform _target;

    private Transform _transform;

    private void Awake() => 
        _transform = transform;

    private void LateUpdate() => 
        _transform.position = _target.position + _offset;

    public void Construct(Transform target, Vector3 offset)
    {
        _target = target;
        _offset = offset;
    }
}