using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    public Vector3 Offset;
    public Transform Target;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void LateUpdate()
    {
        _transform.position = Target.position + Offset;
    }
}