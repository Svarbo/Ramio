using Data;
using Infrastructure.Factories;
using UnityEngine;

namespace Infrastructure.States.Scenes
{
    public class GameLoopState : IPayloadState<LevelsInfo>
    {
        public void Exit()
        {
        }

        public void FixedUpdate(float deltaTime)
        {
        }

        public void LateUpdate(float deltaTime)
        {
        }

        public void Update(float deltaTime)
        {
        }

        public void Enter(LevelsInfo levelsInfo)
        {
            AbstractFactory abstractFactory = new AbstractFactory();
            LevelBootstrap levelBootstrap = abstractFactory.Create<LevelBootstrap>("LevelBootstrap");
            levelBootstrap.Construct(levelsInfo);
        }

        public void Enter()
        {
        }
    }
}