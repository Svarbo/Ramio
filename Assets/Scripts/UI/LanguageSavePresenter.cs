using UnityEngine.SceneManagement;

public class LanguageSavePresenter
{
    private StateMachine _stateMachine;
    private LevelsInfo _levelsInfo;
    private LanguageChanger _languageChanger;

    public LanguageSavePresenter(StateMachine stateMachine, LevelsInfo levelsInfo, LanguageChanger languagesChanger)
    {
        _stateMachine = stateMachine;
        _levelsInfo = levelsInfo;
        _languageChanger = languagesChanger;
    }

    public void SaveLanguageChanges() => 
        _languageChanger.ChangeLanguage();

    public void RestartScene()
    {
        _levelsInfo.SceneName = SceneManager.GetActiveScene().name;
        _stateMachine.Enter(typeof(LoadLevelState), _levelsInfo);
    }
}