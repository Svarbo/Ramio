using Data;
using Infrastructure.Inputs;
using UnityEngine;

namespace Players
{
    public class PlayerFactory
    {
        private Vector3 _startSpawnPosition;
        private UserInfo _userInfo;

        public PlayerFactory(Vector3 startSpawnPosition, UserInfo userInfo)
        {
            _startSpawnPosition = startSpawnPosition;
            _userInfo = userInfo;
        }

        public Player Create()
        {
            Player player = Object.Instantiate
            (
                original: Resources.Load<Player>("Player"),
                position: _startSpawnPosition,
                rotation: Quaternion.identity
            );

            TargetFollower targetFollower = Object.FindObjectOfType<TargetFollower>();
            targetFollower.Target = player.transform;
            targetFollower.Offset = new Vector3(0, 0, -5);

            //if (_userInfo.IsMobile)
            //    player.PlayerMover.SetInputService(new MobileInputService());
            //else
            //    player.PlayerMover.SetInputService(new StandaloneInputService());

            return player;
        }
    }
}