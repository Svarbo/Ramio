using UnityEngine;

public class DamageZoneMover : MonoBehaviour
{
    [SerializeField] private float _motionSpeed;

    private Transform _transform;

    private void Awake() => 
        _transform = GetComponent<Transform>();

    private void Update() => 
        _transform.Translate(Vector2.right * _motionSpeed * Time.deltaTime);
}