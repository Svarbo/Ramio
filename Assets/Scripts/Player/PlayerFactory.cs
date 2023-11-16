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
            targetFollower.Construct(player.transform, new Vector3(0, 0, -5) );

            if (_userInfo.IsMobile)
            {
                player.GetComponentInChildren<InputServiceView>().gameObject.SetActive(true);
                player.PlayerInput.SetInputService(new MobileInputService());
            }
            else
            {
                player.GetComponentInChildren<InputServiceView>().gameObject.SetActive(false);
                player.PlayerInput.SetInputService(new StandaloneInputService());
            }

            return player;
        }
    }
}