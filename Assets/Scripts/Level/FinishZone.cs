using Players;
using UI.Level.EndGame;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class FinishZone : MonoBehaviour
{
    private const string LastLevelName = "Level3";

    private PlayerCanvasDrawer _levelCanvasDrawer;
    private Animator _animator;
    private int _isAchievedParameter = Animator.StringToHash("IsAchieved");

    private void Awake() =>
        _animator = GetComponent<Animator>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player personage))
        {
            if (_levelCanvasDrawer == null)
                _levelCanvasDrawer = personage.GetComponentInChildren<PlayerCanvasDrawer>();

            PlayWinAnimation();

            if (IsLastLevel())
                _levelCanvasDrawer.ShowGratitudePanel();
            else
                _levelCanvasDrawer.ShowWinPanel();
        }
    }

    private void PlayWinAnimation() =>
        _animator.SetBool(_isAchievedParameter, true);

    private bool IsLastLevel()
    {
        string currentLevelName = SceneManager.GetActiveScene().name;
        return LastLevelName == currentLevelName;
    }
}