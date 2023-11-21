using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private Button _buttonTryAgain;
    [SerializeField] private Button _buttonGoMenu;

    private StateMachine _stateMachine;
    private LevelsInfo _levelsInfo;

    private void OnEnable()
    {
        _buttonTryAgain.onClick.AddListener(TryAgain);
        _buttonGoMenu.onClick.AddListener(GoToMainMenu);
    }

    private void OnDisable()
    {
        _buttonTryAgain.onClick.RemoveListener(TryAgain);
        _buttonGoMenu.onClick.RemoveListener(GoToMainMenu);
    }

    public void Construct(StateMachine stateMachine, LevelsInfo levelsInfo)
    {
        _levelsInfo = levelsInfo;
        _stateMachine = stateMachine;
    }

    private void TryAgain()
    {
        _levelsInfo.SceneName = SceneManager.GetActiveScene().name;
        _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
    }

    private void GoToMainMenu() =>
        _stateMachine.Enter(typeof(MainMenuState));
}