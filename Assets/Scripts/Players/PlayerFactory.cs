using System;
using Camera;
using ConstantValues;
using Data;
using Infrastructure.Inputs;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Players
{
    public class PlayerFactory
    {
        private readonly bool _isMobile;
        private readonly Type _difficult;

        private Vector3 _startSpawnPosition;
        private Vector3 _cameraOffset = new Vector3(0, 0, -5);

        public PlayerFactory(Vector3 startSpawnPosition, bool isMobile, Type difficult)
        {
            _startSpawnPosition = startSpawnPosition;
            _isMobile = isMobile;
            _difficult = difficult;
        }

        public Player Create()
        {
            Player player = Object.Instantiate(
                original: Resources.Load<Player>(ResourcesPath.PlayerPath),
                position: _startSpawnPosition,
                rotation: Quaternion.identity);

            UnityEngine.Camera.main.GetComponent<TargetFollower>().Construct(player.transform, _cameraOffset);

            SetAttemptsCount(player);
            SetInputService(player);

            return player;
        }

        private void SetAttemptsCount(Player player)
        {
            int count = LevelsProgress.Instance.GetDifficultByType(_difficult).GetCountTryBySceneName(SceneManager.GetActiveScene().name);
            player.SetAttemptsCount(count);
        }

        private void SetInputService(Player personage)
        {
            if (_isMobile)
            {
                personage.InputServiceView.Activate();
                personage.Input.SetInputService(new MobileInputService());
            }
            else
            {
                personage.InputServiceView.Deactivate();
                personage.Input.SetInputService(new StandaloneInputService());
            }
        }
    }
}