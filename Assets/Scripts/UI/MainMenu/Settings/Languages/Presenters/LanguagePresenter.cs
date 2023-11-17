public class LanguagePresenter
{
    private readonly LanguageView _languageRuView;
    private readonly LanguageView _languageEnView;
    private readonly LanguageView _languageTrView;

    public LanguagePresenter(LanguageView languageRuView, LanguageView languageEnView, LanguageView languageTRView)
    {
        _languageRuView = languageRuView;
        _languageEnView = languageEnView;
        _languageTrView = languageTRView;
    }

    public void ChangeLanguage()
    {
        _languageEnView.SetDisactive();
        _languageRuView.SetDisactive();
        _languageTrView.SetDisactive();
    }
}