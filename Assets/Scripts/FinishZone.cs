using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FinishZone : MonoBehaviour
{
    private Animator _animator;
    private int _isAchievedParameter = Animator.StringToHash("IsAchieved");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayWinAnimation();
            player.GetComponentInChildren<Referee>().DeclairWin();
        }
    }

    private void PlayWinAnimation()
    {
        _animator.SetBool(_isAchievedParameter, true);
    }
}