using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Orange : MonoBehaviour
{
    private int reward = 1;
    private Animator _animator;
    private int _collectedAnimation = Animator.StringToHash("Collected");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            player.IncreaseScore(reward);
            _animator.Play(_collectedAnimation);
        }
    }

    private void Off()
    {
        gameObject.SetActive(false);
    }
}