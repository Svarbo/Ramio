using UnityEngine;

public class SlideState : State
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _wallSlidingSpeed;

    private void OnEnable()
    {
        Slide();
    }

    private void Slide()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Mathf.Clamp(_rigidbody2D.velocity.y, -_wallSlidingSpeed, float.MaxValue));
    }
}