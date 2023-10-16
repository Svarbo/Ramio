using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fader : MonoBehaviour
{
    private Animator _animator;
    private int _fadeOutAnimation = Animator.StringToHash("FadeOut");
    private int _fadeInAnimation = Animator.StringToHash("FadeIn");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        FadeOut();
    }

    private void FadeOut()
    {
        _animator.Play(_fadeOutAnimation);
    }

    public void FadeIn()
    {
        _animator.Play(_fadeInAnimation);
    }
}