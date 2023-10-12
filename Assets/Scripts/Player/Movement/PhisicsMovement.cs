using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SurfaceSlider))]
public class PhisicsMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private SurfaceSlider _surfaceSlider;
    private Vector2 _directionAlongSurface;
    private Vector2 _offsetVector;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _surfaceSlider = GetComponent<SurfaceSlider>();
    }

    public void Move(Vector2 direction)
    {
        _directionAlongSurface = _surfaceSlider.Project(direction.normalized);
        _offsetVector = _directionAlongSurface * (_speed * Time.deltaTime);

        _rigidbody2D.MovePosition(_rigidbody2D.position + _offsetVector);
    }
}
