using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DisappearingPlatform : MonoBehaviour
{
    private Animator _animator;
    private int _disappearAnimation = Animator.StringToHash("Disappear");

    private void Awake() => 
        _animator = GetComponent<Animator>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            Disappear();
    }

    private void Disappear() => 
        _animator.Play(_disappearAnimation);

    public void Disable() => 
        gameObject.SetActive(false);
}