using ConstantValues;
using Infrastructure.States;
using Level;
using Data;
using Infrastructure.Factories;

namespace Infrastructure.States.Scenes
{
    public class GameLoopState : IPayloadState<LevelsInfo>
    {
        public void Exit()
        {
        }

        public void Enter(LevelsInfo levelsInfo)
        {
            AbstractFactory abstractFactory = new AbstractFactory();
            LevelBootstrap levelBootstrap = abstractFactory.Create<LevelBootstrap>(ResourcesPath.LevelBootstrap);
            levelBootstrap.Construct(levelsInfo);
        }

        public void Enter()
        {
        }
    }
}