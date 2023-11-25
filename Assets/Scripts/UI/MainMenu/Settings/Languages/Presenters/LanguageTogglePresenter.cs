namespace UI.MainMenu.Settings.Languages.Presenters
{
    public class LanguageTogglePresenter
    {
        private readonly LanguageSaveView _languageSaveView;

        public LanguageTogglePresenter(LanguageSaveView languageSaveView) =>
            _languageSaveView = languageSaveView;

        public void ShowButtonSaveSettings() =>
            _languageSaveView.Show();
    }
}