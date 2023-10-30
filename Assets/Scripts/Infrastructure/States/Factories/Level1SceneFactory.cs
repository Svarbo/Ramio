using Infrastructure.States.Scenes;

namespace Infrastructure.States.Factories
{
    public class Level1SceneFactory : ISceneFactory
    {
        public IScene Create() =>
            new Level1Scene();
    }
}