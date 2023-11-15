using Level;
using UI.MainMenu.Models;
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
            LevelBootstrap levelBootstrap = Object.Instantiate(Resources.Load<LevelBootstrap>("LevelBootstrap"));
            levelBootstrap.Construct(levelsInfo);
        }

        public void Enter()
        {
        }
    }
}