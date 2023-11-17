public class MainMenuViewFactory
{
    private readonly AbstractFactory _abstractFactory;

    public MainMenuViewFactory() =>
        _abstractFactory = new AbstractFactory();

    public MainMenuView Create() =>
        _abstractFactory.Create<MainMenuView>("UI/MainMenu/MainMenuView");
}