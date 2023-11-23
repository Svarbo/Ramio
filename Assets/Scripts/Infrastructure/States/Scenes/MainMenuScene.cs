public class MainMenuState : IPayloadState<LevelsInfo>
{
    private readonly AppCore _appCore;
    private DifficultChooserPresenter _difficultChooserPresenter;
    private LevelChooserPresenter _levelChooserPresenter;
    private GameAudioData _gameAudioData;
    private LanguagePresenter _languagePresenter;
    private DifficultBuilder _difficultBuilder;
    private LevelChooserBuilder _levelChooserBuilder;
    private LevelsInfo _levelsInfo;

    public MainMenuState(AppCore appCore) =>
        _appCore = appCore;

    public void FixedUpdate(float deltaTime)
    {
    }

    public void LateUpdate(float deltaTime)
    {
    }

    public void Update(float deltaTime)
    {
    }

    public void Exit()
    {
    }

    public void Enter(LevelsInfo levelsInfo)
    {
        _levelsInfo = levelsInfo;
        LoadScene();
    }

    public void Enter() { }

    private void LoadScene()
    {
        // TODO Fill UserInfo

        #region Fill UserInfo

        //UserInfo userInfo = abstractFactory.Load<UserInfo>("");
        //userInfo.IsMobile = Agava.WebUtility.Device.IsMobile;

        #endregion

        MainMenuViewFactory mainMenuViewFactory = new MainMenuViewFactory();
        MainMenuView mainMenuView = mainMenuViewFactory.Create();

        #region LevelMenuBuilders

        _levelChooserBuilder = new LevelChooserBuilder(mainMenuView.LevelMenuView, _levelsInfo, _appCore.StateMachine);
        _levelChooserPresenter = _levelChooserBuilder.Build();

        #region Difficults

        _difficultBuilder = new DifficultBuilder(_levelChooserPresenter, _levelsInfo, mainMenuView.LevelMenuView.DifficultChooserView);
        _difficultChooserPresenter = _difficultBuilder.Build();

        #endregion

        #endregion

        #region Settings
        
        #region Audio

        _gameAudioData = mainMenuView.SettingsView.AudioMenuView.GameAudioData;

        AudioMenuPresenter audioMenuPresenter = new AudioMenuPresenter
        (
            gameAudioData: _gameAudioData,
            effectsView: mainMenuView.SettingsView.AudioMenuView.EffectsView,
            musicView: mainMenuView.SettingsView.AudioMenuView.MusicView
        );

        mainMenuView.SettingsView.AudioMenuView.AllAudioView.Construct(audioMenuPresenter);
        mainMenuView.SettingsView.AudioMenuView.EffectsView.Construct(audioMenuPresenter);
        mainMenuView.SettingsView.AudioMenuView.MusicView.Construct(audioMenuPresenter);

        #endregion

        #region Language

        _languagePresenter = new LanguagePresenter
        (
            mainMenuView.SettingsView.LanguagesMainMenuView.LanguageRUView,
            mainMenuView.SettingsView.LanguagesMainMenuView.LanguageENView,
            mainMenuView.SettingsView.LanguagesMainMenuView.LanguageTRView
        );

        #endregion

        #endregion
    }
}