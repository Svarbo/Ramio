using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TrapGunShell : DamageZone
{
    [SerializeField] private float _fallingSpeed;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        ConfigureRigidBody();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    private void ConfigureRigidBody()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody2D.gravityScale = _fallingSpeed;
    }
}