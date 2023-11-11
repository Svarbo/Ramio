using UnityEngine;

[RequireComponent(typeof(Animator))]
public class JumpBoost : MonoBehaviour
{
    private Animator _animator;
    private int _isCollectedAnimation = Animator.StringToHash("Collected");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<ExtraJumpChecker>(out ExtraJumpChecker extraJumpChecker))
        {
            extraJumpChecker.AddExtraJump();
            _animator.Play(_isCollectedAnimation);
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}