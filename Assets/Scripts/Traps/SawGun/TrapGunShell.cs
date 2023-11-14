using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TrapGunShell : DamageZone
{
    private const string _groundLayer = "Ground";
    private const string _playerLayer = "Player";
    
    [SerializeField] private float _fallingSpeed;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        ConfigureRigidbody();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        int collisionLayer = collision.gameObject.layer;

        if (collisionLayer == LayerMask.NameToLayer(_groundLayer) || collisionLayer == LayerMask.NameToLayer(_playerLayer))
            gameObject.SetActive(false);
    }

    private void ConfigureRigidbody()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        _rigidbody2D.gravityScale = _fallingSpeed;
    }
}