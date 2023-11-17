using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HitState : PlayerState
{
    [SerializeField] private AudioClip _hitSound;

    private Rigidbody2D _rigidbody2D;
    private int _hitAnimation = Animator.StringToHash("Hit");

    protected override void Awake()
    {
        base.Awake();

        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rigidbody2D.velocity = Vector3.zero;

        PlayerAnimator.Play(_hitAnimation);
        AudioSource.PlayOneShot(_hitSound);
    }

    public override bool IsCompleted()
    {
        return PlayerInfo.IsHit == false
            || PlayerInfo.IsDesappearing;
    }
}