using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ClosingDoor : MonoBehaviour
{
    private Animator _animator;
    private int _closeAnimation = Animator.StringToHash("Close");
    private int _openAnimation = Animator.StringToHash("Open");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Close()
    {
        _animator.Play(_closeAnimation);
    }

    public void Open()
    {
        _animator.Play(_openAnimation);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}