using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Orange : MonoBehaviour
{
    private int _reward = 1;
    private AudioSource _audioSource;
    private Animator _animator;
    private int _collectedAnimation = Animator.StringToHash("Collected");

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.IncreaseScore(_reward);

            _animator.Play(_collectedAnimation);
            _audioSource.Play();
        }
    }

    public void Off() =>
        gameObject.SetActive(false);
}