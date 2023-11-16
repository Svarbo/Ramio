using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FinishZone : MonoBehaviour
{
    //[SerializeField] private Referee _referee;

    private Animator _animator;
    private int _isAchievedParameter = Animator.StringToHash("IsAchieved");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            PlayWinAnimation();
           // _referee.DeclairWin();
        }
    }

    private void PlayWinAnimation()
    {
        _animator.SetBool(_isAchievedParameter, true);
    }
}