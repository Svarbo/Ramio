using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    private Animator _animator;
    private int _openAnimation = Animator.StringToHash("Open");

    private void Start() => 
        _animator = GetComponent<Animator>();

    public void Open() => 
        _animator.Play(_openAnimation);

    public void Off() => 
        gameObject.SetActive(false);
}