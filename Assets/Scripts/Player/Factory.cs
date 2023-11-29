using CameraFollowing;
using Data;
using Infrastructure.Inputs;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Player
{
    public class Factory
    {
        private Vector3 _startSpawnPosition;
        private readonly bool _isMobile;
        private readonly Type _difficult;

        public Factory(Vector3 startSpawnPosition, bool IsMobile, Type difficult)
        {
            _startSpawnPosition = startSpawnPosition;
            _isMobile = IsMobile;
            _difficult = difficult;
        }

        public MainHero Create()
        {
            MainHero player = Object.Instantiate
            (
                original: Resources.Load<MainHero>("Player"),
                position: _startSpawnPosition,
                rotation: Quaternion.identity
            );
            player.SetDifficult(LevelsProgress.Instance.GetDifficultByType(_difficult));
            Camera.main.GetComponent<TargetFollower>().Construct(player.transform, new Vector3(0, 0, -5));

            if (_isMobile)
            {
                player.InputServiceView.Activate();
                player.Input.SetInputService(new MobileInputService());
            }
            else
            {
                player.InputServiceView.Deactivate();
                player.Input.SetInputService(new StandaloneInputService());
            }

            return player;
        }
    }
}