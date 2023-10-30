using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSource : MonoBehaviour
{
    [SerializeField] private AudioClip _transitionSound;
    [SerializeField] private AudioClip _appearingSound;
    [SerializeField] private AudioClip _deathSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayTransitionSound()
    {
        _audioSource.PlayOneShot(_transitionSound);
    }

    public void PlayAppearingSound()
    {
        _audioSource.PlayOneShot(_appearingSound);
    }

    public void PlayDeathSound()
    {
        _audioSource.PlayOneShot(_deathSound);
    }
}