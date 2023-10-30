using Infrastructure.States.Scenes;

namespace Infrastructure.States.Factories
{
    public class MainMenuSceneFactory : ISceneFactory
    {
        public IScene Create() =>
            new MainMenuScene();
    }
}